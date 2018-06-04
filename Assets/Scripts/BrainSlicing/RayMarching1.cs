using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

[RequireComponent(typeof(Camera))]
public class RayMarching1 : MonoBehaviour
{
	[SerializeField]
	[Header("Render in a lower resolution to increase performance.")]
	private int downscale = 2;
	[SerializeField]
	private LayerMask volumeLayer;
    
	[SerializeField]
	private Shader compositeShader;
	[SerializeField]
	private Shader renderFrontDepthShader;
	[SerializeField]
	private Shader renderBackDepthShader;
	[SerializeField]
	private Shader rayMarchShader;
    private int numSlices;

	[SerializeField][Header("Remove all the darker colors")]
	private bool increaseVisiblity = false;

	private Texture2D[] slices;
	[SerializeField][Range(0, 1)]
	private float opacity = 1;
	[Header("Volume texture size. These must be a power of 2")]
	[SerializeField]
	private int volumeWidth = 256;
	[SerializeField]
	private int volumeHeight = 256;
	[SerializeField]
	private int volumeDepth = 256;
	[Header("Clipping planes percentage")]
	[SerializeField]
	private Vector4 clipDimensions = new Vector4(100, 100, 100, 0);

	private Material _rayMarchMaterial;
	private Material _compositeMaterial;
	private Camera _ppCamera;
	private Texture3D _volumeBuffer;

    private void Awake()
	{
		_rayMarchMaterial = new Material(rayMarchShader);
		_compositeMaterial = new Material(compositeShader);
	}

	private void Start()
	{
		GenerateVolumeTexture("MR");
	}

	private void OnDestroy()
	{
		if(_volumeBuffer != null)
		{
			Destroy(_volumeBuffer);
		}
	}

	[SerializeField]
    private Transform clipPlane1, clipPlane2, clipPlane3;
    [SerializeField]
	private Transform cubeTarget;
	
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		_rayMarchMaterial.SetTexture("_VolumeTex", _volumeBuffer);

		var width = source.width / downscale;
		var height = source.height / downscale;

        if (_ppCamera == null)
        {
            var go = new GameObject("PPCamera1");
            _ppCamera = go.AddComponent<Camera>();
            _ppCamera.enabled = false;
        }

        _ppCamera.CopyFrom(GetComponent<Camera>());
        _ppCamera.clearFlags = CameraClearFlags.SolidColor;
        _ppCamera.backgroundColor = Color.white;
        _ppCamera.cullingMask = volumeLayer;

        var frontDepth = RenderTexture.GetTemporary(width, height, 0, RenderTextureFormat.ARGBFloat);
		var backDepth = RenderTexture.GetTemporary(width, height, 0, RenderTextureFormat.ARGBFloat);

		var volumeTarget = RenderTexture.GetTemporary(width, height, 0);

        //// Render depths
        _ppCamera.targetTexture = frontDepth;
        _ppCamera.RenderWithShader(renderFrontDepthShader, "RenderType");
        _ppCamera.targetTexture = backDepth;
        _ppCamera.RenderWithShader(renderBackDepthShader, "RenderType");

        // Render volume
        _rayMarchMaterial.SetTexture("_FrontTex", frontDepth);
		_rayMarchMaterial.SetTexture("_BackTex", backDepth);
        _rayMarchMaterial.SetFloat("_Opacity", opacity); // Blending strength 
        _rayMarchMaterial.SetVector("_ClipDims", clipDimensions / 100f); // Clip box

        if (cubeTarget != null)
        {
            if (clipPlane1.gameObject.activeSelf)
            {
                var p = new Plane(
                    cubeTarget.InverseTransformDirection(clipPlane1.transform.up),
                    cubeTarget.InverseTransformPoint(clipPlane1.position));
                _rayMarchMaterial.SetVector("_ClipPlane", new Vector4(p.normal.x, p.normal.y, p.normal.z, p.distance));
            }
            else if (clipPlane2.gameObject.activeSelf)
            {
                var l = new Plane(
                    cubeTarget.InverseTransformDirection(clipPlane2.transform.up),
                    cubeTarget.InverseTransformPoint(clipPlane2.position));
                _rayMarchMaterial.SetVector("_ClipPlane", new Vector4(l.normal.x, l.normal.y, l.normal.z, l.distance));
            }
            else if (clipPlane3.gameObject.activeSelf)
            {
                var m = new Plane(
                    cubeTarget.InverseTransformDirection(clipPlane3.transform.up),
                    cubeTarget.InverseTransformPoint(clipPlane3.position));
                _rayMarchMaterial.SetVector("_ClipPlane", new Vector4(m.normal.x, m.normal.y, m.normal.z, m.distance));
            }
        }
        else
        {
            _rayMarchMaterial.SetVector("_ClipPlane", Vector4.zero);
        }




		Graphics.Blit(null, volumeTarget, _rayMarchMaterial);

		//Composite
		_compositeMaterial.SetTexture("_BlendTex", volumeTarget);
		Graphics.Blit(source, destination, _compositeMaterial);

		RenderTexture.ReleaseTemporary(volumeTarget);
		RenderTexture.ReleaseTemporary(frontDepth);
		RenderTexture.ReleaseTemporary(backDepth);
	}

	public void GenerateVolumeTexture(string data)
	{
        string subj = "";
        if (data == "MR") subj = "PY18N002";
        if (data == "CT") subj = "PY18N002_CT";
        var dir = new DirectoryInfo(string.Format("Assets/Resources/{0}",subj));
        FileInfo[] info = dir.GetFiles("*.tif");
        numSlices = info.Length;
        slices = new Texture2D[numSlices];

        for (int i = 0; i < numSlices; i++)
        {
            string sample = string.Format("{0}/{0}{1}", subj, i);
            slices[i] = Resources.Load(sample) as Texture2D;
        }

        _volumeBuffer = new Texture3D(volumeWidth, volumeHeight, volumeDepth, TextureFormat.ARGB32, false);
		
		var w = _volumeBuffer.width;
		var h = _volumeBuffer.height;
		var d = _volumeBuffer.depth;

        // skip some slices if we can't fit it all in
        var countOffset = (slices.Length - 1) / (float)d;
		var volumeColors = new Color[w * h * d];
		
		var sliceCount = 0;
		var sliceCountFloat = 0f;
		for(int z = 0; z < d; z++)
		{
			sliceCountFloat += countOffset;
			sliceCount = Mathf.FloorToInt(sliceCountFloat);
			for(int x = 0; x < w; x++)
			{
				for(int y = 0; y < h; y++)
				{
					var idx = x + (y * w) + (z * (w * h));
					volumeColors[idx] = slices[sliceCount].GetPixelBilinear(x / (float)w, y / (float)h); 
					if(increaseVisiblity)
					{
                        volumeColors[idx].a *= volumeColors[idx].r;
                    }
                }
			}
		}
		
		_volumeBuffer.SetPixels(volumeColors);
		_volumeBuffer.Apply();
		
		_rayMarchMaterial.SetTexture("_VolumeTex", _volumeBuffer);
	}
}

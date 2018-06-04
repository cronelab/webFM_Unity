using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIElements : MonoBehaviour {

    private GameObject lPia, rPia;
    private GameObject lHip, rHip;
    private GameObject lThal, rThal;
    private GameObject brainstem;
    private GameObject lPut, rPut;
    private GameObject lamgd, ramgd;
    private GameObject lCaud, rCaud;
    private GameObject brainMesh;
    public GameObject ECoG_Electrodes, SEEG_Electrodes;
    private GameObject structBut, transBut;

    private Renderer lHemiRend, rHemiRend,lPutRend,rPutRend,lHipRend,rHipRend,lThalRend,rThalRend,lAmgdRend,rAmgdRend,
        lCaudRend,rCaudRend, brainStemRend;
    private Slider tranSlider1, tranSlider2, tranSlider3;
    private Slider xSlider, ySlider, zSlider;


    private Vector3 screenPoint;
    private Vector3 offset;

    private GameObject clipPlaneX, clipPlaneY, clipPlaneZ;
    public void Awake()
    {
        WebGLInput.captureAllKeyboardInput = false;
    }
    private void Start()
    {
        Test();
        tranSlider1 = GameObject.Find("lPiaSlider").GetComponent<Slider>();
        tranSlider2 = GameObject.Find("rPiaSlider").GetComponent<Slider>();
        tranSlider3 = GameObject.Find("subStructSlider").GetComponent<Slider>();
        structBut = GameObject.Find("StructureToggle");
        transBut = GameObject.Find("Transparency");
        structBut.SetActive(false);
        transBut.SetActive(false);
        brainMesh = GameObject.Find("PY17N009");
        brainMesh.SetActive(true);
        //xSlider = GameObject.Find("xSlider").GetComponent<Slider>();
        //ySlider = GameObject.Find("ySlider").GetComponent<Slider>();
        //zSlider = GameObject.Find("zSlider").GetComponent<Slider>();
        //////Clipping planes
        //clipPlaneX = GameObject.Find("Clipping PlaneX");
        //clipPlaneY = GameObject.Find("Clipping PlaneY");
        //clipPlaneZ = GameObject.Find("Clipping PlaneZ");
    }
    public void Test()
    {
        lPia = GameObject.Find("lPia");
        rPia = GameObject.Find("rPia");
        lPut = GameObject.Find("lPut");
        rPut = GameObject.Find("rPut");
        lHip = GameObject.Find("lhipp");
        rHip = GameObject.Find("rhipp");
        lThal = GameObject.Find("lthal");
        rThal = GameObject.Find("rthal");
        lamgd = GameObject.Find("lamgd");
        ramgd = GameObject.Find("ramgd");
        lCaud = GameObject.Find("lCaud");
        rCaud = GameObject.Find("rCaud");
        brainstem = GameObject.Find("brainstem");

        lHemiRend = lPia.GetComponent<Renderer>();
        rHemiRend = rPia.GetComponent<Renderer>();
        rPutRend = rPut.GetComponent<Renderer>();
        lPutRend = lPut.GetComponent<Renderer>();
        rHipRend = rHip.GetComponent<Renderer>();
        lHipRend = lHip.GetComponent<Renderer>();
        lThalRend = lThal.GetComponent<Renderer>();
        rThalRend = rThal.GetComponent<Renderer>();
        lAmgdRend = lamgd.GetComponent<Renderer>();
        rAmgdRend = ramgd.GetComponent<Renderer>();
        lCaudRend = lCaud.GetComponent<Renderer>();
        rCaudRend = rCaud.GetComponent<Renderer>();
        brainStemRend = brainstem.GetComponent<Renderer>();

        ECoG_Electrodes = GameObject.Find("Electrodes");
        SEEG_Electrodes = GameObject.Find("SEEG");


    }
    void Update()
    {
        lHemiRend.material.SetFloat("_Transparency", tranSlider1.value / 2f);
        rHemiRend.material.SetFloat("_Transparency", tranSlider2.value / 2f);
        rPutRend.material.SetFloat("_Transparency", tranSlider3.value / 2f);
        lPutRend.material.SetFloat("_Transparency", tranSlider3.value / 2f);
        rHipRend.material.SetFloat("_Transparency", tranSlider3.value / 2f);
        lHipRend.material.SetFloat("_Transparency", tranSlider3.value / 2f);
        rThalRend.material.SetFloat("_Transparency", tranSlider3.value / 2f);
        lThalRend.material.SetFloat("_Transparency", tranSlider3.value / 2f);
        rCaudRend.material.SetFloat("_Transparency", tranSlider3.value / 2f);
        lCaudRend.material.SetFloat("_Transparency", tranSlider3.value / 2f);
        rAmgdRend.material.SetFloat("_Transparency", tranSlider3.value / 2f);
        lAmgdRend.material.SetFloat("_Transparency", tranSlider3.value / 2f);
        brainStemRend.material.SetFloat("_Transparency", tranSlider3.value / 2f);

        if (tranSlider1.value == 1)
        {
            lHemiRend.material.shader = Shader.Find("Standard");
        }
        else
        {
            lHemiRend.material.shader = Shader.Find("Unlit/SpecialFX/Cool Hologram");
      
        }
        if (tranSlider2.value == 1)
        {
            rHemiRend.material.shader = Shader.Find("Standard");
        }
        else
        {
            rHemiRend.material.shader = Shader.Find("Unlit/SpecialFX/Cool Hologram");
        }

        if (tranSlider3.value == 1)
        {
            rPutRend.material.shader = Shader.Find("Standard");
            lPutRend.material.shader = Shader.Find("Standard");
            rHipRend.material.shader = Shader.Find("Standard");
            rHipRend.material.shader = Shader.Find("Standard");
            rThalRend.material.shader = Shader.Find("Standard");
            lThalRend.material.shader = Shader.Find("Standard");
            rCaudRend.material.shader = Shader.Find("Standard");
            lCaudRend.material.shader = Shader.Find("Standard");
            rAmgdRend.material.shader = Shader.Find("Standard");
            lAmgdRend.material.shader = Shader.Find("Standard");
            brainStemRend.material.shader = Shader.Find("Standard");
        }
        else
        {
            rPutRend.material.shader = Shader.Find("Unlit/SpecialFX/Cool Hologram");
            lPutRend.material.shader = Shader.Find("Unlit/SpecialFX/Cool Hologram");
            rHipRend.material.shader = Shader.Find("Unlit/SpecialFX/Cool Hologram");
            lHipRend.material.shader = Shader.Find("Unlit/SpecialFX/Cool Hologram");
            rThalRend.material.shader = Shader.Find("Unlit/SpecialFX/Cool Hologram");
            lThalRend.material.shader = Shader.Find("Unlit/SpecialFX/Cool Hologram");
            rCaudRend.material.shader = Shader.Find("Unlit/SpecialFX/Cool Hologram");
            lCaudRend.material.shader = Shader.Find("Unlit/SpecialFX/Cool Hologram");
            rAmgdRend.material.shader = Shader.Find("Unlit/SpecialFX/Cool Hologram");
            lAmgdRend.material.shader = Shader.Find("Unlit/SpecialFX/Cool Hologram");
            brainStemRend.material.shader = Shader.Find("Unlit/SpecialFX/Cool Hologram");
        }



        //if (xSlider.value == -.1376)
        //{
        //    clipPlaneX.SetActive(false);
        //}
        //else
        //{
        //    clipPlaneX.SetActive(true);
        //    clipPlaneX.transform.position = new Vector3(xSlider.value, clipPlaneX.transform.position.y, clipPlaneX.transform.position.z);
        //}
        //
        //if (ySlider.value == 0)
        //{
        //    clipPlaneY.SetActive(false);
        //}
        //else
        //{
        //    clipPlaneY.SetActive(true);
        //}
        //
        //if (zSlider.value == 0)
        //{
        //    clipPlaneZ.SetActive(false);
        //}
        //else
        //{
        //    clipPlaneZ.SetActive(true);
        //    clipPlaneZ.transform.position = new Vector3(0, .61f, zSlider.value);
        //
        //}

    }

    //public IEnumerator picture() {
    //    GameObject.Find("Menu").transform.localScale = new Vector3(0, 0, 0);
    //    GameObject.Find("elecScaleFactor").transform.localScale = new Vector3(0, 0, 0);
    //    GameObject.Find("screenshotBtn").transform.localScale = new Vector3(0, 0, 0);
    //    ScreenCapture.CaptureScreenshot("Image.png");
    //    yield return new WaitForSeconds(.1f);

    //    GameObject.Find("Menu").transform.localScale = new Vector3(3.060708f, 3.060708f, 3.060708f);
    //    GameObject.Find("screenshotBtn").transform.localScale = new Vector3(2.172367f, 2.172367f, 2.172367f);
    //    GameObject.Find("elecScaleFactor").transform.localScale = new Vector3(2.150506f, 1.907562f, 0.8358533f);
    //}

    //public void takeScreenshot()
    //{
    //    StartCoroutine(picture());
    //}

    public void toggleMeshorVol()
    {
        if (brainMesh.activeSelf)
        {
            GameObject.Find("Main Camera").GetComponent<RayMarching>().enabled = true;
            brainMesh.SetActive(false);
        }
        else
        {
            GameObject.Find("Main Camera").GetComponent<RayMarching>().enabled = false;
            brainMesh.SetActive(true);
        }
    }
    public void toggleButtons()
    {
        if (!structBut.activeSelf)
        {
            structBut.SetActive(true);
            transBut.SetActive(true);
            return;
        }
        else
        {
            structBut.SetActive(false);
            transBut.SetActive(false);
            return;
        }

    }
    public void toggleAll(bool state)
    {
        lHip.SetActive(state);
        rHip.SetActive(state);
        lPia.SetActive(state);
        rPia.SetActive(state);
        lPut.SetActive(state);
        rPut.SetActive(state);
        lThal.SetActive(state);
        rThal.SetActive(state);
        lCaud.SetActive(state);
        rCaud.SetActive(state);
        lamgd.SetActive(state);
        ramgd.SetActive(state);
        brainstem.SetActive(state);

    }
    public void togglePia()
    {
        if (!lPia.activeSelf)
        {
            lPia.SetActive(true);
            rPia.SetActive(true);
            return;
        }
        else
        {
            lPia.SetActive(false);
            rPia.SetActive(false);
            return;
        }
    }
    public void toggleThal()
    {
        if (!lThal.activeSelf)
        {
            lThal.SetActive(true);
            rThal.SetActive(true);
            return;
        }
        else
        {
            lThal.SetActive(false);
            rThal.SetActive(false);
            return;
        }
    }
    public void toggleHippo()
    {
        if (!lHip.activeSelf)
        {
            lHip.SetActive(true);
            rHip.SetActive(true);
            return;
        }
        else
        {
            lHip.SetActive(false);
            rHip.SetActive(false);
            return;
        }
    }
    public void togglePutamen()
    {
        if (!lPut.activeSelf)
        {
            lPut.SetActive(true);
            rPut.SetActive(true);
            return;
        }
        else
        {
            lPut.SetActive(false);
            rPut.SetActive(false);
            return;
        }
    }
    public void toggleCaudate()
    {
        if (!lCaud.activeSelf)
        {
            lCaud.SetActive(true);
            rCaud.SetActive(true);
            return;
        }
        else
        {
            lCaud.SetActive(false);
            rCaud.SetActive(false);
            return;
        }
    }
    public void toggleAmygdala()
    {
        if (!lamgd.activeSelf)
        {
            lamgd.SetActive(true);
            ramgd.SetActive(true);
            return;
        }
        else
        {
            lamgd.SetActive(false);
            ramgd.SetActive(false);
            return;
        }
    }
    public void toggleBrainstem()
    {
        if (!brainstem.activeSelf)
        {
            brainstem.SetActive(true);
            return;
        }
        else
        {
            brainstem.SetActive(false);
            return;
        }
    }
    public void toggleECoGElec()
    {

        if (!ECoG_Electrodes.activeSelf)
        {
            ECoG_Electrodes.SetActive(true);
            return;
        }
        else
        {
            ECoG_Electrodes.SetActive(false);
            return;
        }
    }
    public void toggleSEEGElec()
    {
        if (!SEEG_Electrodes.activeSelf)
        {
            SEEG_Electrodes.SetActive(true);
            return;
        }
        else
        {
            SEEG_Electrodes.SetActive(false);
            return;
        }
    }
}

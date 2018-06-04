using UnityEngine;
using System.Collections;
using System.IO;

public class LoadFromFileExample : MonoBehaviour
{
    void Start()
    {
        var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "resources.assetbundle"));
        print(myLoadedAssetBundle);
        if (myLoadedAssetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }

        var prefab = myLoadedAssetBundle.LoadAsset<GameObject>("gBrainPial.fbx");
        print(prefab);
        Instantiate(prefab);

        myLoadedAssetBundle.Unload(false);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using System.Text;
using System.IO;


public class LoadConfigs : MonoBehaviour {

    private string brainConfigFile;

    string brainToLoad;
 
    // Use this for initialization
    void Awake () {
//#if UNITY_WEBGL
//        brainConfigFile = Application.streamingAssetsPath + "/brainConfig.json";
//#elif UNITY_STANDALONE
//        brainConfigFile = Application.dataPath+"/brainConfig.json";
//#endif
        brainConfigFile = Application.streamingAssetsPath + "/brainConfig.json";
        Debug.Log(Application.streamingAssetsPath);
        //var brainConfigFile = Resources.Load("brainConfig") as String;

        if (brainConfigFile != null && File.Exists(brainConfigFile))
        {
            var tempStruct = JsonUtility.FromJson<brainSelections>(ReadFile(brainConfigFile));
            brainToLoad = tempStruct.brainToLoad;

            Debug.Log(brainToLoad);
            GameObject instance = Instantiate(Resources.Load(brainToLoad, typeof(GameObject))) as GameObject;

        }

    }


    // accessor function for the local IP address and port

    // return the entire string
    public string ReadFile(string filename)
    {
        StreamReader fileReader = new StreamReader(filename, Encoding.Default);
        string returnString;
        using (fileReader)
            returnString = fileReader.ReadToEnd();
        return returnString;
    }
}

[Serializable]
public class brainSelections
{
    public string brainToLoad;
    // We could also define other variables here.
}


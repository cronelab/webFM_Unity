using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;
public class materialManager : MonoBehaviour
{

    Component[] renderers;
    public Shader shader;
    Renderer rend;

    void Awake()
    {

        Renderer[] childRends = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in childRends)
        {
            rend.material = new Material(shader);
            rend.gameObject.AddComponent<mouseOver_name>();
        }
        string jsonString = File.ReadAllText("Assets/Scripts/materialColors.json");
        JSONNode data = JSON.Parse(jsonString);
        foreach (KeyValuePair<string, JSONNode> kvp in (JSONObject)data)
        {
            float r = kvp.Value.AsArray[0] / 255f;
            float g = kvp.Value.AsArray[1] / 255f;
            float b = kvp.Value.AsArray[2] / 255f;
            GameObject.Find(kvp.Key.ToString()).GetComponent<Renderer>().material.color = new Color(r, g, b);
        }
        GameObject[] gos = (GameObject[])FindObjectsOfType(typeof(GameObject));
        for (int i = 0; i < gos.Length; i++)
            if (gos[i].name.Contains("rh.") || gos[i].name.Contains("hh."))
                gos[i].tag = "gyri";
    }
    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
    }
    // Update is called once per frame
    void Update()
    {

    }
}


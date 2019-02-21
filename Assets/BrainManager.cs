using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainManager : MonoBehaviour
{
    public Material mPia;
    public Material mBrainstem;
    public Material mAmygdala;
    public Material mCaudate;
    public Material mHippocampus;
    public Material mThalamus;
    public Material mPutaman;
    public Material mWM;
    public Shader shader;

    // Start is called before the first frame update
    void Start()
    {
        //Set up everything coming out of Blender.
        GameObject brain = gameObject.transform.GetChild(0).gameObject;
        GameObject pia = brain.transform.GetChild(0).gameObject;
        GameObject gyri = brain.transform.GetChild(1).gameObject;
        GameObject whiteMatter = brain.transform.GetChild(2).gameObject;
        GameObject substructures = brain.transform.GetChild(3).gameObject;

        //Get the child renderers.
        Component[] pialRenderers = pia.transform.GetComponentsInChildren<Renderer>();
        Component[] gyriRenderers = gyri.transform.GetComponentsInChildren<Renderer>();
        Component[] subStructRenderers = substructures.transform.GetComponentsInChildren<Renderer>();
        Component[] wmRenderers = whiteMatter.transform.GetComponentsInChildren<Renderer>();

        //Set Pia materials.
        foreach (Renderer rends in pialRenderers)
        {
            rends.material = mPia;
        }
        //Set the hologram shader and random colors for the Gyri.
        foreach (Renderer rends in gyriRenderers)
        {
            rends.material = new Material(shader);
            rends.material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));

        }
        //Disable the Gyri.
        gyri.SetActive(false);

        //Set the material for each of the substructures.
        foreach (Renderer rends in subStructRenderers)
        {
            if(rends.gameObject.name == "brainstem")
            {
                rends.material = mBrainstem;
            }
            else if (rends.gameObject.name == "lAmgd" || rends.gameObject.name == "rAmgd")
            {
                rends.material = mAmygdala;
            }
            else if (rends.gameObject.name == "lCaud" || rends.gameObject.name == "rCaud")
            {
                rends.material = mCaudate;
            }
            else if (rends.gameObject.name == "lHipp" || rends.gameObject.name == "rHipp")
            {
                rends.material = mHippocampus;
            }
            else if (rends.gameObject.name == "lThal" || rends.gameObject.name == "rThal")
            {
                rends.material = mThalamus;
            }
            else if (rends.gameObject.name == "lPut" || rends.gameObject.name == "rPut")
            {
                rends.material = mPutaman;
            }
        }
        foreach (Renderer rends in wmRenderers)
        {
            rends.material = mWM;


        }
        //Disable the WM.
        whiteMatter.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

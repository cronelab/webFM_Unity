using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class materialManager : MonoBehaviour
{

    Component[] renderers;
    public Shader shader;
Renderer rend;
    void Start()
    {
    //     renderers = GetComponentsInChildren(typeof(Renderer));
    //  foreach(Renderer rend in renderers)
    //     {
    //         rend.material = new Material(shader);

    //         rend.material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
    //     }        
        GameObject.Find("Left-Cerebral-White-Matter").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("Left-Cerebral-White-Matter").GetComponent<Renderer>().material.color = new Color(245/255f,245/255f,245/255f);
        GameObject.Find("Left-Cerebral-Cortex").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("Left-Cerebral-Cortex").GetComponent<Renderer>().material.color = new Color(205/255f,62/255f,78/255f);
        GameObject.Find("Left-Lateral-Ventricle").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("Left-Lateral-Ventricle").GetComponent<Renderer>().material.color = new Color(120/255f,18/255f,134/255f);
        GameObject.Find("Left-Inf-Lat-Vent").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("Left-Inf-Lat-Vent").GetComponent<Renderer>().material.color = new Color(196/255f,58/255f,250/255f);
        GameObject.Find("Left-Cerebellum-White-Matter").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("Left-Cerebellum-White-Matter").GetComponent<Renderer>().material.color = new Color(220/255f,248/255f,164/255f);
        GameObject.Find("Left-Cerebellum-Cortex").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("Left-Cerebellum-Cortex").GetComponent<Renderer>().material.color = new Color(230/255f,148/255f,34/255f);
        GameObject.Find("Left-Thalamus-Proper").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("Left-Thalamus-Proper").GetComponent<Renderer>().material.color = new Color(0/255f,118/255f,14/255f);
        GameObject.Find("Left-Caudate").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("Left-Caudate").GetComponent<Renderer>().material.color = new Color(122/255f,186/255f,220/255f);
        GameObject.Find("Left-Putamen").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("Left-Putamen").GetComponent<Renderer>().material.color = new Color(236/255f,13/255f,176/255f);
        GameObject.Find("Left-Pallidum").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("Left-Pallidum").GetComponent<Renderer>().material.color = new Color(12/255f,48/255f,255/255f);
        GameObject.Find("3rd-Ventricle").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("3rd-Ventricle").GetComponent<Renderer>().material.color = new Color(204/255f,182/255f,142/255f);
        GameObject.Find("4th-Ventricle").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("4th-Ventricle").GetComponent<Renderer>().material.color = new Color(42/255f,204/255f,164/255f);
        GameObject.Find("Brain-Stem").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("Brain-Stem").GetComponent<Renderer>().material.color = new Color(119/255f,159/255f,176/255f);
        GameObject.Find("Left-Hippocampus").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("Left-Hippocampus").GetComponent<Renderer>().material.color = new Color(220/255f,216/255f,20/255f);
        GameObject.Find("Left-Amygdala").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("Left-Amygdala").GetComponent<Renderer>().material.color = new Color(103/255f,255/255f,255/255f);
        GameObject.Find("CSF").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("CSF").GetComponent<Renderer>().material.color = new Color(60/255f,60/255f,60/255f);
        GameObject.Find("Left-Accumbens-area").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("Left-Accumbens-area").GetComponent<Renderer>().material.color = new Color(255/255f,  165/255f,   0/255f);
        GameObject.Find("Left-VentralDC").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("Left-VentralDC").GetComponent<Renderer>().material.color = new Color(165/255f,   42/255f,  42/255f);
        GameObject.Find("Left-vessel").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("Left-vessel").GetComponent<Renderer>().material.color = new Color(160/255f,   32/255f, 240/255f);
        GameObject.Find("Left-choroid-plexus").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("Left-choroid-plexus").GetComponent<Renderer>().material.color = new Color(  0/255f,  200/255f, 200/255f);
        GameObject.Find("Right-Cerebral-White-Matter").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("Right-Cerebral-White-Matter").GetComponent<Renderer>().material.color = new Color(245/255f,  245/255f, 245/255f);
        GameObject.Find("Right-Cerebral-Cortex").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("Right-Cerebral-Cortex").GetComponent<Renderer>().material.color = new Color(205/255f,   62/255f,  78/255f);
        GameObject.Find("Right-Lateral-Ventricle").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("Right-Lateral-Ventricle").GetComponent<Renderer>().material.color = new Color(120/255f,   18/255f, 134/255f);
        GameObject.Find("Right-Inf-Lat-Vent").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("Right-Inf-Lat-Vent").GetComponent<Renderer>().material.color = new Color(196/255f,   58/255f, 250/255f);
        GameObject.Find("Right-Cerebellum-White-Matter").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("Right-Cerebellum-White-Matter").GetComponent<Renderer>().material.color = new Color(220/255f,  248/255f, 164/255f);
        GameObject.Find("Right-Cerebellum-Cortex").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("Right-Cerebellum-Cortex").GetComponent<Renderer>().material.color = new Color(230/255f,  148/255f,  34/255f);
        GameObject.Find("Right-Thalamus-Proper").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("Right-Thalamus-Proper").GetComponent<Renderer>().material.color = new Color(  0/255f,  118/255f,  14/255f);
        GameObject.Find("Right-Caudate").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("Right-Caudate").GetComponent<Renderer>().material.color = new Color(122/255f,  186/255f, 220/255f);
        GameObject.Find("Right-Putamen").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("Right-Putamen").GetComponent<Renderer>().material.color = new Color(236/255f,   13/255f, 176/255f);
        GameObject.Find("Right-Pallidum").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("Right-Pallidum").GetComponent<Renderer>().material.color = new Color( 13/255f,   48/255f, 255/255f);
        GameObject.Find("Right-Hippocampus").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("Right-Hippocampus").GetComponent<Renderer>().material.color = new Color(220/255f,  216/255f,  20/255f);
        GameObject.Find("Right-Amygdala").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("Right-Amygdala").GetComponent<Renderer>().material.color = new Color(103/255f,  255/255f, 255/255f);
        GameObject.Find("Right-Accumbens-area").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("Right-Accumbens-area").GetComponent<Renderer>().material.color = new Color(255/255f,  165/255f,   0/255f);
        GameObject.Find("Right-VentralDC").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("Right-VentralDC").GetComponent<Renderer>().material.color = new Color(165/255f,   42/255f,  42/255f);
        // GameObject.Find("Right-vessel").GetComponent<Renderer>().material = new Material(shader);
        // GameObject.Find("Right-vessel").GetComponent<Renderer>().material.color = new Color(160/255f,   32/255f, 240/255f);
        GameObject.Find("Right-choroid-plexus").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("Right-choroid-plexus").GetComponent<Renderer>().material.color = new Color(  0/255f,   20/255f, 221/255f);
        // GameObject.Find("5th-Ventricle").GetComponent<Renderer>().material = new Material(shader);
        // GameObject.Find("5th-Ventricle").GetComponent<Renderer>().material.color = new Color(120/255f,  190/255f, 150/255f);
        GameObject.Find("WM-hypointensities").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("WM-hypointensities").GetComponent<Renderer>().material.color = new Color(200/255f,   70/255f, 255/255f);
        // GameObject.Find("Left-WM-hypointensities").GetComponent<Renderer>().material = new Material(shader);
        // GameObject.Find("Left-WM-hypointensities").GetComponent<Renderer>().material.color = new Color(255/255f,  148/255f,  10/255f);
        // GameObject.Find("Right-WM-hypointensities").GetComponent<Renderer>().material = new Material(shader);
        // GameObject.Find("Right-WM-hypointensities").GetComponent<Renderer>().material.color = new Color(255/255f,  148/255f,  10/255f);
        // GameObject.Find("non-WM-hypointensities").GetComponent<Renderer>().material = new Material(shader);
        // GameObject.Find("non-WM-hypointensities").GetComponent<Renderer>().material.color = new Color(164/255f,  108/255f, 226/255f);
        // GameObject.Find("Left-non-WM-hypointensities").GetComponent<Renderer>().material = new Material(shader);
        // GameObject.Find("Left-non-WM-hypointensities").GetComponent<Renderer>().material.color = new Color(164/255f,  108/255f, 226/255f);
        // GameObject.Find("Right-non-WM-hypointensities").GetComponent<Renderer>().material = new Material(shader);
        // GameObject.Find("Right-non-WM-hypointensities").GetComponent<Renderer>().material.color = new Color(164/255f,  108/255f, 226/255f);
        GameObject.Find("Optic-Chiasm").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("Optic-Chiasm").GetComponent<Renderer>().material.color = new Color(234/255f,  169/255f,  30/255f);
        GameObject.Find("CC_Posterior").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("CC_Posterior").GetComponent<Renderer>().material.color = new Color(  0/255f,    0/255f,  64/255f);
        GameObject.Find("CC_Mid_Posterior").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("CC_Mid_Posterior").GetComponent<Renderer>().material.color = new Color(  0/255f,    0/255f, 112/255f);
        GameObject.Find("CC_Central" ).GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("CC_Central" ).GetComponent<Renderer>().material.color = new Color(  0/255f,    0/255f, 160/255f);
        GameObject.Find("CC_Mid_Anterior").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("CC_Mid_Anterior").GetComponent<Renderer>().material.color = new Color(  0/255f,    0/255f, 208/255f);
        GameObject.Find("CC_Anterior").GetComponent<Renderer>().material = new Material(shader);
        GameObject.Find("CC_Anterior").GetComponent<Renderer>().material.color = new Color(  0/255f,    0/255f, 255/255f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

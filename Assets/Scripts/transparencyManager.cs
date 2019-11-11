using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class transparencyManager : MonoBehaviour
{
    private Slider cerebralCortexSlider, cerebralWMSlider;
    private GameObject[] cerebralCortex;
    private GameObject[] cerebralWM;
    // Start is called before the first frame update
    void Start()
    {
        cerebralCortexSlider = GameObject.Find("cerebralCortexSlider").GetComponent<Slider>();
        cerebralWMSlider = GameObject.Find("cerebralWMSlider").GetComponent<Slider>();
        cerebralCortex = new GameObject[2];
        cerebralCortex[0] = GameObject.Find("Right-Cerebral-Cortex");
        cerebralCortex[1] = GameObject.Find("Left-Cerebral-Cortex");
        cerebralWM = new GameObject[2];
        cerebralWM[0] = GameObject.Find("Right-Cerebral-White-Matter");
        cerebralWM[1] = GameObject.Find("Left-Cerebral-White-Matter");
    }

    // Update is called once per frame
    void Update()
    {
        cerebralCortex[0].GetComponent<Renderer>().material.SetFloat("_Transparency", cerebralCortexSlider.value);
        cerebralCortex[1].GetComponent<Renderer>().material.SetFloat("_Transparency", cerebralCortexSlider.value);
        cerebralCortex[0].GetComponent<Renderer>().material.SetFloat("_Transparency", cerebralCortexSlider.value);
        cerebralCortex[1].GetComponent<Renderer>().material.SetFloat("_Transparency", cerebralCortexSlider.value);
        cerebralWM[0].GetComponent<Renderer>().material.SetFloat("_Transparency", cerebralWMSlider.value);
        cerebralWM[1].GetComponent<Renderer>().material.SetFloat("_Transparency", cerebralWMSlider.value);
        if(cerebralCortexSlider.value==0){
            cerebralCortex[0].GetComponent<MeshRenderer>().enabled =false;
            cerebralCortex[1].GetComponent<MeshRenderer>().enabled =false;
        }
        else{
            cerebralCortex[0].GetComponent<MeshRenderer>().enabled =true;
            cerebralCortex[1].GetComponent<MeshRenderer>().enabled =true;
        }
    }
}

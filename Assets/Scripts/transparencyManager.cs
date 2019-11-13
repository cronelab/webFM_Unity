using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class transparencyManager : MonoBehaviour
{
    private Slider cerebralCortexSlider, cerebralWMSlider, gyriSlider;
    private GameObject[] cerebralCortex;
    private GameObject[] cerebralWM;
    GameObject[] gyri;
    // Start is called before the first frame update
    void Start()
    {
        cerebralCortexSlider = GameObject.Find("cerebralCortexSlider").GetComponent<Slider>();
        cerebralWMSlider = GameObject.Find("cerebralWMSlider").GetComponent<Slider>();
        gyriSlider = GameObject.Find("gyriSlider").GetComponent<Slider>();
        cerebralCortex = new GameObject[2];
        cerebralCortex[0] = GameObject.Find("Right-Cerebral-Cortex");
        cerebralCortex[1] = GameObject.Find("Left-Cerebral-Cortex");
        cerebralWM = new GameObject[2];
        cerebralWM[0] = GameObject.Find("Right-Cerebral-White-Matter");
        cerebralWM[1] = GameObject.Find("Left-Cerebral-White-Matter");
        gyri = GameObject.FindGameObjectsWithTag("gyri");

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

        foreach (GameObject gyrus in gyri)
        {
            gyrus.GetComponent<Renderer>().material.SetFloat("_Transparency", gyriSlider.value);
        }
        if (gyriSlider.value == 0)
        {
            cerebralCortex[0].SetActive(true);
            cerebralCortex[1].SetActive(true);
            foreach (GameObject gyrus in gyri)
            {
                gyrus.SetActive(false);
            }
        }
        else
        {
            cerebralCortex[0].SetActive(false);
            cerebralCortex[1].SetActive(false);
            foreach (GameObject gyrus in gyri)
            {
                gyrus.SetActive(true);
            }
        }

        if (cerebralCortexSlider.value == 0)
        {
            cerebralCortex[0].SetActive(false);
            cerebralCortex[1].SetActive(false);
        }
        else if (cerebralCortexSlider.value != 0 && gyriSlider.value == 0)
        {
            cerebralCortex[0].SetActive(true);
            cerebralCortex[1].SetActive(true);
        }

        if (cerebralWMSlider.value == 0)
        {
            cerebralWM[0].SetActive(false);
            cerebralWM[1].SetActive(false);
        }
        else
        {
            cerebralWM[0].SetActive(true);
            cerebralWM[1].SetActive(true);
        }
    }
}

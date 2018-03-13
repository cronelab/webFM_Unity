using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIElements : MonoBehaviour {

    private GameObject lPia, rPia;
    private GameObject lHip, rHip;
    private GameObject lThal, rThal;
    private GameObject ECoG_Electrodes;
    private GameObject SEEG_Electrodes;
    private GameObject structBut, transBut;


    private Renderer lHemiRend, rHemiRend;

    private Slider tranSlider1, tranSlider2;

    private Vector3 screenPoint;
    private Vector3 offset;

    private void Start()
    {
        lPia = GameObject.Find("lpia");
        rPia = GameObject.Find("rpia");
        lHip = GameObject.Find("lhip");
        rHip = GameObject.Find("rhip");
        lThal = GameObject.Find("lthal");
        rThal = GameObject.Find("rthal");
        tranSlider1 = GameObject.Find("Slider1").GetComponent<Slider>();
        tranSlider2 = GameObject.Find("Slider2").GetComponent<Slider>();

        structBut = GameObject.Find("StructureToggle");
        transBut = GameObject.Find("Transparency");
        structBut.SetActive(false);
        transBut.SetActive(false);
        lHemiRend = lPia.GetComponent<Renderer>();
        rHemiRend = rPia.GetComponent<Renderer>();
        ECoG_Electrodes = GameObject.Find("LTG");
        SEEG_Electrodes = GameObject.Find("SEEG");
    }

    void Update()
    {
        lHemiRend.material.SetFloat("_Transparency", tranSlider1.value / 2.5f);
        rHemiRend.material.SetFloat("_Transparency", tranSlider2.value / 2.5f);

        if (tranSlider1.value == 0)
        {
            lHemiRend.material.shader = Shader.Find("Standard");
        }
        else
        {
            lHemiRend.material.shader = Shader.Find("Unlit/Transparent");
        }
        if (tranSlider2.value == 0)
        {
            rHemiRend.material.shader = Shader.Find("Standard");
        }
        else
        {
            rHemiRend.material.shader = Shader.Find("Unlit/Transparent");
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

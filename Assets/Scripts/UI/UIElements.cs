using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIElements : MonoBehaviour {

    private GameObject lPia, rPia;
    private GameObject lHip, rHip;
    private GameObject lThal, rThal;
    private GameObject brainstem, gyri;
    private GameObject lPut, rPut;
    private GameObject lAmgd, rAmgd;
    private GameObject lCaud, rCaud;
    private GameObject brainMesh, WM;
    public GameObject ECoG_Electrodes, SEEG_Electrodes;
    private GameObject structBut, transBut;

    private Renderer lHemiRend, rHemiRend,lPutRend,rPutRend,lHipRend,rHipRend,lThalRend,rThalRend,lAmgdRend,rAmgdRend,
        lCaudRend,rCaudRend, brainStemRend;
    private Renderer[] wmRend;
    public Slider tranSlider1, tranSlider2, tranSlider3, electrodeScaler, gyriScaler, wmScaler;



    private Vector3 screenPoint;
    private Vector3 offset;

    private GameObject clipPlaneX, clipPlaneY, clipPlaneZ;



    public void Awake()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
            WebGLInput.captureAllKeyboardInput = false;
#endif
    }
    private void Start()
    {
        lPia = GameObject.Find("lPia");
        rPia = GameObject.Find("rPia");
        lPut = GameObject.Find("lPut");
        rPut = GameObject.Find("rPut");
        lHip = GameObject.Find("lHipp");
        rHip = GameObject.Find("rHipp");
        lThal = GameObject.Find("lThal");
        rThal = GameObject.Find("rThal");
        lAmgd = GameObject.Find("lAmgd");
        rAmgd = GameObject.Find("rAmgd");
        lCaud = GameObject.Find("lCaud");
        rCaud = GameObject.Find("rCaud");
        brainstem = GameObject.Find("brainstem");
        gyri = GameObject.Find("Gyri");
        WM = GameObject.Find("White_matter");

        lHemiRend = lPia.GetComponent<Renderer>();
        rHemiRend = rPia.GetComponent<Renderer>();
        rPutRend = rPut.GetComponent<Renderer>();
        lPutRend = lPut.GetComponent<Renderer>();
        rHipRend = rHip.GetComponent<Renderer>();
        lHipRend = lHip.GetComponent<Renderer>();
        lThalRend = lThal.GetComponent<Renderer>();
        rThalRend = rThal.GetComponent<Renderer>();
        lAmgdRend = lAmgd.GetComponent<Renderer>();
        rAmgdRend = rAmgd.GetComponent<Renderer>();
        lCaudRend = lCaud.GetComponent<Renderer>();
        rCaudRend = rCaud.GetComponent<Renderer>();
        brainStemRend = brainstem.GetComponent<Renderer>();
        wmRend = WM.GetComponentsInChildren<Renderer>();

        ECoG_Electrodes = GameObject.Find("ECoG");
        SEEG_Electrodes = GameObject.Find("SEEG");
        tranSlider1 = GameObject.Find("lPiaSlider").GetComponent<Slider>();
        tranSlider2 = GameObject.Find("rPiaSlider").GetComponent<Slider>();
        tranSlider3 = GameObject.Find("subStructSlider").GetComponent<Slider>();
        electrodeScaler = GameObject.Find("elecScaleFactor").GetComponent<Slider>();
        gyriScaler = GameObject.Find("gyriScaleFactor").GetComponent<Slider>();
        wmScaler = GameObject.Find("wmScaleFactor").GetComponent<Slider>();
        structBut = GameObject.Find("Toggles");
        transBut = GameObject.Find("Sliders");
        structBut.SetActive(false);
        transBut.SetActive(false);
        brainMesh = GameObject.Find("Manager").transform.GetChild(0).gameObject;

        brainMesh.SetActive(true);

    }
 
    void Update()
    {
        lHemiRend.material.SetFloat("_Transparency", tranSlider1.value);
        rHemiRend.material.SetFloat("_Transparency", tranSlider2.value);
        rPutRend.material.SetFloat("_Transparency", tranSlider3.value);
        lPutRend.material.SetFloat("_Transparency", tranSlider3.value);
        rHipRend.material.SetFloat("_Transparency", tranSlider3.value);
        lHipRend.material.SetFloat("_Transparency", tranSlider3.value);
        rThalRend.material.SetFloat("_Transparency", tranSlider3.value);
        lThalRend.material.SetFloat("_Transparency", tranSlider3.value);
        rCaudRend.material.SetFloat("_Transparency", tranSlider3.value);
        lCaudRend.material.SetFloat("_Transparency", tranSlider3.value);
        rAmgdRend.material.SetFloat("_Transparency", tranSlider3.value);
        lAmgdRend.material.SetFloat("_Transparency", tranSlider3.value);
        brainStemRend.material.SetFloat("_Transparency", tranSlider3.value);
        foreach(Renderer rends in wmRend)
        {
            rends.material.SetFloat("_Transparency", wmScaler.value);

        }


        Component[] renderers;

        renderers = gyri.GetComponentsInChildren(typeof(Renderer));

        //   Renderer rend = GetComponent<Renderer>();
        foreach (Renderer rend in renderers)
        {
            rend.material.SetFloat("_Transparency", gyriScaler.value);
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
        lAmgd.SetActive(state);
        rAmgd.SetActive(state);
        brainstem.SetActive(state);

    }

    public void toggleWM()
    {
       if (WM.activeSelf)
        {
            //var electrodes = GameObject.FindGameObjectsWithTag("Electrodes");
            //foreach (GameObject elec in electrodes)
            //{
            //    elec.GetComponent<isTouchingCollider>().enabled = true;
            //}
            WM.SetActive(false);
        }
        else
        {
            //var electrodes = GameObject.FindGameObjectsWithTag("Electrodes");
            //foreach (GameObject elec in electrodes)
            //{
            //    elec.GetComponent<isTouchingCollider>().enabled = false;
            //    elec.GetComponent<Renderer>().material.color = Color.black;
            //}
            WM.SetActive(true);
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
    public void toggleGyri()
    {
        if (!gyri.activeSelf)
        {
            gyri.SetActive(true);
            return;
        }
        else
        {
            gyri.SetActive(false);
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
        if (!lAmgd.activeSelf)
        {
            lAmgd.SetActive(true);
            rAmgd.SetActive(true);
            return;
        }
        else
        {
            lAmgd.SetActive(false);
            rAmgd.SetActive(false);
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
            SEEG_Electrodes.SetActive(true);

            return;
        }
        else
        {
            ECoG_Electrodes.SetActive(false);
            SEEG_Electrodes.SetActive(false);

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

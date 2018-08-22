using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeElecColors : MonoBehaviour {

    [SerializeField]
    private Gradient elecGradient;
    private Vector3 elecSize;
    public static bool viz = true;

    private void Start()
    {
        elecSize = gameObject.transform.localScale;
    }

    public void switchViz()
    {
        viz = !viz;
    }


    public void activityChanger(float valFromBrowser)
    {
        //Yo, super inelegant, but most vals are between -.5 and .5, not 0 and 1.
        Color colorGrad = elecGradient.Evaluate(valFromBrowser + .5f);
        transform.GetComponent<Renderer>().material.color = new Color(colorGrad.r, colorGrad.g, colorGrad.b);

        float elecSliderVal = Mathf.Abs(GameObject.Find("Canvas").GetComponent<UIElements>().electrodeScaler.value);
        if (valFromBrowser != 0)
        {
            if (gameObject.transform.parent.parent.name == "SEEG")
            {
                transform.localScale = new Vector3(elecSize.x + (float)System.Math.Sqrt(Mathf.Abs(valFromBrowser)) * elecSliderVal, elecSize.y, elecSize.z + (float)System.Math.Sqrt(Mathf.Abs(valFromBrowser)) * elecSliderVal);
            }
            else if (gameObject.transform.parent.parent.name == "ECoG")
            {
                transform.localScale = new Vector3(elecSize.x + (float)System.Math.Sqrt(Mathf.Abs(valFromBrowser)) * elecSliderVal, elecSize.y + (float)System.Math.Sqrt(Mathf.Abs(valFromBrowser)) * elecSliderVal, elecSize.z + (float)System.Math.Sqrt(Mathf.Abs(valFromBrowser)) * elecSliderVal);
            }
        }
        else if(valFromBrowser==0)
        {

            if (viz == false)
            {
                transform.localScale = new Vector3(0,0,0);
            }
            else
            {
                transform.localScale = elecSize;
                transform.GetComponent<Renderer>().material.color = Color.black;
            }
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeElecColors : MonoBehaviour {

    [SerializeField]
    private Gradient red;
    [SerializeField]
    private Gradient blue;
    [SerializeField]
    private float elecSize = 4.2f;
    private Slider scaler;

    private void Start()
    {
        scaler = GameObject.Find("elecScaleFactor").GetComponent<Slider>();
    }

    public void activityChanger(float valFromBrowser)
    {
        if (valFromBrowser > 0)
        {

            Color redGrad = red.Evaluate(valFromBrowser);
            transform.GetComponent<Renderer>().material.color = new Color(redGrad.r, redGrad.g, redGrad.b);

            //PLAY WITH TRAnsparacy shader. Right now only useful at the boundaries (0 vs 1).
            //Change UI, make it look more professional

            transform.localScale = new Vector3(elecSize + (float)System.Math.Sqrt(valFromBrowser) * scaler.value, elecSize + (float)System.Math.Sqrt(valFromBrowser) * scaler.value, elecSize + (float)System.Math.Sqrt(valFromBrowser) * scaler.value);
        }
        else if (valFromBrowser < 0)
        {
            Color blueGrad = blue.Evaluate(valFromBrowser * -1);
            transform.GetComponent<Renderer>().material.color = new Color(blueGrad.r, blueGrad.g, blueGrad.b);
            transform.localScale = new Vector3(elecSize + (float)System.Math.Sqrt(valFromBrowser * -1) * scaler.value, elecSize + (float)System.Math.Sqrt(valFromBrowser * -1) * scaler.value, elecSize + (float)System.Math.Sqrt(valFromBrowser * -1) * scaler.value);
        }
        else {
            transform.GetComponent<Renderer>().material.color = Color.black;
            //transform.localScale = new Vector3(4.6f, 4.6f, 4.6f);
            transform.localScale = new Vector3(0, 0, 0);

        }
    }
}

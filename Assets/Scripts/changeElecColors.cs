using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeElecColors : MonoBehaviour {

    public Gradient red;
    public Gradient blue;

    public void testFunction(float valFromBrowser)
    {
        if (valFromBrowser > 0)
        {
            Color redGrad = red.Evaluate(valFromBrowser);
            transform.GetComponent<Renderer>().material.color = new Color(redGrad.r, redGrad.g, redGrad.b);
        }
        else
        {
            Color blueGrad = blue.Evaluate(valFromBrowser);
            transform.GetComponent<Renderer>().material.color = new Color(blueGrad.r, blueGrad.g, blueGrad.b);

        }
    }
}

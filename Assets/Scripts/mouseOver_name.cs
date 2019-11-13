using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseOver_name : MonoBehaviour
{
    private static Color activeColor;
    private bool doOnce = true;
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnMouseOver()
    {
        if (doOnce)
        //If your mouse hovers over the GameObject with the script attached, output this message
        {
            Debug.Log("Mouse is over: " + gameObject.transform.name);
            activeColor = gameObject.GetComponent<Renderer>().material.color;
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            doOnce = false;
        }

    }
    void OnMouseExit()
    {
        gameObject.GetComponent<Renderer>().material.color = activeColor;
        doOnce = true;

    }
    // Update is called once per frame
    void Update()
    {
    }
}

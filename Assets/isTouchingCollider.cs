using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isTouchingCollider : MonoBehaviour {

    private bool startDetection = false;

    private void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.white;
        startDetection = true;

    }

    void OnCollisionEnter(Collision collision)
    {
        if (startDetection)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(.93f, .92f, 0);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (startDetection)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }


}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isTouchingCollider : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "rh_white" || collision.transform.name == "lh_white")
        {
            Debug.Log(gameObject.transform.name);
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}


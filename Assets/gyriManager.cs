using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gyriManager : MonoBehaviour {

    public Shader shader;
    private Renderer[] renderers;

    void Start()
    {
        Component[] renderers;

        renderers = GetComponentsInChildren(typeof(Renderer));

     //   Renderer rend = GetComponent<Renderer>();
     foreach(Renderer rend in renderers)
        {
            rend.material = new Material(shader);
            rend.material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            print(rend.material.color);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}

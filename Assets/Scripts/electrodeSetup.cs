using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electrodeSetup : MonoBehaviour {

    // Use this for initialization
    private GameObject sphere;
    public float scalingFactor;
    public Gradient ElecGradient;

    void Start () {

        var electrodeType = gameObject.transform.GetChild(0);
        var numElectrodeGroups = electrodeType.childCount;

        for(int j = 0; j<numElectrodeGroups; j++)
        {
            var electrodeGroup = electrodeType.GetChild(j);

            int numElectrodesInGroup = electrodeGroup.childCount;
            for (int i = 0; i < numElectrodesInGroup; i++)
            {

                var elecCollider = electrodeGroup.GetChild(i).GetComponent<Collider>();
                Destroy(electrodeGroup.GetChild(i).gameObject);
                sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.SetParent(electrodeType.GetChild(j).transform);
                sphere.transform.position = elecCollider.bounds.center;
                sphere.transform.localScale = new Vector3(scalingFactor, scalingFactor, scalingFactor);
                sphere.AddComponent<changeElecColors>();
                sphere.GetComponent<changeElecColors>().elecGradient = ElecGradient;
                sphere.name = electrodeGroup.name + (i+1);
                sphere.AddComponent<isTouchingCollider>();
                sphere.GetComponent<isTouchingCollider>().enabled = false;
                sphere.AddComponent<Rigidbody>();
                sphere.GetComponent<SphereCollider>().radius = .34f;
                sphere.tag = "Electrodes";
                Rigidbody rb = sphere.GetComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.FreezeAll;
                sphere.GetComponent<Renderer>().material.color = Color.black;

            }
        }
    }
}

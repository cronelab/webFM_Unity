using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;
using UnityEngine.UI;

public class electrodeSetup : MonoBehaviour {


    //NEED TO ADDRESS MULTIPLE LINE RENDERERS on electrodes
    //Not an issue if you only plot one stimulating channel at a time.





    // Use this for initialization
    private GameObject sphere;
    public float scalingFactor;
    public Gradient ElecGradient;
    private Vector3 stimulationCoords;
    public Material lineColor10;
    public Material lineColor6;
    public Material lineColor8;
    public int stimToLookAt = 0;
    private int m_stimToLookAt = 0;
    public string[,] stimulatingElecs;
    public Transform electrodeType;
    public int numElectrodeGroups;
    public JSONNode importedJSON;

    public GameObject stimElec1, stimElec2;
    public GameObject slider;

    public Text stimPair;
    public string patient;

    void Start () {
        
        electrodeType = gameObject.transform.GetChild(0);
        numElectrodeGroups = electrodeType.childCount;

        for (int j = 0; j < numElectrodeGroups; j++)
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
                sphere.name = electrodeGroup.name + (i + 1);
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

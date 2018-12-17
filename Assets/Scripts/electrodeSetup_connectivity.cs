using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;
using UnityEngine.UI;

public class electrodeSetup_connectivity : MonoBehaviour {


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
        const int numStimPairs = 23;

        // Build in something that parses data from the StreamingAssets folder to automate the stimulatingElecs array!

        patient = "PY18N015";

        stimulatingElecs = new string[numStimPairs, 2] {
            { "LA1", "LA2" }, { "LA2", "LA3" }, {"LA8","LA9" }, {"LA9","LA10" }, { "LF1", "LF2" }, { "LF9", "LF10" }, {"LH3","LH4" },
            { "LH8", "LH9" }, { "LOF1", "LOF2" }, {"LOF6","LOF7" }, { "LOF8", "LOF9" }, { "LOF10", "LOF11" }, {"LOF13","LOF14" },
            { "RA1", "RA2" }, { "RA3", "RA4" }, {"RF8","RF9" }, { "RF9", "RF10" }, { "RH3", "RH4" }, {"RH8","RH10" },
            { "ROF1", "ROF2" }, { "ROF5", "ROF6" }, {"ROF11","ROF12" }, { "ROF13", "ROF14" } };

        OnVariableChange += VariableChangeHandler;
        print(stimulatingElecs[0, 0]);

        string zscore_data = File.ReadAllText(Application.streamingAssetsPath + "/" + patient + "/Zscores/"+ patient +"_" + stimulatingElecs[m_stimToLookAt, 0] + "_" + stimulatingElecs[m_stimToLookAt, 1] + ".json");
        //string zscore_data = File.ReadAllText(Application.streamingAssetsPath + "/Zscores/PY18N015_" + "LA1" + "_" + "LA2" + ".json");

        importedJSON = JSON.Parse(zscore_data);
        print(importedJSON);

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

        //stimElec1 = GameObject.Find("LA1");
        //stimElec2 = GameObject.Find("LA2");
        stimElec1 = GameObject.Find(stimulatingElecs[m_stimToLookAt, 0]);
        stimElec2 = GameObject.Find(stimulatingElecs[m_stimToLookAt, 1]);
        stimElec1.GetComponent<Renderer>().material.color = Color.red;
        stimElec2.GetComponent<Renderer>().material.color = Color.red;
        stimulationCoords = (stimElec1.transform.position + stimElec2.transform.position)/ 2;

        for (int j = 0; j < numElectrodeGroups; j++)
        {
            var electrodeGroup = electrodeType.GetChild(j);
            int numElectrodesInGroup = electrodeGroup.childCount;
            for (int i = 0; i < numElectrodesInGroup/2; i++)
            {
                sphere = GameObject.Find(electrodeGroup.name + (i + 1));
                if (importedJSON[electrodeGroup.name + (i + 1)][1] < 8 && importedJSON[electrodeGroup.name + (i + 1)][1] > 6)
                {
                    LineRenderer line = sphere.AddComponent<LineRenderer>();
                    line.SetPosition(0, stimulationCoords);
                    line.SetPosition(1, sphere.transform.position);
                    line.material = lineColor6;
                    line.startWidth = .4f;
                    line.endWidth = .4f;
                }
                //                if (importedJSON[electrodeGroup.name + (i + 1)][1] != null)
                if (importedJSON[electrodeGroup.name + (i + 1)][1] < 10 && importedJSON[electrodeGroup.name + (i + 1)][1] > 8)
                {
                    LineRenderer line = sphere.AddComponent<LineRenderer>();
                    line.SetPosition(0, stimulationCoords);
                    line.SetPosition(1, sphere.transform.position);
                    line.material = lineColor8;
                    line.startWidth = .5f;
                    line.endWidth = .5f;
                }

                if (importedJSON[electrodeGroup.name + (i + 1)][1] > 10)
                {
                    LineRenderer line = sphere.AddComponent<LineRenderer>();
                    line.SetPosition(0, stimulationCoords);
                    line.SetPosition(1, sphere.transform.position);
                    line.material = lineColor10;
                    line.startWidth = .6f;
                    line.endWidth = .6f;
                }
            }
        }
    }
    public delegate void OnVariableChangeDelegate(int newVal);
    public event OnVariableChangeDelegate OnVariableChange;

    private void Update()
    {
        stimToLookAt = (int)slider.GetComponent<Slider>().value;

        if (stimToLookAt != m_stimToLookAt && OnVariableChange != null)
        {
            m_stimToLookAt = stimToLookAt;
            OnVariableChange(stimToLookAt);
        }
    }
    private void VariableChangeHandler(int newVal)
    {
        stimElec1.GetComponent<Renderer>().material.color = Color.black;
        stimElec2.GetComponent<Renderer>().material.color = Color.black;

        //        stimElec1 = GameObject.Find("LA1");
        //      stimElec2 = GameObject.Find("LA2");
        print(stimulatingElecs[0,0].ToString());
        stimElec1 = GameObject.Find(stimulatingElecs[newVal, 0].ToString());
        stimElec2 = GameObject.Find(stimulatingElecs[newVal, 1]);
        stimElec1.GetComponent<Renderer>().material.color = Color.red;
        stimElec2.GetComponent<Renderer>().material.color = Color.red;

        stimPair.text = stimElec1.name + " - " + stimElec2.name;

        stimulationCoords = (stimElec1.transform.position + stimElec2.transform.position) / 2;
        StartCoroutine(changeStim());

    }
    IEnumerator changeStim()
    {

        for (int j = 0; j < numElectrodeGroups; j++)
        {
            var electrodeGroup = electrodeType.GetChild(j);
            int numElectrodesInGroup = electrodeGroup.childCount;
            for (int i = 0; i < numElectrodesInGroup; i++)
            {
                sphere = GameObject.Find(electrodeGroup.name + (i + 1));
                LineRenderer oldLine = sphere.GetComponent<LineRenderer>();
                if (oldLine != null)
                {
                    Destroy(oldLine);
                    yield return new WaitForSeconds(.01f);
                }
                if (importedJSON[electrodeGroup.name + (i + 1)][1] < 8 && importedJSON[electrodeGroup.name + (i + 1)][1] > 6)
                {
                    LineRenderer line = sphere.AddComponent<LineRenderer>();
                    line.SetPosition(0, stimulationCoords);
                    line.SetPosition(1, sphere.transform.position);
                    line.material = lineColor6;
                    line.startWidth = .4f;
                    line.endWidth = .4f;
                }
                //                if (importedJSON[electrodeGroup.name + (i + 1)][1] != null)
                if (importedJSON[electrodeGroup.name + (i + 1)][1] < 10 && importedJSON[electrodeGroup.name + (i + 1)][1] > 8)
                {
                    LineRenderer line = sphere.AddComponent<LineRenderer>();
                    line.SetPosition(0, stimulationCoords);
                    line.SetPosition(1, sphere.transform.position);
                    line.material = lineColor8;
                    line.startWidth = .5f;
                    line.endWidth = .5f;
                }

                if (importedJSON[electrodeGroup.name + (i + 1)][1] > 10)
                {
                    LineRenderer line = sphere.AddComponent<LineRenderer>();
                    line.SetPosition(0, stimulationCoords);
                    line.SetPosition(1, sphere.transform.position);
                    line.material = lineColor10;
                    line.startWidth = .6f;
                    line.endWidth = .6f;
                }
            }
        }
        yield return new WaitForSeconds(0.1f);
    }
}

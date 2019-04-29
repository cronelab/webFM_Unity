using UnityEngine;
using System.Collections;
public class ElectrodeManager : MonoBehaviour
{

    [SerializeField]
    public Gradient elecGradient;
    private Vector3 elecSize;
    public static bool viz = true;

    private GameObject sphere;
    private Transform electrodeType;
    private int numElectrodeGroups;
    private float elecSliderVal = .01f;

    void Start()
    {
        elecSize = gameObject.transform.localScale;

        electrodeType = GameObject.Find("Electrodes").transform.GetChild(0);
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
                sphere.transform.localScale = new Vector3(elecSliderVal, elecSliderVal, elecSliderVal);
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
    public void switchViz()
    {
        viz = !viz;
    }

    public void Update()
    {
        //float elecSliderVal = Mathf.Abs(GameObject.Find("Canvas").GetComponent<UIElements>().electrodeScaler.value);
        //foreach (GameObject elec in GameObject.FindGameObjectsWithTag("Electrodes"))
        //{
        //    elec.transform.localScale = new Vector3(elecSliderVal, elecSliderVal, elecSliderVal);

        //}
    }

    public void receiveBlinkCommand(string elec)
    {
        StartCoroutine(electrodeHighlighter(elec));
    }

    public IEnumerator electrodeHighlighter(string elec)
    {
        sphere = GameObject.Find(elec);
        foreach (GameObject electrode in GameObject.FindGameObjectsWithTag("Electrodes"))
        {
            if (electrode.GetComponent<Renderer>().material.color == Color.yellow)
            {
                electrode.GetComponent<Renderer>().material.color = Color.black;
            }
        }
        sphere.GetComponent<Renderer>().material.color = Color.yellow;
        yield return new WaitForSeconds(.5f);


    }

    public void activityChanger(string elec)
    {
        float elecSliderVal = Mathf.Abs(GameObject.Find("Canvas").GetComponent<UIElements>().electrodeScaler.value);
        var sElec = elec.Split(" "[0])[0];
        var sAct = elec.Split(" "[0])[1];
        float valFromBrowser = float.Parse(sAct);
        if (valFromBrowser < 1000 || valFromBrowser > -1000)
        {
            sphere = GameObject.Find(sElec);
            //Yo, super inelegant, but most vals are between -.5 and .5, not 0 and 1.
            Color colorGrad = elecGradient.Evaluate(valFromBrowser + .5f);
            sphere.transform.GetComponent<Renderer>().material.color = new Color(colorGrad.r, colorGrad.g, colorGrad.b);
            float scalingVal = elecSliderVal * (float)System.Math.Sqrt((Mathf.Abs(valFromBrowser)));
            if (valFromBrowser != 0)
            {
                sphere.transform.localScale = new Vector3(scalingVal, scalingVal, scalingVal);
            }
            else if (valFromBrowser == 0)
            {

                if (viz == false)
                {
                    sphere.transform.localScale = new Vector3(0, 0, 0);
                }
                else
                {
                    sphere.transform.localScale = new Vector3(.01f, .01f, .01f);
                    sphere.transform.GetComponent<Renderer>().material.color = Color.black;
                }
            }
        }
    }
}

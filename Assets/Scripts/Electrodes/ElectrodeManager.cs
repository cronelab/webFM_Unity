using UnityEngine;
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
        Debug.Log("These electrodes are touching the white matter");
        elecSize = gameObject.transform.localScale;

        electrodeType = GameObject.Find("Electrodes").transform;
        numElectrodeGroups = electrodeType.childCount;
        for (int j = 0; j < numElectrodeGroups; j++)
        {
            var electrodeGroup = electrodeType.GetChild(j);

            int numElectrodesInGroup = electrodeGroup.childCount;
            for (int i = 0; i < numElectrodesInGroup; i++)
            {
                electrodeGroup.GetChild(i).transform.gameObject.AddComponent<SphereCollider>();
                var elecCollider = electrodeGroup.GetChild(i).GetComponent<Collider>();
                Destroy(electrodeGroup.GetChild(i).gameObject);
                sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.SetParent(electrodeType.GetChild(j).transform);
                sphere.transform.position = elecCollider.bounds.center;
                sphere.transform.localScale = new Vector3(elecSliderVal, elecSliderVal, elecSliderVal);
                sphere.name = electrodeGroup.name + (i + 1);
                sphere.AddComponent<isTouchingCollider>();
                sphere.GetComponent<isTouchingCollider>().enabled = true;
                sphere.AddComponent<Rigidbody>();
                sphere.GetComponent<SphereCollider>().radius = .50f;
                sphere.tag = "Electrodes";
                Rigidbody rb = sphere.GetComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.FreezeAll;
                sphere.GetComponent<Renderer>().material.color = Color.black;
            }
        }

    }
}

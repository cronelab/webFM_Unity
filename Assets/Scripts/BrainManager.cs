using UnityEngine;

public class BrainManager : MonoBehaviour
{
    private Material mPia;
    private Material mBrainstem;
    private Material mAmygdala;
    private Material mCaudate;
    private Material mHippocampus;
    private Material mThalamus;
    private Material mPutaman;
    private Material mWM;
    private Shader shader;
    private string[] gyriNames = new string[]{
        "bankssts",
        "inferiorparietal",
        "medialorbitofrontal",
        "pericalcarine",
        "superiorfrontal",
        "caudalanteriorcingulate",
        "inferiortemporal",
        "middletemporal",
        "postcentral",
        "superiorparietal",
        "caudalmiddlefrontal",
        "insula",
        "paracentral",
        "posteriorcingulate",
        "superiortemporal",
        "cuneus",
        "isthmuscingulate",
        "parahippocampal",
        "precentral",
        "supramarginal",
        "entorhinal",
        "lateraloccipital",
        "parsopercularis",
        "precuneus",
        "temporalpole",
        "frontalpole",
        "lateralorbitofrontal",
        "parsorbitalis",
        "rostralanteriorcingulate",
        "transversetemporal",
        "fusiform",
        "lingual",
        "parstriangularis",
        "rostralmiddlefrontal"
    };

    // Start is called before the first frame update
    void Start()
    {
        //Set up everything coming out of Blender.
        shader = Shader.Find("Unlit/SpecialFX/Cool Hologram");
        mPia = Resources.Load<Material>("Materials/Brain/Pia"); ;
        mBrainstem = Resources.Load<Material>("Materials/Brain/Brainstem");
        mAmygdala = Resources.Load<Material>("Materials/Brain/Amygdyla");
        mCaudate = Resources.Load<Material>("Materials/Brain/Caudate");
        mHippocampus = Resources.Load<Material>("Materials/Brain/Hippocampus");
        mThalamus = Resources.Load<Material>("Materials/Brain/Thalamus");
        mPutaman = Resources.Load<Material>("Materials/Brain/Putamen");
        mWM = Resources.Load<Material>("Materials/Brain/WM");
        GameObject pia = gameObject.transform.GetChild(2).gameObject;
        GameObject gyri = gameObject.transform.GetChild(1).gameObject;
        GameObject whiteMatter = gameObject.transform.GetChild(4).gameObject;
        GameObject substructures = gameObject.transform.GetChild(3).gameObject;

        //Set the hologram shader and random colors for the Gyri.
        foreach (string gyriName in gyriNames)
        {
            float r = Random.Range(0.0f, 1.0f);
            float g = Random.Range(0.0f, 1.0f);
            float b = Random.Range(0.0f, 1.0f);
            Renderer lgyrRend = GameObject.Find("lh_" + gyriName).transform.GetComponentInChildren<Renderer>();
            Renderer rgyrRend = GameObject.Find("rh_" + gyriName).transform.GetComponentInChildren<Renderer>();
            lgyrRend.material = new Material(shader);
            rgyrRend.material = new Material(shader);
            lgyrRend.material.color = new Color(r, g, b);
            rgyrRend.material.color = new Color(r, g, b);

        }

        //Disable the Gyri.
        gyri.SetActive(false);
        pia.SetActive(false);
        whiteMatter.SetActive(true);
        substructures.SetActive(false);

        //Set the material for each of the substructures.
        foreach (Renderer rends in substructures.transform.GetComponentsInChildren<Renderer>())
        {
            if (rends.gameObject.name == "lbrainstem")
            {
                rends.material = mBrainstem;
            }
            else if (rends.gameObject.name == "lAmgd" || rends.gameObject.name == "rAmgd")
            {
                rends.material = mAmygdala;
            }
            else if (rends.gameObject.name == "lCaud" || rends.gameObject.name == "rCaud")
            {
                rends.material = mCaudate;
            }
            else if (rends.gameObject.name == "lHipp" || rends.gameObject.name == "rHipp")
            {
                rends.material = mHippocampus;
            }
            else if (rends.gameObject.name == "lThal" || rends.gameObject.name == "rThal")
            {
                rends.material = mThalamus;
            }
            else if (rends.gameObject.name == "lPut" || rends.gameObject.name == "rPut")
            {
                rends.material = mPutaman;
            }
        }
        foreach (MeshRenderer rend in pia.transform.GetComponentsInChildren<MeshRenderer>())
        {
            rend.material = mPia;
        }
        foreach (MeshRenderer rend in whiteMatter.transform.GetComponentsInChildren<MeshRenderer>())
        {
            rend.material = mWM;
            rend.material.SetFloat("_Transparency", .35f);



        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}

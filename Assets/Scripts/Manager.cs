using UnityEngine;

public class Manager : MonoBehaviour
{
    void Start()
    {
        gameObject.transform.GetChild(0).gameObject.AddComponent<BrainManager>();
        gameObject.transform.GetChild(0).gameObject.AddComponent<ElectrodeManager>();
    }
}
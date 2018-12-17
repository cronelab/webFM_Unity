using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electrodeOrganizer : MonoBehaviour
{

    // Use this for initialization
    GameObject firstElectrode, lastElectrode;
    void Start()
    {
        GameObject brainHolder = GameObject.Find("test");
        firstElectrode = brainHolder.transform.GetChild(0).gameObject;
        lastElectrode = brainHolder.transform.GetChild(brainHolder.transform.childCount - 1).gameObject;
        int numElectrodes = brainHolder.transform.childCount;
        while (numElectrodes >= 1)
        {
            if (Physics.SphereCast(firstElectrode.transform.position, .5f, lastElectrode.transform.position - firstElectrode.transform.position, out RaycastHit hitInfo))
            {
                Debug.Log(hitInfo.collider);
                numElectrodes--;
                firstElectrode = GameObject.Find(hitInfo.collider.name);
            }
            else
            {
                numElectrodes = 0;
            }
        }
    }
}
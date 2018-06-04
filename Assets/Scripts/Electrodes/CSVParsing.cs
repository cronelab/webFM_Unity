using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class CSVParsing : MonoBehaviour
{
    public TextAsset csvFile; // Reference of CSV file
    private char lineSeperater = ','; // It defines line seperate character
    //private char fieldSeperator = '\n'; // It defines field seperate chracter
    private Vector3[] elecArray;

    void Start()
    {
        elecArray = new Vector3[128];
        readData();
    }

    //Change size and spacing of electrodes!


    // Read data from CSV file
    private void readData()
    {
        string[] records = csvFile.text.Split(lineSeperater);

        for (int i = 0; i < 128; i++)
        {
            

            elecArray[i] = new Vector3(float.Parse(records[i]), float.Parse(records[128 + i]), float.Parse(records[256 + i]));
            GameObject linearSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            linearSphere.transform.localScale = new Vector3(0.02485016f, 0.02485016f, 0.02485016f);
            linearSphere.transform.position = elecArray[i]/80f;
        }
    }



}
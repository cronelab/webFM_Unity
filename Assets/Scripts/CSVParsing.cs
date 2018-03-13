using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class CSVParsing : MonoBehaviour
{
    public TextAsset linearCsvFile; // Reference of CSV file
    public TextAsset nonLinearCsvFile; // Reference of CSV file
    private char lineSeperater = ','; // It defines line seperate character
    private char fieldSeperator = '\n'; // It defines field seperate chracter
    private Vector3[] linearElecArray;
    private Vector3[] nonLinearElecArray;

    void Start()
    {
        linearElecArray = new Vector3[128];
        nonLinearElecArray = new Vector3[128];
        readData();
    }
    // Read data from CSV file
    private void readData()
    {
        string[] linearRecords = linearCsvFile.text.Split(lineSeperater);
        string[] nonLinearRecords = nonLinearCsvFile.text.Split(lineSeperater);

        for (int i = 0; i < 128; i++)
        {

            //linearElecArray[i] = new Vector3(float.Parse(linearRecords[i]), float.Parse(linearRecords[128 + i]), float.Parse(linearRecords[256 + i]));
            nonLinearElecArray[i] = new Vector3(float.Parse(nonLinearRecords[i]), float.Parse(nonLinearRecords[128 + i]), float.Parse(nonLinearRecords[256 + i]));
            //GameObject linearSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //linearSphere.transform.position = linearElecArray[i];
            GameObject nonLinearSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            nonLinearSphere.transform.position = nonLinearElecArray[i];
        }
    }



}
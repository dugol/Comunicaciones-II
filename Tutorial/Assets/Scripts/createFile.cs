using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class createFile : MonoBehaviour {


    String fileName;
    StreamWriter sr;
    void Start ()
    {
        fileName = "Posi.csv";
        if (File.Exists(fileName))
        {
            Debug.Log(fileName + " ya existe.");
        }
        sr = File.CreateText(fileName);
	}
	
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Rayo desde la cámara
            RaycastHit hit; //Objeto tipo choque

            if (Physics.Raycast(ray, out hit))
            { //Entra al IF si se choca con algo
                sr.WriteLine(hit.point);
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            sr.Close();
            Debug.Break();
        }
    }
}

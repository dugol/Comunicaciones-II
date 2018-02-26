using UnityEngine;
using System.Collections;

public class CapsuleMovement : MonoBehaviour {

    Vector3 final;
    Quaternion rotacion;
    public float smooth = 1.0f;
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Rayo desde la cámara
            RaycastHit hit; //Objeto tipo choque

            if (Physics.Raycast(ray, out hit))
            { //Entra al IF si se choca con algo

                final =hit.point;
                rotacion = Quaternion.LookRotation(hit.point - transform.position);
                transform.rotation = rotacion;
               
            }
        }
        transform.position = Vector3.Lerp(transform.position,final,smooth* Time.deltaTime);

    }
}

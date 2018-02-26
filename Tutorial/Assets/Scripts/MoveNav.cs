using UnityEngine;
using System.Collections;

public class MoveNav : MonoBehaviour {

    // Use this for initialization
    Vector3 final;
    UnityEngine.AI.NavMeshAgent nav;
	void Awake()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Rayo desde la cámara
            RaycastHit hit; //Objeto tipo choque

            if (Physics.Raycast(ray, out hit))
            { //Entra al IF si se choca con algo

                final = hit.point;
                nav.SetDestination(final);

            }
        }
    }
}

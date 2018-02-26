using UnityEngine;
using System.Collections;

public class collision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Moneda"))
        {
            Destroy(other.collider.gameObject);
            NotificationCenter.DefaultCenter().PostNotification(this, "GenerarMoneda");
        }
    }
}

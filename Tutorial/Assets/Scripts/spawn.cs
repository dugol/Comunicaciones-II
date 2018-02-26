using UnityEngine;
using System.Collections;

public class spawn : MonoBehaviour {

    public GameObject Moneda;
    public Transform Principio;
    public Transform Final;
    float alturaMaxima = 4.9f;
    float alturaMinima = 0f;
    void Awake()
    {
        
    }
    void Start ()
    {
        NotificationCenter.DefaultCenter().AddObserver(this, "GenerarMoneda");
        Generar10Monedas();
	}

    void Generar10Monedas()
    {
        for (int i = 0; i < 10; i++)
        {
            bool crear = true;
            Vector3 pos;
            pos = new Vector3(Random.Range(Principio.position.x, Final.position.x), 0, Random.Range(Principio.position.z, Final.position.z));

            RaycastHit hit;
            if (Physics.Raycast(Vector3.up * alturaMaxima + pos, -Vector3.up, out hit, 4.9f))
            {
                pos = hit.point;
                if (hit.point.y <= alturaMinima)
                {
                    crear = false;
                }
            }

            if (crear)
            {
                Instantiate(Moneda, pos + new Vector3(0, 0.77f, 0), Quaternion.identity);
            }
            else
            {
                i--;
            }

        }
    }

    void GenerarMoneda(Notification notificacion)
    {
        bool crear = true;
        Vector3 pos;
        pos = new Vector3(Random.Range(Principio.position.x, Final.position.x), 0, Random.Range(Principio.position.z, Final.position.z));

        RaycastHit hit;
        if (Physics.Raycast(Vector3.up * alturaMaxima + pos, -Vector3.up, out hit, 4.9f))
        {
            pos = hit.point;
            if (hit.point.y <= alturaMinima)
            {
                crear = false;
            }
        }

        if (crear)
        {
            Instantiate(Moneda, pos + new Vector3(0, 0.77f, 0), Quaternion.identity);
        }

    }



}

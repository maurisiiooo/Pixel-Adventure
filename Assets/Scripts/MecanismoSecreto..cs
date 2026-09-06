using UnityEngine;

public class MecanismoSecreto : MonoBehaviour
{
    public GameObject paredSecreta; 
    public Vector3 desplazamientoApertura = new Vector3(0, -5f, 0); 

    private Vector3 posicionInicial;
    private bool activado = false;

    void Start()
    {
        if (paredSecreta != null)
        {
            posicionInicial = paredSecreta.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.GetComponent<Rigidbody>() != null && !activado)
        {
            activado = true;
            if (paredSecreta != null)
            {
                
                paredSecreta.transform.position = posicionInicial + desplazamientoApertura;
            }
        }
    }
}
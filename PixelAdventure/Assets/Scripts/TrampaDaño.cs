using UnityEngine;

public class TrampaPinchos : MonoBehaviour
{
    [Header("Punto de Reaparición")]
    public Transform puntoInicio;

    private void Start()
    {
        
        if (puntoInicio == null)
        {
            GameObject spawn = GameObject.Find("PuntoInicio");
            if (spawn != null)
            {
                puntoInicio = spawn.transform;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player") || other.GetComponent<CharacterController>() != null)
        {
            CharacterController controlador = other.GetComponent<CharacterController>();

            if (controlador != null)
            {
                
                controlador.enabled = false;

                if (puntoInicio != null)
                {
                    other.transform.position = puntoInicio.position;
                    other.transform.rotation = puntoInicio.rotation;
                }
                else
                {
                    
                    other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y + 2f, other.transform.position.z);
                }

                controlador.enabled = true;
            }
        }
    }
}
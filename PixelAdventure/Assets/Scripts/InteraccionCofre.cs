using UnityEngine;

public class InteraccionCofre : MonoBehaviour
{
    private bool estaCerca = false;
    private bool cofreAbierto = false;

    [Header("Recompensa")]
    public GameObject objetoRecompensa; 

    private void Update()
    {
        if (estaCerca && !cofreAbierto && Input.GetKeyDown(KeyCode.E))
        {
            cofreAbierto = true;
            Debug.Log("¡Cofre abierto con éxito! Mecánica cumplida.");

            
            GetComponent<Renderer>().material.color = Color.yellow;

            
            if (objetoRecompensa != null)
            {
                objetoRecompensa.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            estaCerca = true;
            Debug.Log("Presiona 'E' para abrir el cofre.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            estaCerca = false;
        }
    }
}
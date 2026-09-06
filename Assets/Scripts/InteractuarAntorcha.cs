using UnityEngine;

public class InteractuarAntorcha : MonoBehaviour
{
    private bool jugadorCerca = false;
    public GameObject luzAntorcha; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador") || other.name.Contains("Jugador"))
        {
            jugadorCerca = true;
            Debug.Log("Presiona 'E' para interactuar con la antorcha");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Jugador") || other.name.Contains("Jugador"))
        {
            jugadorCerca = false;
        }
    }

    private void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            // Alternar el estado de la luz
            if (luzAntorcha != null)
            {
                luzAntorcha.SetActive(!luzAntorcha.activeSelf);
                Debug.Log("Antorcha alternada");
            }
        }
    }
}
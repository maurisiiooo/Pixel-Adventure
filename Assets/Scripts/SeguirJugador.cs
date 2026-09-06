using UnityEngine;

public class SeguirJugador : MonoBehaviour
{
    public Transform objetivo;
    public Vector3 offset = new Vector3(0f, 3f, -5f);
    public float velocidadSuavizado = 5f;

    
    public float sensibilidadMouse = 5f;
    private float rotacionX = 0f;
    private float rotacionY = 0f;

    private void Start()
    {
       
    }

    private void LateUpdate()
    {
        if (objetivo == null) return;

       
        rotacionX += Input.GetAxis("Mouse X") * sensibilidadMouse;
        rotacionY -= Input.GetAxis("Mouse Y") * sensibilidadMouse;

        
        rotacionY = Mathf.Clamp(rotacionY, -10f, 60f);

        
        Quaternion rotacion = Quaternion.Euler(rotacionY, rotacionX, 0);

        
        Vector3 posicionDeseada = objetivo.position + rotacion * offset;

        
        transform.position = Vector3.Lerp(transform.position, posicionDeseada, velocidadSuavizado * Time.deltaTime);

       
        transform.LookAt(objetivo.position + Vector3.up * 1.5f);
    }
}
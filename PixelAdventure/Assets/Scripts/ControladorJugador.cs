using UnityEngine;

public class ControladorJugador : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;
    public float velocidadCaminar = 4f;
    public float velocidadCorrer = 8f;
    public float fuerzaSalto = 2f;
    public float gravedad = -9.81f;
    private Vector3 velocidadMovimiento;

    public Transform camaraTransform;

    [Header("Empuje de Objetos")]
    public float fuerzaEmpuje = 3.0f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        if (camaraTransform == null && Camera.main != null)
        {
            camaraTransform = Camera.main.transform;
        }
    }

    private void Update()
    {
        // 1. Resetear la gravedad vertical si está en el suelo
        if (controller.isGrounded && velocidadMovimiento.y < 0)
        {
            velocidadMovimiento.y = -2f;
        }

        // 2. Movimiento horizontal (WASD) y Shift para correr
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 forward = camaraTransform.forward;
        Vector3 right = camaraTransform.right;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 movimiento = forward * moveZ + right * moveX;

        bool estaCorriendo = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        float velocidadActual = estaCorriendo ? velocidadCorrer : velocidadCaminar;

        // Asignar velocidad horizontal al vector de movimiento
        velocidadMovimiento.x = movimiento.x * velocidadActual;
        velocidadMovimiento.z = movimiento.z * velocidadActual;

        // 3. Rotación hacia donde se mueve
        if (movimiento != Vector3.zero)
        {
            Quaternion rotacionObjetivo = Quaternion.LookRotation(movimiento);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionObjetivo, 15f * Time.deltaTime);
        }

        // 4. Lógica de Salto (Barra Espaciadora)
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocidadMovimiento.y = Mathf.Sqrt(fuerzaSalto * -2f * gravedad);
            animator.SetTrigger("Saltar");
        }

       
        velocidadMovimiento.y += gravedad * Time.deltaTime;

        
        controller.Move(velocidadMovimiento * Time.deltaTime);

        
        float valorAnimacionVelocidad = 0f;
        if (movimiento.magnitude > 0.01f)
        {
            valorAnimacionVelocidad = estaCorriendo ? 1f : 0.5f;
        }
        animator.SetFloat("Velocidad", valorAnimacionVelocidad);

        
        animator.SetBool("EstaEnSuelo", controller.isGrounded);
    }

   
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody cuerpoRigido = hit.collider.attachedRigidbody;

       
        if (cuerpoRigido == null || cuerpoRigido.isKinematic) return;

        
        if (hit.moveDirection.y < -0.3f) return;

       
        Vector3 direccionEmpuje = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

       
        cuerpoRigido.linearVelocity = direccionEmpuje * fuerzaEmpuje;
    }
}
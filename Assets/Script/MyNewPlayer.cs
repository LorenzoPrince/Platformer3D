using UnityEngine;
using UnityEngine.InputSystem; //para llamar al paquete de el inputsystem nuevo
// [RequireComponent(typeof(CharacterController))] //previene errores agrega automaticamente unity el componente
public class MyNewPlayer : MonoBehaviour
{
    private Rigidbody rigidBody;
    Vector2 moveInput;
    public float movementSpeed;
    public float gravity = -9.81f;
    private bool isGrounded;
    public float JumpForce;
    public int rotationSpeed = 2;
    private Vector2 inputMovement;
    public Transform playerCamera;
    private void Awake() // esto se llama antes de que inicie el juego recomendable para cosas como rigybidy etc
    {

        rigidBody = GetComponent<Rigidbody>();

        rigidBody.freezeRotation = true; // evitar caídas por rotación física
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void FixedUpdate() //hace que vaya intervalos fisicos de tiempo.
    {
  
            Vector3 camForward = playerCamera.transform.forward;
            Vector3 camRight = playerCamera.transform.right;

            camForward.y = 0;
            camRight.y = 0;

            camForward.Normalize();
            camRight.Normalize();

            Vector3 movement = camForward * moveInput.y + camRight * moveInput.x;

            if (movement != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(movement);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }

            rigidBody.AddForce(movement * movementSpeed, ForceMode.VelocityChange); // toma directamente la nueva velocidad impulse empuja entonce se nota
       




    }
    public void OnJump(InputAction.CallbackContext context) //me da lo que esta guardando del evento. cuando toque el boton usar el on antes siempre
    {
        if (context.performed)
        {
            if (isGrounded)
            {
                rigidBody.AddForce(Vector3.up  * JumpForce, ForceMode.Impulse );
                Debug.Log("Jump");
                isGrounded = false;
            }
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>(); // actualizo el vector 2 y ponemo donde esta, osea lee.
        Debug.Log("Move:" + moveInput);
    }
    public void OnScreenShot(InputAction.CallbackContext context)
    {
        if (context.performed) // el context.performed sirve para boolenaos
        {

            Debug.Log("ScreenShot!");
        }
    }
    private void OnCollisionEnter(Collision contraLoQueChoque)
    {
        Debug.Log("choque contra " + contraLoQueChoque.gameObject.name);
        if (contraLoQueChoque.gameObject.CompareTag("Pizo"))
        {
            isGrounded = true;
        }

    }
}

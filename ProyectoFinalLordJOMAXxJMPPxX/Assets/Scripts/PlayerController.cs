using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;
    public Rigidbody rb;
    private bool isGrounded;
    private int jumpCount;
    private Vector2 movementInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 moveDirection = transform.right * movementInput.x + transform.forward * movementInput.y;
        Vector3 velocity = moveDirection * speed;
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
    }

    public void Move(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && (isGrounded || jumpCount < 2))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            jumpCount++;
        }
    }
    public void Boost(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            speed *= 2; 
        }
        else if (context.canceled)
        {
            speed /= 2; 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0; // Reiniciar el contador de saltos al estar en el suelo
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}

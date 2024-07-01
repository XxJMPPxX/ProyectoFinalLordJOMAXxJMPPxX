using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;
    public Rigidbody rb;
    private bool isGrounded;
    private int jumpCount;
    private Vector2 movementInput;
    public AudioLibreria audioManager;
    public Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        animator.SetBool("OnRun", false);
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

        if (isGrounded && (movementInput.x != 0 || movementInput.y != 0))
        {
            audioManager.SFXSource.clip = audioManager.SFXSOunds[1];
            audioManager.SFXSource.Play();
            animator.SetBool("OnRun", true);
        }
        else
        {
            animator.SetBool("OnRun", false);
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && (isGrounded || jumpCount < 1))
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
            jumpCount = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("trampa"))
        {
            SceneManager.LoadScene("Level0");
        }


        if (other.CompareTag("AGARRADO"))
        {
            SceneManager.LoadScene("Selector de niveles");
        }
    }
}

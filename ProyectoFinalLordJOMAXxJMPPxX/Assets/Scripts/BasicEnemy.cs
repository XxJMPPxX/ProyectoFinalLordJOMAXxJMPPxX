using UnityEngine;

public class BasicEnemy : Enemy
{
    [SerializeField] private float basicSpeed = 3f;
    [SerializeField] private float basicHealth = 100;
    [SerializeField] private int basicDamage = 2;
    public Animator animator;

    private GameObject centroArtefacto;
    private VidaArtefacto vidaArtefacto;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isAttacking", false);

        centroArtefacto = GameObject.Find("CentroArtefacto");
        if (centroArtefacto == null)
        {
            Debug.LogError("CentroArtefacto no encontrado. Aseg�rate de que el objeto est� en la escena.");
        }

        GameObject vidaArtefactoObject = GameObject.Find("CentroArtefacto");
        if (vidaArtefactoObject != null)
        {
            vidaArtefacto = vidaArtefactoObject.GetComponent<VidaArtefacto>();
            if (vidaArtefacto == null)
            {
                Debug.LogError("El GameObject encontrado no tiene un componente VidaArtefacto.");
            }
        }
        else
        {
            Debug.LogError("No se encontr� un GameObject con el nombre especificado.");
        }
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;

        if (centroArtefacto != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, centroArtefacto.transform.position, step);
        }

        if (basicHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        speed = basicSpeed;
        health = basicHealth;
        damage = basicDamage;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("artefacto"))
        {
            speed = 0;

            if (vidaArtefacto != null)
            {
                vidaArtefacto.Vida -= damage;
            }
            else
            {
                Debug.LogWarning("VidaArtefacto no est� asignado.");
            }

            animator.SetBool("isAttacking", true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("artefacto"))
        {
            speed = basicSpeed;
            animator.SetBool("isAttacking", false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("LLAMA"))
        {
            basicHealth -= 10 * Time.deltaTime;
        }


        if (other.CompareTag("CONGELADO"))
        {
            speed = 0;
        }


    }
}

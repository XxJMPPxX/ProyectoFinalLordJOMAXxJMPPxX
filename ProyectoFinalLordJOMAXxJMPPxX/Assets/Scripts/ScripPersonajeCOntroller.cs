using UnityEngine;

public class BasicEnemy : Enemy
{
    [SerializeField]
    private float basicSpeed = 3f;
    [SerializeField]
    private int basicHealth = 100;
    [SerializeField]
    private int basicDamage = 10;
    public Transform target;
    private void Start()
    {
        speed = basicSpeed;
        health = basicHealth;
        damage = basicDamage;
    }

    protected void Update()
    {
        MoveTowardsTarget();
    }

   public void MoveTowardsTarget()
    {
        
            transform.position += (target.position - transform.position).normalized * speed * Time.deltaTime;
        
    }
}

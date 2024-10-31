using UnityEngine;
using System.Collections;

public class EnemyFunctionality : MonoBehaviour
{
    private CurvedHealthBar curvedHealthBar;

    // Movement
    public float speed;

    // Health
    [SerializeField] private float maxHealth, currentHealth;

    // Moving from point to point
    public Transform wayPointTarget;
    private int wavepointIndex = 0;
    private float rotationSpeed = 0.2f;
    private Animator animator;
    private Quaternion rotGoal;
    private Vector3 direction;

    [SerializeField] private GameObject gameManager;
    public WaveSpawner waveSpawner;
    private int enemyDied = 0;

    [SerializeField] private PlayerAttributes playerAttributes;

    private void Awake()
    {
        maxHealth = currentHealth;
    }
    private void Start()
    {
        wayPointTarget = Waypoints.points[0];
        animator = this.GetComponent<Animator>();
    }
    private void Update()
    {
        if (currentHealth > 0)
        {
            GetMoving();
            ChangeLookDirection();
            if (Vector3.Distance(transform.position, wayPointTarget.position) <= 0.5f)
            {
                GetNextWayPoint();
            }
        }
    }
    public void GetMoving()
    {
        Vector3 enemyTravelDirection = (wayPointTarget.position - transform.position).normalized;
        transform.Translate(enemyTravelDirection * speed * Time.deltaTime, Space.World);
    }
    void GetNextWayPoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1 && enemyDied == 0)
        {
            enemyDied = 1;
            gameManager.GetComponent<PlayerAttributes>().PlayerLifeLost();
            EndReached();
            return;
        }
        else if (enemyDied == 1)
        {
            return;
        }
        wavepointIndex++;
        wayPointTarget = Waypoints.points[wavepointIndex];
    }
    void ChangeLookDirection()
    {                      
        direction = (wayPointTarget.position - transform.position).normalized;

        rotGoal = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotGoal, rotationSpeed);
    }
    public IEnumerator DeathAnimation()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }    
    void Die()
    {
        animator.Play("Death");
        waveSpawner.enemies.Remove(gameObject);
        StartCoroutine(DeathAnimation());
    }
    void EndReached()
    {
        waveSpawner.enemies.Remove(gameObject);
        Destroy(gameObject);
    }
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        curvedHealthBar = GetComponentInChildren<CurvedHealthBar>();
        curvedHealthBar.FillState = currentHealth/maxHealth;
        if (currentHealth <= 0)
        {
            curvedHealthBar.FillState = 0f / maxHealth;
            playerAttributes.GetComponent<PlayerAttributes>().enemiesKilled++;
            Die();
        }
    }
    public bool IsDead()
    {
        if (currentHealth <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
        //return false;
    }
}

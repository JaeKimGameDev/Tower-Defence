using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem.Processors;
using UnityEngine.UI;

public class EnemyFunctionality : MonoBehaviour
{
    // Movement
    public float speed = 10f;

    // Health
    [SerializeField] private float maxHealth = 100f, currentHealth = 100f;
    private FloatingHealthBar healthBar;

    // Moving from point to point
    private Transform target;
    private int wavepointIndex = 0;
    public float rotationSpeed = 720;
    private Animator animator;

    private void Awake()
    {
        maxHealth = currentHealth;
    }

    private void Start()
    {
        target = Waypoints.points[0];
        changeLookDirection();
        animator = this.GetComponent<Animator>();
        healthBar = this.GetComponentInChildren<FloatingHealthBar>();
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
    }

    private void Update()
    {
        Vector3 enemyTravelDirection = (target.position - transform.position).normalized;
        transform.Translate(enemyTravelDirection * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.5f)
        {
            if (enemyTravelDirection != Vector3.zero)
            {
                Quaternion enemyRotation = Quaternion.LookRotation(transform.position, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, enemyRotation, rotationSpeed * Time.deltaTime);
            }
            GetNextWayPoint();
        }
    }

    // move to waypoint
    void GetNextWayPoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            Dies();
            // implement player life or chances lost because gameobject has reached the end without dying
            //numberOfEnemies--;
            return;
        }
        wavepointIndex++;
        changeLookDirection();
    }

    void changeLookDirection()
    {
        target = Waypoints.points[wavepointIndex];
        transform.LookAt(target.position);
        target.Rotate(new Vector3(0, 0, 0));
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
        if (currentHealth <= 0)
        {
            Dies();
        }
    }

    void Dies()
    {
        animator.SetBool("isDead", true);
        Destroy(gameObject);
    }
}

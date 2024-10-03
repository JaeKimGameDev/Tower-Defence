using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem.Processors;
using UnityEngine.UI;

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
    private float rotationSpeed = 0.05f;
    private Animator animator;
    private Quaternion rotGoal;
    private Vector3 direction;

    public PlayerAttributes playerAttributes;

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
        GetMoving();
        ChangeLookDirection();

        if (Vector3.Distance(transform.position, wayPointTarget.position) <= 0.5f)
        {
            GetNextWayPoint();
        }
    }
    public void GetMoving()
    {
        Vector3 enemyTravelDirection = (wayPointTarget.position - transform.position).normalized;
        transform.Translate(enemyTravelDirection * speed * Time.deltaTime, Space.World);
    }
    void GetNextWayPoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            playerAttributes.PlayerLifeLost();
            Die();
            // implement player life or chances lost because gameobject has reached the end without dying
            //numberOfEnemies--;
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
    void Die()
    {
        animator.SetBool("isDead", true);
        Destroy(gameObject);
    }
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        curvedHealthBar = GetComponentInChildren<CurvedHealthBar>();
        curvedHealthBar.FillState = currentHealth/maxHealth;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
}

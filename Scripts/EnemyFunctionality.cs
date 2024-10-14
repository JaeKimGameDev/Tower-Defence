using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem.Processors;
using UnityEngine.UI;
using DamageNumbersPro;
using Unity.VisualScripting;
using UnityEngine.UIElements;
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
    private float rotationSpeed = 0.05f;
    private Animator animator;
    private Quaternion rotGoal;
    private Vector3 direction;

    public GameObject gameManager;
    public WaveSpawner waveSpawner;

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
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            gameManager.GetComponent<PlayerAttributes>().PlayerLifeLost();
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
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        curvedHealthBar = GetComponentInChildren<CurvedHealthBar>();
        curvedHealthBar.FillState = currentHealth/maxHealth;
        if (currentHealth <= 0)
        {
            curvedHealthBar.FillState = 0f / maxHealth;
            Die();
        }
    }
    public bool IsDead()
    {
        if (currentHealth <= 0)
        {
            return true;
        }
        return false;
    }
}

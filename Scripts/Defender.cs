using UnityEngine;
using System.Collections.Generic;

public class Defender : MonoBehaviour
{
    private Transform target;
    private Quaternion rotGoal;
    private Vector3 direction;
    private float rotationSpeed = .1f;
    //private float rotationSpeed = 0.75f;

    [Header("Attributes")]
    public float range;
    public float fireRate;
    private float fireCountdown;

    [SerializeField]
    private float gunDamage;

    public GameObject bulletPrefab;
    public Transform firePoint;
    private GameObject frontOfEnemy;
    public float enemyDistance;

    private Animator animator;
    public GameObject muzzleFlash;
    private ParticleSystem muzzleParticleSystem;

    public WaveSpawner waveSpawner;

    void Start()
    {
        muzzleParticleSystem = muzzleFlash.GetComponent<ParticleSystem>();
        animator = GetComponent<Animator>();
        animator.SetTrigger("Idle");
        InvokeRepeating("UpdateTarget", 0f, 0.1f);
        fireCountdown = 0.25f;
    }
    void UpdateTarget()
    {
        List<GameObject> enemies = waveSpawner.enemies;
        frontOfEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (enemyDistance <= range)
            {
                frontOfEnemy = enemy;
                break;
            }
        }
        if (frontOfEnemy != null && frontOfEnemy.GetComponent<EnemyFunctionality>().IsDead() == false)
        {
            target = frontOfEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
    void FixedUpdate()
    {
        fireCountdown -= Time.deltaTime;
        if (target == null)
        {
            animator.SetTrigger("Idle");
            return;
        }
        else
        {
            ChangeLookDirection();
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }            
        }        
    }
    void Shoot()
    {
        animator.SetTrigger("Shoot");
        muzzleParticleSystem.Play();
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        animator.SetTrigger("ShootIdle");
        if (bullet != null)
        {
            bullet.Seek(target, gunDamage);
        }
    }
    void ChangeLookDirection()
    {
        animator.SetTrigger("ShootIdle");
        direction = (target.position - transform.position).normalized;
        rotGoal = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotGoal, rotationSpeed);
    }
    public void IncreaseGunDamage(float increaseDamageBy)
    {
        gunDamage = gunDamage + increaseDamageBy;
    }    
    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

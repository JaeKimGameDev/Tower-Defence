using UnityEngine;
using static UnityEngine.InputSystem.OnScreen.OnScreenStick;
using System.Collections;
using System.Collections.Generic;

public class Defender : MonoBehaviour
{
    private Transform target;
    private Quaternion rotGoal;
    private Vector3 direction;
    private float rotationSpeed = 0.75f;

    [Header("Attributes")]
    public float range;
    public float fireRate;
    private float fireCountdown;

    [SerializeField]
    private float gunDamage;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public GameObject frontOfEnemy;
    public float enemyDistance;

    private Animator animator;
    public GameObject muzzleFlash;
    private ParticleSystem muzzleParticleSystem;

    public WaveSpawner waveSpawner;

    void Start()
    {
        muzzleParticleSystem = muzzleFlash.GetComponent<ParticleSystem>();
        animator = GetComponent<Animator>();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    void UpdateTarget()
    {
        //GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
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
        if (frontOfEnemy != null && frontOfEnemy.GetComponent<EnemyFunctionality>().IsDead() is false)
        {
            target = frontOfEnemy.transform;
        }
        else
        {
            animator.SetTrigger("Idle");
        }
    }

    void FixedUpdate()
    {        
        if (target == null)
        {
            return;
        }
        animator.SetTrigger("ShootIdle");
        ChangeLookDirection();

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
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
}

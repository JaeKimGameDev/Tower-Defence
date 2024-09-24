using UnityEngine;

public class Turret : MonoBehaviour
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

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
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
        if (frontOfEnemy != null)
        {
            target = frontOfEnemy.transform;
        }
    }

    void FixedUpdate()
    {
        if (target == null)
        {
            return;
        }
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
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target, gunDamage);
        }
    }

    void ChangeLookDirection()
    {
        direction = (target.position - transform.position).normalized;
        rotGoal = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotGoal, rotationSpeed);
    }

    private void Awake()
    {
        
    }
}

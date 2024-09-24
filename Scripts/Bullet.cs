using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float damage;
    public float speed;
    public EnemyFunctionality enemyFunctionality;
    
    public void Seek(Transform _target, float _damage)
    {
        target = _target;
        damage = _damage;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        DamageEnemy(target.gameObject);
        Destroy(gameObject);
    }

    void DamageEnemy(GameObject enemy)
    {
        EnemyFunctionality enemyFunctionality = enemy.GetComponent<EnemyFunctionality>();
        if (enemyFunctionality != null) 
        {
            enemyFunctionality.TakeDamage(damage);
        }
    }
}

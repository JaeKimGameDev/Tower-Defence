using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _target;
    public float _damage;
    public float speed;
    public EnemyFunctionality enemyFunctionality;
    
    public void Seek(Transform target, float damage)
    {
        _target = target;
        _damage = damage;
    }
    public float Damage
    {
        get
        { 
            return _damage;
        }
        set
        {
            _damage = value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = _target.position - transform.position;
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
        DamageEnemy(_target.gameObject);
        Destroy(gameObject);
    }

    void DamageEnemy(GameObject enemy)
    {
        EnemyFunctionality enemyFunctionality = enemy.GetComponent<EnemyFunctionality>();
        if (enemyFunctionality != null) 
        {
            enemyFunctionality.TakeDamage(_damage);
        }
        else
        {
            return;
        }
    }
}

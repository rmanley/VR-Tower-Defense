using UnityEngine;

public class TurretProjectile : Projectile
{
    private Transform target;
    private float damage;

    public void Seek(Transform target, float damage)
    {
        this.target = target;
        this.damage = damage;
    }

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
            if(target.gameObject.tag == "Enemy")
                HitTarget(target.gameObject, damage);
            Destroy(gameObject);
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    protected override void HitTarget(GameObject target, float damage)
    {
        base.HitTarget(target, damage);

        //EnemyStats enemyStats = target.gameObject.GetComponent<EnemyStats>();
        //enemyStats.TakeDamage(damage);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}

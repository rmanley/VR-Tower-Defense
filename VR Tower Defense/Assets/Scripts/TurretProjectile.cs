using UnityEngine;

public class TurretProjectile : Projectile
{
    private Transform target;

    public void Seek(Transform target)
    {
        this.target = target;
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
                HitTarget(target.gameObject);
            Destroy(gameObject);
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    protected override void HitTarget(GameObject target)
    {
        base.HitTarget(target);

        EnemyStats enemyStats = target.gameObject.GetComponent<EnemyStats>();
        PlayerManager.instance.player.GetComponent<PlayerStats>().money += enemyStats.bounty;
        enemyStats.TakeDamage(damage);
    }
}

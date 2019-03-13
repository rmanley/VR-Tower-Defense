using System;
using UnityEngine;

public class PlayerProjectile : Projectile
{
    Gun gun;
    Vector3 startpos;
    Vector3 dir;
    Collider target;
    public float heatSeekingRange;
    private float distanceThisFrame = 0f;

    private void Awake()
    {
        gun = FindObjectOfType<Gun>();
        startpos = transform.position;
        dir = Vector3.forward;
    }

    void Update()
    {
        if(heatSeekingRange > 0f)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, heatSeekingRange);
            foreach (Collider collider in colliders)
            {
                if (collider.tag == "Enemy")
                {
                    Debug.Log(collider.transform.name);
                    target = collider;
                    heatSeekingRange = 0f;
                    break;
                }
            }
        }

        distanceThisFrame = speed * Time.deltaTime;
        if (target != null)
        {
            dir = target.transform.position - transform.position;
            transform.LookAt(target.transform);
            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        }
        transform.Translate(dir.normalized * distanceThisFrame);


        if (Vector3.Distance(transform.position, startpos) > gun.range)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            HitTarget(collision.gameObject);
        }
        Destroy(gameObject);
    }

    protected override void HitTarget(GameObject target)
    {
        base.HitTarget(target);

        EnemyStats enemyStats = target.gameObject.GetComponent<EnemyStats>();
        enemyStats.TakeDamage(damage);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, heatSeekingRange);
    }
}

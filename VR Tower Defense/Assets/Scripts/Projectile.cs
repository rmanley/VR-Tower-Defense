using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 70f;
    public float explosionRadius = 0f;
    public GameObject impactEffect;

    protected virtual void HitTarget(GameObject target, float damage)
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

        if (explosionRadius > 0f)
        {
            Explode(damage);
        }
        else
        {
            EnemyStats enemyStats = target.gameObject.GetComponent<EnemyStats>();
            enemyStats.TakeDamage(damage);
        }
    }

    void Explode(float damage)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                EnemyStats enemyStats = collider.gameObject.GetComponent<EnemyStats>();
                enemyStats.TakeDamage(damage);
            }
        }
    }
}

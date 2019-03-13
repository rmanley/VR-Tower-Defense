using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 70f;
    public float damage = 25f;
    public float explosionRadius = 0f;
    public GameObject impactEffect;

    protected virtual void HitTarget(GameObject target)
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            EnemyStats enemyStats = target.gameObject.GetComponent<EnemyStats>();
            enemyStats.TakeDamage(damage);
        }
    }

    void Explode()
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

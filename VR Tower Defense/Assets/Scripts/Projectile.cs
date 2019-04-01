using System;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public float speed = 70f;
    public float explosionRadius = 0f;
    public float damage;
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
            CharacterStats targetStats = target.gameObject.GetComponent<CharacterStats>();
            targetStats.TakeDamage(damage);
        }
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider collider in colliders)
        {
            if(collider.tag == "Enemy" || collider.tag == "Player")
            {
                CharacterStats targetStats = collider.gameObject.GetComponent<CharacterStats>();
                targetStats.TakeDamage(damage);
            }
        }
    }
}

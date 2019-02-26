using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 70f;
    public float damage = 25f;
    public GameObject impactEffect;

    protected virtual void HitTarget(GameObject target)
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
    }
}

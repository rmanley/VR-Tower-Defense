using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{
    Vector3 startpos;
    Vector3 dir;
    Collider target;
    public bool isHeatSeeking = false;
    private float distanceThisFrame = 0f;
    private float range = 10f;
    
    void Start()
    {
        startpos = transform.position;
        dir = Vector3.forward;
        target = PlayerManager.instance.player.GetComponent<Collider>();
    }
    
    void Update()
    {
        
        distanceThisFrame = speed * Time.deltaTime;
        if (isHeatSeeking)
        {
            dir = target.transform.position - transform.position;
            transform.LookAt(target.transform);
            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        }
        transform.Translate(dir.normalized * distanceThisFrame);

        if (Vector3.Distance(transform.position, startpos) > range)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            HitTarget(collision.gameObject);
            Destroy(gameObject);
        }
    }

    public void SetDamageAndRange(float damage, float range)
    {
        this.damage = damage;
        this.range = range;
    }
}

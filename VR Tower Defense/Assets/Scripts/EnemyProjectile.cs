using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{
    Gun gun;
    Vector3 startpos;
    Vector3 dir;
    Collider target;
    public bool isHeatSeeking = false;
    private float distanceThisFrame = 0f;

    // Start is called before the first frame update
    void Start()
    {
        gun = FindObjectOfType<Gun>();
        damage = gun.damage;
        startpos = transform.position;
        dir = Vector3.forward;
    }
    
    void Update()
    {
        

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

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            HitTarget(collision.gameObject);
        }
        Destroy(gameObject);
    }
}

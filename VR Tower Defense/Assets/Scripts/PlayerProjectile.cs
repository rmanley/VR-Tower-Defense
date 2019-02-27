using UnityEngine;

public class PlayerProjectile : Projectile
{
    Gun gun;
    Vector3 startpos;
    private float distanceThisFrame = 0f;

    private void Awake()
    {
        gun = FindObjectOfType<Gun>();
        startpos = transform.position;
    }

    void Update ()
    {
        distanceThisFrame = speed * Time.deltaTime;
        transform.Translate(Vector3.forward * distanceThisFrame);

        if (Vector3.Distance(transform.position, startpos) > gun.range) Destroy(gameObject);
        //Debug.Log(speed);
        //Debug.Log(distanceThisFrame);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            //Debug.Log("HIT THE ENEMY");
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
}

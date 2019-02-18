using UnityEngine;

public class PlayerBullet : MonoBehaviour {

    public float speed = 70f;
    public GameObject impactEffect;
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
        Debug.Log(speed);
        Debug.Log(distanceThisFrame);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Enemy(Clone)")
        {
            Debug.Log("HIT THE ENEMY");
            HitTarget();
            Destroy(collision.gameObject);

            
        }
    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        Destroy(gameObject);
    }
}

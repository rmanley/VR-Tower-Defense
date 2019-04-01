using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackStrategy : MonoBehaviour, IStrategy
{
    private const float BURST_DELAY = 0.15f;
    private PlayerStats playerStats;
    private GameObject context;
    private WaveSpawner spawner;
    private Transform target;
    private NavMeshAgent agent;
    private EnemyStats stats;
    private Enemy enemy;

    private void Start()
    {
        context = GetComponentInParent<Enemy>().gameObject;
        stats = context.GetComponent<EnemyStats>();
        agent = context.GetComponent<NavMeshAgent>();
        enemy = context.GetComponent<Enemy>();
        spawner = FindObjectOfType<WaveSpawner>();
        target = spawner.endPoint;
        playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();
    }

    public void Execute()
    {
        agent.SetDestination(target.position);
        FaceTarget();
        if (stats.fireCountdown <= 0f)
        {
            switch (stats.fireMode)
            {
                case FireMode.Semi:
                    Shoot();
                    break;
                case FireMode.Burst:
                    enemy.StartCoroutine(this.BurstShoot());
                    break;
            }
        }
        stats.fireCountdown -= Time.deltaTime;
    }

    private void FaceTarget()
    {
        context.transform.LookAt(playerStats.transform.position);
    }

    protected virtual void Shoot()
    {
        GameObject bulletGo = (GameObject)Object.Instantiate(Resources.Load("EnemyBullet", typeof(GameObject)), 
            context.transform.position, context.transform.rotation);
        //bulletGo.GetComponent<EnemyProjectile>().damage = stats.damage;
        //bulletGo.GetComponent<EnemyProjectile>().range = stats.range;
    }

    protected IEnumerator BurstShoot()
    {
        Shoot();
        yield return new WaitForSeconds(BURST_DELAY);
        Shoot();
        yield return new WaitForSeconds(BURST_DELAY);
        Shoot();
    }
    
}

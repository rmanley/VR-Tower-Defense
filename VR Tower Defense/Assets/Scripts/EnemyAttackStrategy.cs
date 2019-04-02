using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackStrategy : IStrategy
{
    protected const float BURST_DELAY = 0.15f;
    protected PlayerStats playerStats;
    protected GameObject context;
    protected WaveSpawner spawner;
    protected Transform target;
    protected NavMeshAgent agent;
    protected EnemyStats stats;
    protected Enemy enemy;

    public EnemyAttackStrategy(GameObject context)
    {
        this.context = context;
        stats = context.GetComponent<EnemyStats>();
        agent = context.GetComponent<NavMeshAgent>();
        enemy = context.GetComponent<Enemy>();
        spawner = Object.FindObjectOfType<WaveSpawner>();
        target = spawner.endPoint;
        playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();
    }

    public virtual void Execute()
    {
        agent.SetDestination(target.position);
        FaceTarget();
        float distance = Vector3.Distance(playerStats.transform.position, enemy.transform.position);

        if (distance <= stats.range && stats.fireCountdown <= 0f)
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
            stats.fireCountdown = 1f / stats.fireRate;
        }
        stats.fireCountdown -= Time.deltaTime;
    }

    protected void FaceTarget()
    {
        context.transform.LookAt(playerStats.transform.position);
    }

    protected virtual void Shoot()
    {
        foreach(Transform firePoint in enemy.firePoints)
        {
            GameObject bulletGo = Object.Instantiate(enemy.bulletPrefab, firePoint.position, firePoint.rotation);
            EnemyProjectile bullet = bulletGo.GetComponent<EnemyProjectile>();

            if (bullet != null)
                bullet.SetDamageAndRange(stats.damage, stats.range);
        }
        
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

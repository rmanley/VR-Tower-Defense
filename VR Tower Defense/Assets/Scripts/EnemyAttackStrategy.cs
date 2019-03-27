using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackStrategy : EnemyPassiveStrategy
{
    private const float BURST_DELAY = 0.15f;
    private PlayerStats playerStats;
    private Enemy context;

    public EnemyAttackStrategy(NavMeshAgent agent) : base(agent)
    {
        playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();
        context = agent.GetComponent<Enemy>();
    }

    public override void Execute()
    {
        base.Execute();
        FaceTarget();
        if (context.stats.fireCountdown <= 0f)
        {
            switch (context.stats.fireMode)
            {
                case FireMode.Semi:
                    Shoot();
                    break;
                case FireMode.Burst:
                    context.StartCoroutine(this.BurstShoot());
                    break;
            }
        }
        context.stats.fireCountdown -= Time.deltaTime;
    }

    private void FaceTarget()
    {
        agent.transform.LookAt(playerStats.transform.position);
    }

    protected virtual void Shoot()
    {
        GameObject bulletGo = (GameObject)Object.Instantiate(Resources.Load("EnemyBullet", typeof(GameObject)), 
            context.transform.position, context.transform.rotation);
        bulletGo.GetComponent<EnemyProjectile>().damage = context.stats.damage;
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

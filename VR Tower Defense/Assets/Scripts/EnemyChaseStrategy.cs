using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseStrategy : EnemyAttackStrategy
{
    public EnemyChaseStrategy(GameObject context) : base(context)
    { }

    public override void Execute()
    {
        agent.SetDestination(playerStats.transform.position); //chase player
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
}

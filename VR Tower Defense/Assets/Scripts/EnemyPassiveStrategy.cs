using UnityEngine;
using UnityEngine.AI;

public class EnemyPassiveStrategy : IStrategy
{
    protected WaveSpawner spawner;
    protected Transform target;
    protected NavMeshAgent agent;

    public EnemyPassiveStrategy(NavMeshAgent agent)
    {
        this.agent = agent;
        spawner = Object.FindObjectOfType<WaveSpawner>();
        target = spawner.endPoint;
    }

    public virtual void Execute()
    {
        agent.SetDestination(target.position);
    }
}

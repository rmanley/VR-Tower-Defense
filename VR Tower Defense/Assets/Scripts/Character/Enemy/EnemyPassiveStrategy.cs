using UnityEngine;
using UnityEngine.AI;

public class EnemyPassiveStrategy : IStrategy
{
    protected GameObject context;
    protected WaveSpawner spawner;
    protected Transform target;
    protected NavMeshAgent agent;

    public EnemyPassiveStrategy(GameObject context)
    {
        this.context = context;
        agent = context.GetComponent<NavMeshAgent>();
        spawner = Object.FindObjectOfType<WaveSpawner>();
        target = spawner.endPoint;
    }

    public virtual void Execute()
    {
        agent.SetDestination(target.position);
    }
}

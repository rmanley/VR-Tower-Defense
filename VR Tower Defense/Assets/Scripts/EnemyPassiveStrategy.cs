using UnityEngine;
using UnityEngine.AI;

public class EnemyPassiveStrategy : MonoBehaviour, IStrategy
{
    protected GameObject context;
    protected WaveSpawner spawner;
    protected Transform target;
    protected NavMeshAgent agent;

    private void Start()
    {
        context = GetComponentInParent<Enemy>().gameObject;
        agent = context.GetComponent<NavMeshAgent>();
        spawner = Object.FindObjectOfType<WaveSpawner>();
        target = spawner.endPoint;
    }

    public virtual void Execute()
    {
        agent.SetDestination(target.position);
    }
}

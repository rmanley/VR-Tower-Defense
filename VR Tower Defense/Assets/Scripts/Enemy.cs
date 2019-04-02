using System;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyStrategy
{
    Passive, Attack, Chase
}

[RequireComponent(typeof(CharacterStats))]
public class Enemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform[] firePoints;

    private IStrategy strategy;
    [SerializeField]
    private EnemyStrategy enemyStrategy;
    public EnemyStrategy Strategy
    {
        get { return enemyStrategy; }
        set { enemyStrategy = value; SetStrategy(); }
    }
    
    EnemyStats stats;
    CharacterStats playerStats;
    protected GameObject healthUI;

    //private Transform target;
    // private int wavepointIndex = 0;

    void Start()
    {
        stats = GetComponent<EnemyStats>();
        playerStats = PlayerManager.instance.player.GetComponent<CharacterStats>();
        healthUI = stats.healthBar.GetComponentInParent<Canvas>().gameObject;
        SetStrategy();
    }

    void Update()
    {
        healthUI.transform.LookAt(playerStats.transform.position);
        ExecuteStrategy();
    }

    public void ExecuteStrategy()
    {
        strategy.Execute();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "End")
        {
            playerStats.TakeDamage(stats.damage);
            Destroy(gameObject);
            return;
        }
    }

    //Adapted from: http://www.theappguruz.com/blog/learn-strategy-pattern-in-unity-in-less-than-15-minutes
    private void SetStrategy()
    {
        switch(enemyStrategy)
        {
            case EnemyStrategy.Passive:
                strategy = new EnemyPassiveStrategy(gameObject);
                break;
            case EnemyStrategy.Attack:
                strategy = new EnemyAttackStrategy(gameObject);
                break;
        }
    }

}

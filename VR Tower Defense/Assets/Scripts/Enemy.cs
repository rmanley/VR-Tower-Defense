using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : MonoBehaviour
{
    public IStrategy Strategy { get; set; }
    
    [HideInInspector]
    public EnemyStats stats;
    CharacterStats playerStats;
    protected GameObject healthUI;

    //private Transform target;
    // private int wavepointIndex = 0;

    void Start()
    {
        if (Strategy == null) Strategy = new EnemyPassiveStrategy(GetComponent<NavMeshAgent>());
        stats = GetComponent<EnemyStats>();
        playerStats = PlayerManager.instance.player.GetComponent<CharacterStats>();
        healthUI = stats.healthBar.GetComponentInParent<Canvas>().gameObject;
    }

    void Update()
    {
        healthUI.transform.LookAt(playerStats.transform.position);
        ExecuteStrategy();
    }

    public void ExecuteStrategy()
    {
        Strategy.Execute();
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
}

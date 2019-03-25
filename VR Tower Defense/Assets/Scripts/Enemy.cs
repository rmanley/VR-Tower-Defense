using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : MonoBehaviour
{
    WaveSpawner ws;
    EnemyStats stats;
    CharacterStats playerStats;
    private Transform target;
    public NavMeshAgent agent;

    //private Transform target;
   // private int wavepointIndex = 0;

    void Start()
    {
        ws = FindObjectOfType<WaveSpawner>();
        stats = GetComponent<EnemyStats>();
        playerStats = PlayerManager.instance.player.GetComponent<CharacterStats>();
        target = ws.endPoint;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        transform.LookAt(playerStats.transform.position);
        agent.SetDestination(target.position);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : MonoBehaviour
{
    EnemyStats stats;
    CharacterStats playerStats;

    private Transform target;
    private int wavepointIndex = 0;

    void Start()
    {
        stats = GetComponent<EnemyStats>();
        playerStats = PlayerManager.instance.player.GetComponent<CharacterStats>();
        target = Waypoints.points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * stats.speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if(wavepointIndex >= Waypoints.points.Length - 1)
        {
            //reduce player health when last waypoint is reached
            playerStats.TakeDamage(stats.damage);
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
}

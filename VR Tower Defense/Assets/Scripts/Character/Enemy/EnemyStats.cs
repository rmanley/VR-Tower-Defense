﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public int bounty = 10;
    public float speed = 10f;
    public float damage = 10f;

    public FireMode fireMode = FireMode.Semi;
    public float range = 20f;
    public float fireRate = 2f;
    [HideInInspector]
    public float fireCountdown = 0f;

    public GameObject deathEffect;

    protected override void Die()
    {
        base.Die();
        PlayerManager.instance.player.GetComponent<PlayerStats>().money += bounty;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2f);

        WaveSpawner.enemyCount--;
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public int bounty = 10;
    public float speed = 10f;
    public float damage = 10f;

    protected override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }
}

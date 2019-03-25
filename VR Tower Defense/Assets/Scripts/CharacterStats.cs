using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    public float maxHealth = 100f;
    [HideInInspector]
    public float health;

    public Image healthBar;

    void Start()
    {
        health = maxHealth;
    }
    
    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.fillAmount = health / maxHealth;

        if(health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        //Debug.Log(gameObject.name + " died!");
    }
}

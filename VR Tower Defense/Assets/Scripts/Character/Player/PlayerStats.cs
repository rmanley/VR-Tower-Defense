using UnityEngine;

public class PlayerStats : CharacterStats
{
    [HideInInspector]
    public int money;
    public int startMoney = 400;

    private bool isInvincible = false;

    void Awake()
    {
        money = startMoney;
    }

    //https://answers.unity.com/questions/478155/2d-when-player-gets-hit-make-invulnerable-for-a-fe.html @Xenofire
    private void OnCollisionEnter(Collision collision)
    {
        if(!isInvincible && collision.gameObject.tag == "Enemy")
        {
            isInvincible = true;
            TakeDamage(collision.gameObject.GetComponent<EnemyStats>().damage*10);
            Invoke("ResetInvincibility", 2f);   //Invincible for 2 seconds after running into an enemy.
        }
    }

    private void ResetInvincibility()
    {
        isInvincible = false;
    }

    protected override void Die()
    {
        //base.Die();
        //MessageManager.instance.DieMessage();
        PlayerManager.instance.KillPlayer();
    }
}

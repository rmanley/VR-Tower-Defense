using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public Text healthText;
    private PlayerStats playerStats;

    private void Awake()
    {
        playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "♥" + playerStats.health.ToString();
    }
}

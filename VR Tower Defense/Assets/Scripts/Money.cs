using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{

    public Text moneyText;
    private PlayerStats playerStats;

    private void Awake()
    {
        playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update () {
        moneyText.text = "$" + playerStats.money.ToString();
	}
}

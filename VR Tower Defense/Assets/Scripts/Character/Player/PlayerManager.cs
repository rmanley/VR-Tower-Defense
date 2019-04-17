using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion
    public static int levelscene;
    public GameObject player;   //update to point to player that's spawned

    private float countdown = 1f;

    private void Update()
    {
        if (countdown <= 0f)
        {
            player.GetComponent<CharacterStats>().TakeDamage(-1);
            countdown = 1f;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
    }

    public void KillPlayer()
    {
        levelscene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("GameOver");
    }
}

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

    public void KillPlayer()
    {
        levelscene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("GameOver");
    }
}

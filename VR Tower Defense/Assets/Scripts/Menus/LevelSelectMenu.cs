using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectMenu : MonoBehaviour
{
    public string L1 = "MainScene";
    public string L2 = "MainScene2";
    public float wait = 0.2f;
    private int select = 1;
    private bool canInput = true;
    private int[] menuItems = { 3, 4, 5 };

    private void Update()
    {
        int input = (int)Input.GetAxis("RJV");
        if (input != 0 && canInput)
        {
            canInput = false;
            StartCoroutine(MenuChange(input));
        }

        switch (select)
        {
            case 1:
                foreach (var i in menuItems)
                {
                    transform.GetChild(i).GetComponent<Image>().canvasRenderer.SetAlpha(0.75f);
                }
                transform.GetChild(3).GetComponent<Image>().canvasRenderer.SetAlpha(1);
                break;
            case 2:
                foreach (var i in menuItems)
                {
                    transform.GetChild(i).GetComponent<Image>().canvasRenderer.SetAlpha(0.75f);
                }
                transform.GetChild(4).GetComponent<Image>().canvasRenderer.SetAlpha(1);
                break;
            case 3:
                foreach (var i in menuItems)
                {
                    transform.GetChild(i).GetComponent<Image>().canvasRenderer.SetAlpha(0.75f);
                }
                transform.GetChild(5).GetComponent<Image>().canvasRenderer.SetAlpha(1);
                break;
        }

        if (Input.GetButtonDown("B"))
        {
            switch (select)
            {
                case 1: Level1(); break;
                case 2: Level2(); break;
                case 3: Back(); break;
            }
        }
    }

    IEnumerator MenuChange(int input)
    {
        if (input < 0 && select > 1)
            select--;
        else if (input > 0 && select < 3)
            select++;

        yield return new WaitForSecondsRealtime(wait);
        canInput = true;
    }

    public void Level1()
    {
        WaveSpawner.waveIndex = 0;
        SceneManager.LoadScene(L1);
    }

    public void Level2()
    {
        WaveSpawner.waveIndex = 0;
        SceneManager.LoadScene(L2);
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string mainMenu = "MainMenu";
    public float wait = 0.2f;
    private int select = 1;
    private bool canInput = true;
    private int[] menuItems = { 2, 3, 4 };

    public static bool paused = false;
    public static bool instructions = false;

    private void Awake()
    {
        paused = false;
        instructions = false;
        Time.timeScale = 1;
        for (int i = 0; i < 5; i++)
        {
            transform.GetChild(i).gameObject.SetActive(paused);
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            if(!paused || !instructions) Resume();
        }

        if (paused && !instructions)
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
                    transform.GetChild(2).GetComponent<Image>().canvasRenderer.SetAlpha(1);
                    break;
                case 2:
                    foreach (var i in menuItems)
                    {
                        transform.GetChild(i).GetComponent<Image>().canvasRenderer.SetAlpha(0.75f);
                    }
                    transform.GetChild(3).GetComponent<Image>().canvasRenderer.SetAlpha(1);
                    break;
                case 3:
                    foreach (var i in menuItems)
                    {
                        transform.GetChild(i).GetComponent<Image>().canvasRenderer.SetAlpha(0.75f);
                    }
                    transform.GetChild(4).GetComponent<Image>().canvasRenderer.SetAlpha(1);
                    break;
            }

            if (Input.GetButtonDown("B"))
            {
                switch (select)
                {
                    case 1: Resume(); break;
                    case 2: Instructions(); break;
                    case 3: MainMenu(); break;
                }
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

    public void Resume()
    {
        paused = !paused;
        for (int i = 0; i < 5; i++)
        {
            transform.GetChild(i).gameObject.SetActive(paused);
        }
        if (paused)
        {
            Time.timeScale = 0;
        }
        else
            Time.timeScale = 1;
    }

    public void Instructions()
    {
        transform.GetChild(5).gameObject.SetActive(true);
        instructions = true;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string LevelSelectMenu = "LevelSelectMenu";
    public string instructionsScene = "InstructionsScene";
    public float wait = 0.2f;
    private int select = 1;
    private bool canInput = true;
    private int[] menuItems = { 3, 4, 5 };

    private void Update()
    {
        if (!PauseMenu.instructions)
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
                    case 1: Play(); break;
                    case 2: Instructions(); break;
                    case 3: Exit(); break;
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

    public void Play()
    {
        Shop.shopOpen = false;
        SceneManager.LoadScene(LevelSelectMenu);
    }

    public void Instructions()
    {
        transform.GetChild(6).gameObject.SetActive(true);
        PauseMenu.instructions = true;
    }

    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InstructionsMenu: MonoBehaviour
{
    //public string mainMenu = "MainMenu";

    private void Update()
    {
        if (Input.GetButtonDown("B"))
        {
            Back();
        }
    }

    public void Back()
    {
        PauseMenu.instructions = false;
        gameObject.SetActive(false);
    }
}

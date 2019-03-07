using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour
{
    #region Singleton
    public static MessageManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public Text messageText;

    public void DieMessage()
    {
        messageText.enabled = true;
        messageText.text = "YOU DIED!";
        Invoke("DisableMessage", 2f);
    }

    public void MoneyMessage()
    {
        messageText.enabled = true;
        messageText.text = "NOT ENOUGH MONEY!";
        Invoke("DisableMessage", 0.5f);
    }

    public void DisableMessage()
    {
        messageText.enabled = false;
    }

    public void DebugMessage(string message)
    {
        messageText.enabled = true;
        messageText.text = message;
        Invoke("DisableMessage", 0.5f);
    }
}

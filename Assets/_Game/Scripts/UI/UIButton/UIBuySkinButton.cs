using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBuySkinButton : MonoBehaviour
{
    [SerializeField] private SkinID buttonID;
    [SerializeField] private GameObject thisButton;
    [SerializeField] private Text thisText;

    public SkinID GetButtonID()
    {
        return buttonID;
    }

    public void ChangeText(string newText)
    {
        thisText.text = newText;
    }

    public void EnableButton()
    {
        thisButton.SetActive(true);
    }

    public void DisableButton()
    {
        thisButton.SetActive(false);
    }
}

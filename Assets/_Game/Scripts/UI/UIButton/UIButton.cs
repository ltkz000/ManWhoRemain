using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    public GameObject thisButton;
    public Text thisText;

    public void changeText(string newText)
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

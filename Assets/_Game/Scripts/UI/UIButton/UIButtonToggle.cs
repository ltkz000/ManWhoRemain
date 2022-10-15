using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonToggle : MonoBehaviour
{
    public bool state = true;
    public Image OnImage;
    public Image OffImage;
    public Text OnText;
    public Text OffText;

    private void Start() 
    {
        if(state)
        {
            ButtonOn();
        }
        else
        {
            ButtonOff();
        }
    }

    public void ButtonOn()
    {
        OnImage.gameObject.SetActive(true);
        OnText.gameObject.SetActive(true);

        OffImage.gameObject.SetActive(false);
        OffText.gameObject.SetActive(false);
    }

    public void ButtonOff()
    {
        OnImage.gameObject.SetActive(false);
        OnText.gameObject.SetActive(false);

        OffImage.gameObject.SetActive(true);
        OffText.gameObject.SetActive(true);
    }

    public bool GetState()
    {
        return state;
    }

    public void ChangeState()
    {
        if(state == true)
        {
            state = false;
        }
        else
        {
            state = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class ButtonState
{
    public bool state = true;
    public Image stateImage;
    public Text stateText;

    public void ButtonOn()
    {
        stateImage.gameObject.SetActive(true);
        stateText.gameObject.SetActive(true);
    }

    public void ButtonOff()
    {
        stateImage.gameObject.SetActive(false);
        stateText.gameObject.SetActive(false);
    }

    public void ChangeState(bool newState)
    {
        state = newState;
    }
}

public class CanvasSetting : UICanvas
{
    [SerializeField] UIButtonToggle soundButton;
    [SerializeField] UIButtonToggle vibrationButton;

    protected override void OnOpenCanvas()
    {
        base.OnOpenCanvas();
        Time.timeScale = 0;
    }

    public void HomeButton()
    {
        // PlayerDataManager.Ins.GetCharacterCombat().Revive();
        GameManager.Ins.BackToMainMenu();
        UIManager.Ins.OpenUI(UICanvasID.MainMenu);

        SoundManager.Ins.PlayButtonClickSound();

        Close();
    }

    public void ResumeButton()
    {
        UIManager.Ins.OpenUI(UICanvasID.GamePlay);

        SoundManager.Ins.PlayButtonClickSound();

        Close();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        SoundManager.Ins.PlayButtonClickSound();

        Close();
    }

    public void SettingSoundButton()
    {
        soundButton.ChangeState();

        if(soundButton.GetState())
        {
            soundButton.ButtonOn();

            SoundManager.Ins.TurnOnSound();
        }
        else
        {
            soundButton.ButtonOff();

            SoundManager.Ins.TurnOffSound();
        }

        SoundManager.Ins.PlayButtonClickSound();
    }

    public void SettingVibrationButton()
    {
        vibrationButton.ChangeState();

        if(vibrationButton.GetState())
        {
            vibrationButton.ButtonOn();
        }
        else
        {
            vibrationButton.ButtonOff();
        }

        SoundManager.Ins.PlayButtonClickSound();
    }

    protected override void OnCloseCanvas()
    {
        base.OnCloseCanvas();
        Time.timeScale = 1;
    }
}

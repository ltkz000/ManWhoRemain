using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasVictory : UICanvas
{
    public Text resultText;

    protected override void OnOpenCanvas()
    {
        base.OnOpenCanvas();
        
        UIManager.Ins.CloseUI(UICanvasID.GamePlay);

        Time.timeScale = 0;
    }

    public void NextButton()
    {
        UIManager.Ins.OpenUI(UICanvasID.GamePlay);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        GameManager.Ins.ChangeState(GameState.GamePlay);

        SoundManager.Ins.PlayButtonClickSound();

        Close();
    }

    public void HomeButton()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);

        SoundManager.Ins.PlayButtonClickSound();

        Close();
    }

    protected override void OnCloseCanvas()
    {
        base.OnCloseCanvas();
    }
}

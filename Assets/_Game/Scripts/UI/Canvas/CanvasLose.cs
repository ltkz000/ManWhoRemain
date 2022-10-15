using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasLose : UICanvas
{
    [SerializeField] private Text topText;
    protected override void OnOpenCanvas()
    {
        base.OnOpenCanvas();

        // Time.timeScale = 0;

        topText.text = "#" + (BotManager.Ins.GetBotAlive() + 1).ToString();
    }

    public void ContinueButton()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);

        SoundManager.Ins.PlayButtonClickSound();

        Close();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        SoundManager.Ins.PlayButtonClickSound();
    }

    protected override void OnCloseCanvas()
    {
        base.OnCloseCanvas();
    }
}

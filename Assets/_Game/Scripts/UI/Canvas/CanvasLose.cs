using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasLose : UICanvas
{
    [SerializeField] private CharacterCombat player;
    [SerializeField] private Text topText;
    protected override void OnOpenCanvas()
    {
        base.OnOpenCanvas();

        topText.text = "#" + (BotManager.Ins.GetBotAlive() + 1).ToString();
    }

    public void ContinueButton()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
        // UIManager.Ins.OpenUI(UICanvasID.MainMenu);

        SoundManager.Ins.PlayButtonClickSound();

        Close();
    }

    public void RestartButton()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // UIManager.Ins.OpenUI(UICanvasID.MainMenu);
        player.Revive();
        BotManager.Ins.Restart();

        SoundManager.Ins.PlayButtonClickSound();
    }

    protected override void OnCloseCanvas()
    {
        base.OnCloseCanvas();
    }
}

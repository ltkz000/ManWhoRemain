using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasLose : UICanvas
{
    [SerializeField] private Text topText;
    [SerializeField] private Text goldText;
    protected override void OnOpenCanvas()
    {
        base.OnOpenCanvas();

        // Time.timeScale = 0;
        GameManager.Ins.ChangeState(GameState.Pause);
        topText.text = "#" + (BotManager.Ins.GetBotAlive() + 1).ToString();
        goldText.text = PlayerDataManager.Ins.GetCharacterCombat().GetMapGold().ToString();
    }

    public void ContinueButton()
    {
        GameManager.Ins.BackToMainMenu();
        UIManager.Ins.OpenUI(UICanvasID.MainMenu);

        SoundManager.Ins.PlayButtonClickSound();

        Close();
    }

    protected override void OnCloseCanvas()
    {
        base.OnCloseCanvas();
        // Time.timeScale = 1;
    }
}

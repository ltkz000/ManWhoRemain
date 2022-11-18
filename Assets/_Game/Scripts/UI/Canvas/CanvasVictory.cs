using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.AI;

public class CanvasVictory : UICanvas
{
    protected override void OnOpenCanvas()
    {
        base.OnOpenCanvas();
        // Time.timeScale = 0;
        
        GameManager.Ins.ChangeState(GameState.Pause);
        LevelManager.Ins.CloseMap(PlayerDataManager.Ins.GetPlayerLevel());
        PlayerDataManager.Ins.ChangePlayerLevel();
        UIManager.Ins.CloseUI(UICanvasID.GamePlay);
    }

    public void HomeButton()
    {
        // PlayerDataManager.Ins.GetCharacterCombat().Revive();
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

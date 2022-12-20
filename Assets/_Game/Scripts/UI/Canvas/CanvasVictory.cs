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
        
        GameManager.Ins.ChangeState(GameState.Pause);
        LevelManager.Ins.CloseMap(PlayerDataManager.Ins.GetPlayerLevel());
        PlayerDataManager.Ins.ChangePlayerLevel();
        PlayerDataManager.Ins.GetCharacterCombat().capsuleCollider.enabled = false;
        UIManager.Ins.CloseUI(UICanvasID.GamePlay);
    }

    public void HomeButton()
    {
        GameManager.Ins.BackToMainMenu();
        UIManager.Ins.OpenUI(UICanvasID.MainMenu);

        SoundManager.Ins.PlayButtonClickSound();

        Close();
    }

    protected override void OnCloseCanvas()
    {
        base.OnCloseCanvas();
    }
}

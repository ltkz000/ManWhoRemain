using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasSkinShop : UICanvas
{
    protected override void OnOpenCanvas()
    {
        base.OnOpenCanvas();
        GameManager.Ins.ChangeState(GameState.SkinShop);
    }

    public void CloseButton()
    {
        UIManager.Ins.OpenUI(UICanvasID.MainMenu);

        SoundManager.Ins.PlayButtonClickSound();
        
        Close();
    }

    protected override void OnCloseCanvas()
    {
        base.OnCloseCanvas();
        GameManager.Ins.ChangeState(GameState.MainMenu);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasMainMenu : UICanvas
{
    public Text goldText;

    public void PlayButton()
    {
        
        UIManager.Ins.OpenUI(UICanvasID.GamePlay);
        GameManager.Ins.currentgameState = GameState.GamePlay;

        Close();
    }

    public void Update()
    {
        UpdateGold();
    }

    public void UpdateGold()
    {
        goldText.text = PlayerDataManager.Ins.GetPlayerGold().ToString();
    }

    public void OpenWeaponShopButton()
    {
        UIManager.Ins.OpenUI(UICanvasID.WeaponShop);

        Close();
    }

    public void OpenSkinShopButton()
    {

    }
}

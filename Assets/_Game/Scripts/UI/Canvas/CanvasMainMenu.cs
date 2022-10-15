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
        
        SoundManager.Ins.PlayButtonClickSound();

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

        SoundManager.Ins.PlayButtonClickSound();

        Close();
    }

    public void OpenSkinShopButton()
    {

    }
}

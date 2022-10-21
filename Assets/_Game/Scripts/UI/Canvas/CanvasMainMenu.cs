using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasMainMenu : UICanvas
{
    [SerializeField] private Text goldText;
    [SerializeField] private UIButton changNameButton;

    protected override void OnOpenCanvas()
    {
        base.OnOpenCanvas();
        UpdateGold();
        ChangeNameText();

        GameManager.Ins.ChangeState(GameState.MainMenu);
    }

    public void PlayButton()
    {
        UIManager.Ins.OpenUI(UICanvasID.GamePlay);

        GameManager.Ins.currentgameState = GameState.GamePlay;
        
        SoundManager.Ins.PlayButtonClickSound();

        Close();
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
        UIManager.Ins.OpenUI(UICanvasID.SkinShop);

        SoundManager.Ins.PlayButtonClickSound();

        Close();
    }

    private void ChangeNameText()
    {
        changNameButton.changeText(PlayerDataManager.Ins.GetPlayerName());
    }
}

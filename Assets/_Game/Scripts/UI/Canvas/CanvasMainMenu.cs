using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasMainMenu : UICanvas
{
    [SerializeField] private Text goldText;
    [SerializeField] private Text nameHolder;
    [SerializeField] private InputField inputField;

    [SerializeField] private CharacterCombat characterCombat;

    protected override void OnOpenCanvas()
    {
        base.OnOpenCanvas();
        characterCombat.Revive();
        characterCombat.DeactiveNameText();
        UpdateGold();
        UpdateName();

        // BotManager.Ins.OnMainMenu();
        GameManager.Ins.ChangeState(GameState.MainMenu);
        GameManager.Ins.OpenGameLevel(PlayerDataManager.Ins.GetPlayerLevel());
    }

    public void PlayButton()
    {
        UIManager.Ins.OpenUI(UICanvasID.GamePlay);

        GameManager.Ins.currentgameState = GameState.GamePlay;
        // GameManager.Ins.OpenGameLevel(PlayerDataManager.Ins.GetPlayerLevel());
        
        SoundManager.Ins.PlayButtonClickSound();

        Close();
    }

    public void UpdateGold()
    {
        goldText.text = PlayerDataManager.Ins.GetPlayerGold().ToString();
    }

    public void UpdateName()
    {
        nameHolder.text = PlayerDataManager.Ins.GetPlayerName();
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

    public void ChangeNameData()
    {
        PlayerDataManager.Ins.ChangePlayerName(inputField.text);
    }
}

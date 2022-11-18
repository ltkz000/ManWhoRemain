using UnityEngine;
using UnityEngine.UI;
using UnityEditor.AI;
using TMPro;

public class CanvasMainMenu : UICanvas
{
    [SerializeField] private Text goldText;
    [SerializeField] private Text nameHolder;
    [SerializeField] private InputField inputField;

    protected override void OnOpenCanvas()
    {
        base.OnOpenCanvas();
        PlayerDataManager.Ins.GetCharacterCombat().DeactiveNameText();
        UpdateGold();
        UpdateName();

        GameManager.Ins.ChangeState(GameState.MainMenu);
        if(PlayerDataManager.Ins.GetPlayerLevel() > 0)
        {
            LevelManager.Ins.CloseMap(PlayerDataManager.Ins.GetPlayerLevel() - 1);
        }
        LevelManager.Ins.OpenMap(PlayerDataManager.Ins.GetPlayerLevel());
        NavMeshBuilder.BuildNavMesh();
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
        if(inputField.text != "")
        {
            PlayerDataManager.Ins.ChangePlayerName(inputField.text);
        }
    }
}

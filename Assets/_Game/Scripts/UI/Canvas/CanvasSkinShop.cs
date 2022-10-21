using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasSkinShop : UICanvas
{
    [SerializeField] private CharacterCombat characterCombat;
    [SerializeField] private PlayerSkinControll playerSkinControll;
    [SerializeField] private Text goldText;
    [SerializeField] private List<UITypeButton> UITypeButtonList;
    [SerializeField] private List<UISkinField> UISkinFieldList;
    [SerializeField] private UIButton selectButton;
    [SerializeField] private UIButton buyButton;


    //Function Variables
    [SerializeField] private SkinID currentFieldID;
    [SerializeField] private GameObject topSkin;
    [SerializeField] private GameObject leftHandSkin;

    protected override void OnOpenCanvas()
    {
        base.OnOpenCanvas();

        selectButton.thisButton.SetActive(false);
        buyButton.thisButton.SetActive(false);

        currentFieldID = SkinID.Top;

        characterCombat.characterWeaponScript.DisappearOnHand();

        GameManager.Ins.ChangeState(GameState.SkinShop);

        UpdateGold();
        CheckButtonIsChoose();
        CheckSkinFieldIsChoose();
    }

    public void UpdateGold()
    {
        goldText.text = PlayerDataManager.Ins.GetPlayerGold().ToString();
    }

    public void CheckButtonIsChoose()
    {
        for(int i = 0; i < UITypeButtonList.Count; i++)
        {
            if(UITypeButtonList[i].GetButtonID() == currentFieldID)
            {
                UITypeButtonList[i].ChoosenOne();
            }
            else
            {
                UITypeButtonList[i].NotChoosenOne();
            }
        }
    }

    public void CheckSkinFieldIsChoose()
    {
        for(int i = 0; i < UISkinFieldList.Count; i++)
        {
            if(UISkinFieldList[i].GetFieldID() == currentFieldID)
            {
                UISkinFieldList[i].ActiveField();
            }
            else
            {
                UISkinFieldList[i].DeactiveField();
            }
        }
    }

    public void CheckButtonToShow(TopType type)
    {   
        if(SkinDataManager.Ins.CheckIsLock(type) == true)
        {
            buyButton.EnableButton();
            selectButton.DisableButton();
            ChangePriceButton(SkinDataManager.Ins.GetPrice(type));
        }
        else
        {
            buyButton.DisableButton();
            selectButton.EnableButton();
        }
    }
    public void CheckButtonToShow(PantType type)
    {   
        if(SkinDataManager.Ins.CheckIsLock(type) == true)
        {
            buyButton.EnableButton();
            selectButton.DisableButton();
            ChangePriceButton(SkinDataManager.Ins.GetPrice(type));
        }
        else
        {
            buyButton.DisableButton();
            selectButton.EnableButton();
        }
    }
    public void CheckButtonToShow(ShieldType type)
    {   
        if(SkinDataManager.Ins.CheckIsLock(type) == true)
        {
            buyButton.EnableButton();
            selectButton.DisableButton();
            ChangePriceButton(SkinDataManager.Ins.GetPrice(type));
        }
        else
        {
            buyButton.DisableButton();
            selectButton.EnableButton();
        }
    }
    public void CheckButtonToShow(SetType type)
    {   
        if(SkinDataManager.Ins.CheckIsLock(type) == true)
        {
            buyButton.EnableButton();
            selectButton.DisableButton();
            ChangePriceButton(SkinDataManager.Ins.GetPrice(type));
        }
        else
        {
            buyButton.DisableButton();
            selectButton.EnableButton();
        }
    }

    public void ChangePriceButton(int price)
    {
        buyButton.thisText.text = price.ToString();
    }

    public void ActiveTopSKin()
    {
        if(topSkin != null)
        {
            topSkin.SetActive(true);
        }
    }

    public void ActiveLeftHand()
    {
        if(leftHandSkin != null)
        {
            leftHandSkin.SetActive(true);
        }
    }

    public void DeactiveTopSKin()
    {
        if(topSkin != null)
        {
            topSkin.SetActive(false);
        }
    }

    public void DeactiveLeftHand()
    {
        if(leftHandSkin != null)
        {
            leftHandSkin.SetActive(false);
        }
    }


    //Shop Button Function
    public void CloseButton()
    {
        UIManager.Ins.OpenUI(UICanvasID.MainMenu);

        SoundManager.Ins.PlayButtonClickSound();
        
        Close();
    }

    public void PreviewTopButton(UIChooseTop uIChooseTop)
    {
        DeactiveTopSKin();

        playerSkinControll.ShowPreviewTop(uIChooseTop.GetSkinType());

        topSkin = playerSkinControll.GetTop(uIChooseTop.GetSkinType());
        ActiveTopSKin();

        CheckButtonToShow(uIChooseTop.GetSkinType());
        SoundManager.Ins.PlayButtonClickSound();
    }

    public void PreviewPantButton(UIChoosePant uIChoosePant)
    {   
        playerSkinControll.ShowPreviewPant(uIChoosePant.GetSkinType());

        CheckButtonToShow(uIChoosePant.GetSkinType());
        SoundManager.Ins.PlayButtonClickSound();
    }

    public void PreviewShieldButton(UIChooseShield uIChooseShield)
    {
        DeactiveLeftHand();

        playerSkinControll.ShowPreviewShield(uIChooseShield.GetSkinType());

        leftHandSkin = playerSkinControll.GetLeftHandShield(uIChooseShield.GetSkinType());
        ActiveLeftHand();

        CheckButtonToShow(uIChooseShield.GetSkinType());
        SoundManager.Ins.PlayButtonClickSound();
    }

    public void PreviewSetButton(UIChooseSet uIChooseSet)
    {
        DeactiveTopSKin();
        DeactiveLeftHand();

        playerSkinControll.ShowPreviewSet(uIChooseSet.GetSkinType());

        topSkin = playerSkinControll.GetTopSet(uIChooseSet.GetSkinType());
        leftHandSkin = playerSkinControll.GetLeftHandSet(uIChooseSet.GetSkinType());
        ActiveTopSKin();
        ActiveLeftHand();

        CheckButtonToShow(uIChooseSet.GetSkinType());
        SoundManager.Ins.PlayButtonClickSound();
    }

    public void ChooseTypeButton(UITypeButton uITypeButton)
    {
        currentFieldID = uITypeButton.GetButtonID();

        CheckButtonIsChoose();
        CheckSkinFieldIsChoose();
        SoundManager.Ins.PlayButtonClickSound();
    }

    public void SelectButton()
    {

    }

    public void BuyButton()
    {
        
    }

    protected override void OnCloseCanvas()
    {
        base.OnCloseCanvas();
        characterCombat.characterWeaponScript.AppearOnHand();
        GameManager.Ins.ChangeState(GameState.MainMenu);
    }
}

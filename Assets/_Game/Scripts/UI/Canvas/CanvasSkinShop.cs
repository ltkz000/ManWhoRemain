using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class FunctionButton
{
    [SerializeField] private SkinID buttonID;
    [SerializeField] private UIButton uIButton;

    public SkinID GetButtonID()
    {
        return buttonID;
    }

    public UIButton GetUIButton()
    {
        return uIButton;
    }
}


public class CanvasSkinShop : UICanvas
{
    [SerializeField] private CharacterCombat characterCombat;
    [SerializeField] private PlayerSkinControll playerSkinControll;
    [SerializeField] private Text goldText;
    [SerializeField] private List<UITypeButton> UITypeButtonList;
    [SerializeField] private List<UISkinField> UISkinFieldList;
    [SerializeField, NonReorderable] private List<FunctionButton> buyButtonList;
    [SerializeField, NonReorderable] private List<FunctionButton> selectButtonList;
    [SerializeField, NonReorderable] private List<FunctionButton> unequipButtonList;
    private FunctionButton currentBuyButton;
    private FunctionButton currentSelectButton;
    private FunctionButton currentUnequipButton;

    //Function Variables
    [SerializeField] private SkinID currentFieldID;
    private UIChooseTop chooseTopButton;
    private UIChoosePant choosePantButton;
    private UIChooseShield chooseShieldButton;
    private UIChooseSet chooseSetButton;

    //PreviewSkin
    [SerializeField] private GameObject previewTopSkin;
    [SerializeField] private Material previewPantMaterial;
    [SerializeField] private GameObject previewShieldSkin;
    [SerializeField] private SetRef previewSetRef;

    //SKinType
    private TopType currentTopType;
    private PantType currentPantType;
    private ShieldType currentShieldType;
    private SetType currentSetType;

    protected override void OnOpenCanvas()
    {
        base.OnOpenCanvas();
        previewTopSkin = playerSkinControll.GetTopSkin();
        previewPantMaterial = playerSkinControll.GetPantMaterial();
        previewShieldSkin = playerSkinControll.GetShieldSkin();
        previewSetRef = playerSkinControll.GetSetRef();

        playerSkinControll.DeactiveActualSkin();
        playerSkinControll.DeactiveSetSkin();
        if(previewSetRef.GetSetType() != SetType.None)
        {
            DeactivePreviewSkin();
            ActivePreviewSet();
        }
        else
        {
            ActivePreviewSkin();
        }

        currentFieldID = SkinID.Top;

        characterCombat.characterWeaponScript.DisappearOnHand();

        GameManager.Ins.ChangeState(GameState.SkinShop);

        UpdateGold();
        CheckButtonIsChoose();
        CheckSkinFieldIsChoose();
        CheckBuyButtonToShow();
        DeactiveAllButton();
    }

    public void UpdateGold()
    {
        goldText.text = PlayerDataManager.Ins.GetPlayerGold().ToString();
    }

    public void DeactiveAllButton()
    {
        for(int i = 0; i < buyButtonList.Count; i++)
        {
            buyButtonList[i].GetUIButton().DisableButton();
            selectButtonList[i].GetUIButton().DisableButton();
            unequipButtonList[i].GetUIButton().DisableButton();
        }
    }

    public void CheckBuyButtonToShow()
    {
        for(int i = 0; i < buyButtonList.Count; i++)
        {
            if(buyButtonList[i].GetButtonID() == currentFieldID)
            {
                currentBuyButton = buyButtonList[i];
                currentSelectButton = selectButtonList[i];
                currentUnequipButton = unequipButtonList[i];
            }
        }
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

    public void EnableBuyButton()
    {
        currentBuyButton.GetUIButton().EnableButton();
        currentSelectButton.GetUIButton().DisableButton();
        currentUnequipButton.GetUIButton().DisableButton();
    }

    public void EnableSelectButton()
    {
        currentBuyButton.GetUIButton().DisableButton();
        currentSelectButton.GetUIButton().EnableButton();
        currentUnequipButton.GetUIButton().DisableButton();
    }

    public void EnableUnequipButton()
    {
        currentBuyButton.GetUIButton().DisableButton();
        currentSelectButton.GetUIButton().DisableButton();
        currentUnequipButton.GetUIButton().EnableButton();
    }

    public void CheckButtonToShow(TopType type)
    {   
        if(SkinDataManager.Ins.CheckIsLock(type) == true)
        {
            EnableBuyButton();
            ChangePriceButton(SkinDataManager.Ins.GetPrice(type));
        }
        else
        {
            EnableSelectButton();
        }

        if(type == PlayerDataManager.Ins.GetPlayerTopID())
        {
            EnableUnequipButton();
        }
    }
    public void CheckButtonToShow(PantType type)
    {   
        if(SkinDataManager.Ins.CheckIsLock(type) == true)
        {
            EnableBuyButton();
            ChangePriceButton(SkinDataManager.Ins.GetPrice(type));
        }
        else
        {
            EnableSelectButton();
        }

        if(type == PlayerDataManager.Ins.GetPlayerPantID())
        {
            EnableUnequipButton();
        }
    }
    public void CheckButtonToShow(ShieldType type)
    {   
        if(SkinDataManager.Ins.CheckIsLock(type) == true)
        {
            EnableBuyButton();
            ChangePriceButton(SkinDataManager.Ins.GetPrice(type));
        }
        else
        {
            EnableSelectButton();
        }

        if(type == PlayerDataManager.Ins.GetPlayerShieldID())
        {
            EnableUnequipButton();
        }
    }
    public void CheckButtonToShow(SetType type)
    {   
        if(SkinDataManager.Ins.CheckIsLock(type) == true)
        {
            EnableBuyButton();
            ChangePriceButton(SkinDataManager.Ins.GetPrice(type));
        }
        else
        {
            EnableSelectButton();
        }

        if(type == PlayerDataManager.Ins.GetPlayerSetID())
        {
            EnableUnequipButton();
        }
    }

    public void ChangePriceButton(int price)
    {
        currentBuyButton.GetUIButton().changeText(price.ToString());
    }

    //Active-Deactive Top
    public void ActivePreviewTopSKin()
    {
        if(previewTopSkin != null)
        {
            previewTopSkin.SetActive(true);
        }
    }

    public void DeactivePreviewTopSKin()
    {
        if(previewTopSkin != null)
        {
            previewTopSkin.SetActive(false);
        }
    }

    //Active-Deactive Shield
    public void ActivePreviewShield()
    {
        if(previewShieldSkin != null)
        {
            previewShieldSkin.SetActive(true);
        }
    }

    public void DeactivePreviewShield()
    {
        if(previewShieldSkin != null)
        {
            previewShieldSkin.SetActive(false);
        }
    }

    //Active-Deactive Set
    public void ActivePreviewSet()
    {
        previewSetRef.ActiveSet();
        playerSkinControll.PreviewSet(previewSetRef.GetSetMaterial());
    }

    public void DeactivePreviewSet()
    {
        previewSetRef.DeactiveSet();
        playerSkinControll.PreviewNotSet();
    }

    //Active-Deactive Skin
    public void ActivePreviewSkin()
    {
        ActivePreviewTopSKin();
        ActivePreviewShield();
    }

    public void DeactivePreviewSkin()
    {
        DeactivePreviewTopSKin();
        DeactivePreviewShield();
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
        DeactivePreviewTopSKin();
        DeactivePreviewSet();

        currentTopType = uIChooseTop.GetSkinType();
        previewTopSkin = playerSkinControll.GetPreviewTop(currentTopType);

        ActivePreviewTopSKin();

        CheckButtonToShow(uIChooseTop.GetSkinType());
        SoundManager.Ins.PlayButtonClickSound();
    }

    public void PreviewPantButton(UIChoosePant uIChoosePant)
    {   
        currentPantType = uIChoosePant.GetSkinType();
        previewPantMaterial = playerSkinControll.GetPreviewPant(currentPantType);
        playerSkinControll.PreviewPant(previewPantMaterial);

        CheckButtonToShow(uIChoosePant.GetSkinType());
        SoundManager.Ins.PlayButtonClickSound();
    }

    public void PreviewShieldButton(UIChooseShield uIChooseShield)
    {
        DeactivePreviewShield();
        DeactivePreviewSet();

        currentShieldType = uIChooseShield.GetSkinType();
        previewShieldSkin = playerSkinControll.GetPreviewLeftHand(currentShieldType);

        ActivePreviewShield();

        CheckButtonToShow(uIChooseShield.GetSkinType());
        SoundManager.Ins.PlayButtonClickSound();
    }

    public void PreviewSetButton(UIChooseSet uIChooseSet)
    {
        DeactivePreviewSkin();
        DeactivePreviewSet();

        currentSetType = uIChooseSet.GetSkinType();
        previewSetRef = playerSkinControll.GetPreviewSet(currentSetType);

        ActivePreviewSet();

        CheckButtonToShow(uIChooseSet.GetSkinType());
        SoundManager.Ins.PlayButtonClickSound();
    }

    public void ChooseTypeButton(UITypeButton uITypeButton)
    {
        currentFieldID = uITypeButton.GetButtonID();

        CheckButtonIsChoose();
        CheckSkinFieldIsChoose();
        CheckBuyButtonToShow();
        DeactiveAllButton();
        SoundManager.Ins.PlayButtonClickSound();
    }

    public void SelectTopButton()
    {
        playerSkinControll.ChangeTopSkin(previewTopSkin, currentTopType);
        playerSkinControll.ChangeSetSkin(SetType.None);

        CheckButtonToShow(currentTopType);
        SoundManager.Ins.PlayButtonClickSound();
    }

    public void SelectPantButton()
    {
        playerSkinControll.ChangePantMaterial(previewPantMaterial, currentPantType);

        CheckButtonToShow(currentPantType);
        SoundManager.Ins.PlayButtonClickSound();
    }

    public void SelectSheildButton()
    {
        playerSkinControll.ChangeShieldSkin(previewShieldSkin, currentShieldType);
        playerSkinControll.ChangeSetSkin(SetType.None);

        CheckButtonToShow(currentShieldType);
        SoundManager.Ins.PlayButtonClickSound();
    }

    public void SelectSetButton()
    {
        playerSkinControll.ChangeTopSkin(null, TopType.None);
        playerSkinControll.ChangeShieldSkin(null, ShieldType.None);
        playerSkinControll.ChangeSetSkin(currentSetType);

        CheckButtonToShow(currentSetType);
        SoundManager.Ins.PlayButtonClickSound();
    }

    public void UnequipTopButton()
    {
        DeactivePreviewTopSKin();
        playerSkinControll.ChangeTopSkin(null, TopType.None);

        CheckButtonToShow(currentTopType);
        SoundManager.Ins.PlayButtonClickSound();
    }
    public void UnequipPantButton()
    {
        playerSkinControll.UnequipPant();
        playerSkinControll.ChangePantMaterial(null, PantType.None);

        CheckButtonToShow(currentPantType);
        SoundManager.Ins.PlayButtonClickSound();
    }
    public void UnequipShieldButton()
    {
        DeactivePreviewShield();
        playerSkinControll.ChangeShieldSkin(null, ShieldType.None);

        CheckButtonToShow(currentShieldType);
        SoundManager.Ins.PlayButtonClickSound();
    }
    public void UnequipSetButton()
    {
        DeactivePreviewSet();
        playerSkinControll.ChangeSetSkin(SetType.None);

        CheckButtonToShow(currentSetType);
        SoundManager.Ins.PlayButtonClickSound();
    }

    public void BuyTopButton()
    {
        if(PlayerDataManager.Ins.GetPlayerGold() < SkinDataManager.Ins.GetPrice(currentTopType))
        {
            currentBuyButton.GetUIButton().DisableButton();
        }
        else
        {
            PlayerDataManager.Ins.ChangePlayerGold(SkinDataManager.Ins.GetPrice(currentTopType));
            SkinDataManager.Ins.UnlockSkin(currentTopType);

            UpdateGold();
            CheckButtonToShow(currentTopType);

            SoundManager.Ins.PlayButtonClickSound();
        }
    }
    public void BuyPantButton()
    {
        if(PlayerDataManager.Ins.GetPlayerGold() < SkinDataManager.Ins.GetPrice(currentPantType))
        {
            currentBuyButton.GetUIButton().DisableButton();
        }
        else
        {
            PlayerDataManager.Ins.ChangePlayerGold(SkinDataManager.Ins.GetPrice(currentPantType));
            SkinDataManager.Ins.UnlockSkin(currentPantType);

            UpdateGold();
            CheckButtonToShow(currentPantType);

            SoundManager.Ins.PlayButtonClickSound();
        }
    }
    public void BuyShieldButton()
    {
        if(PlayerDataManager.Ins.GetPlayerGold() < SkinDataManager.Ins.GetPrice(currentShieldType))
        {
            currentBuyButton.GetUIButton().DisableButton();
        }
        else
        {
            PlayerDataManager.Ins.ChangePlayerGold(SkinDataManager.Ins.GetPrice(currentShieldType));
            SkinDataManager.Ins.UnlockSkin(currentShieldType);

            UpdateGold();
            CheckButtonToShow(currentShieldType);

            SoundManager.Ins.PlayButtonClickSound();
        }
    }
    public void BuySetButton()
    {
        if(PlayerDataManager.Ins.GetPlayerGold() < SkinDataManager.Ins.GetPrice(currentSetType))
        {
            currentBuyButton.GetUIButton().DisableButton();
        }
        else
        {
            PlayerDataManager.Ins.ChangePlayerGold(SkinDataManager.Ins.GetPrice(currentSetType));
            SkinDataManager.Ins.UnlockSkin(currentSetType);

            UpdateGold();
            CheckButtonToShow(currentSetType);

            SoundManager.Ins.PlayButtonClickSound();
        }
    }

    protected override void OnCloseCanvas()
    {
        base.OnCloseCanvas();
        DeactivePreviewSet();
        DeactivePreviewSkin();
        playerSkinControll.ChooseSkinToActive();
        characterCombat.characterWeaponScript.AppearOnHand();
        GameManager.Ins.ChangeState(GameState.MainMenu);
    }
}

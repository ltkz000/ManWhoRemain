using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasWeaponShop : UICanvas
{
    private int currentWeaponIndex;
    private int currentSkinIndex;
    [SerializeField] private CharacterCombat player;

    //UI
    [SerializeField] private Text weaponNameText;
    [SerializeField] private Text goldText;
    [SerializeField] private UIButton selectButton;
    [SerializeField] private UIButton buyWeaponButton;
    [SerializeField] private UIButton buySkinButton;
    [SerializeField] private GameObject weaponPreview;
    public List<SkinHolder> skinButtonList;
    private GameObject previewWeapon;

    protected override void OnOpenCanvas()
    {
        base.OnOpenCanvas();
        UpdateGold();
        ChangeWeaponNameText();
        InitSkinButton();
        InitSelectedWeapon();
        SetActiveWeaponAndSkin();
        ChangSelectText();
        ChangeWeaponButton();
    }

    public void InitSkinButton()
    {
        for(int i = 0; i < skinButtonList.Count; i++)
        {
            skinButtonList[i].SetButtonID(i);
        }
    }

    private void InitSelectedWeapon()
    {
        for(int i = 0; i < WeaponDataManager.Ins.GetListLength(); i++)
        {
            if(PlayerDataManager.Ins.GetPlayerWeaponID() == WeaponDataManager.Ins.GetWeaponID(i))
            {
                currentWeaponIndex = i;
                break;
            }
        }
    }

    private void ShowPreviewWeapon(GameObject skinPreview)
    {
        previewWeapon = Instantiate(skinPreview, weaponPreview.transform.position, skinPreview.transform.rotation, weaponPreview.transform);
        previewWeapon.transform.localScale *= 300;
        previewWeapon.transform.rotation = Quaternion.Euler(-90, 0, 0);
    }

    public void NextWeapon()
    {
        DeactiveWeaponAndSkin();

        currentWeaponIndex++;
        currentSkinIndex = WeaponDataManager.Ins.GetCurrentSkinIndex(currentSkinIndex);
        if(currentWeaponIndex == WeaponDataManager.Ins.GetListLength())
        {
            currentWeaponIndex = 0;
        }

        ChangeWeaponNameText();
        SetActiveWeaponAndSkin();
        ChangSelectText();
        ChangeWeaponButton();

        SoundManager.Ins.PlayButtonClickSound();
    }

    public void PreviousWeapon()
    {
        DeactiveWeaponAndSkin();

        currentWeaponIndex--;
        currentSkinIndex = WeaponDataManager.Ins.GetCurrentSkinIndex(currentSkinIndex);
        if(currentWeaponIndex < 0)
        {
            currentWeaponIndex = WeaponDataManager.Ins.GetListLength() - 1;
        }

        ChangeWeaponNameText();
        SetActiveWeaponAndSkin();
        ChangSelectText();
        ChangeWeaponButton();

        SoundManager.Ins.PlayButtonClickSound();
    }

    private void SetActiveWeaponAndSkin()
    {
        ShowPreviewWeapon(WeaponDataManager.Ins.GetUIWeaponPrefab(currentWeaponIndex));
        foreach(var temp in skinButtonList)
        {
            temp.enableSkin(currentWeaponIndex);
        }
    }

    private void DeactiveWeaponAndSkin()
    {
        Destroy(previewWeapon);
        foreach(var temp in skinButtonList)
        {
            temp.disableSkin(currentWeaponIndex);
        }
    }

    private void ChangSelectText()
    {
        if(WeaponDataManager.Ins.GetWeaponID(currentWeaponIndex) != PlayerDataManager.Ins.GetPlayerWeaponID()
            || WeaponDataManager.Ins.GetCurrentSkinIndex(currentWeaponIndex) != currentSkinIndex)
        {
            selectButton.thisText.text = ConstValues.SELECT_TEXT;
        }
        else
        {
            selectButton.thisText.text = ConstValues.EQUIPPED_TEXT;
        }
    }

    private void ChangeWeaponNameText()
    {
        weaponNameText.text = WeaponDataManager.Ins.GetWeaponID(currentWeaponIndex).ToString();
    }

    public void UpdateGold()
    {
        goldText.text = PlayerDataManager.Ins.GetPlayerGold().ToString();
    }

    public void SelectWeaponButton()
    {
        PlayerDataManager.Ins.ChangePlayerWeaponID(WeaponDataManager.Ins.GetWeaponID(currentWeaponIndex));
        WeaponDataManager.Ins.ChangeCurrentSkinIndex(currentWeaponIndex, currentSkinIndex);

        player.ChangePlayerWeapon();

        // selectButton.thisText.text = ConstValues.EQUIPPED_TEXT;
        ChangSelectText();

        SoundManager.Ins.PlayButtonClickSound();
    }

    public void BuyWeaponButton()
    {
        if(PlayerDataManager.Ins.GetPlayerGold() < WeaponDataManager.Ins.GetWeaponPrice(currentWeaponIndex))
        {
            buyWeaponButton.DisableButton();
        }
        else
        {
            currentSkinIndex = WeaponDataManager.Ins.GetCurrentSkinIndex(currentWeaponIndex);
            Destroy(previewWeapon);
            ShowPreviewWeapon(WeaponDataManager.Ins.GetUIWeaponPrefab(currentWeaponIndex));
            PlayerDataManager.Ins.ChangePlayerGold(WeaponDataManager.Ins.GetWeaponPrice(currentWeaponIndex));

            WeaponDataManager.Ins.ChangeWeaponStatus(currentWeaponIndex);

            ChangeWeaponButton();
            UpdateGold();
        }

        SoundManager.Ins.PlayButtonClickSound();
    }

    public void BuySkinButton()
    {
        if(PlayerDataManager.Ins.GetPlayerGold() < WeaponDataManager.Ins.GetSkinPrice(currentWeaponIndex, currentSkinIndex))
        {
            buySkinButton.DisableButton();
        }
        else
        {
            PlayerDataManager.Ins.ChangePlayerGold(WeaponDataManager.Ins.GetSkinPrice(currentWeaponIndex, currentSkinIndex));

            // WeaponDataManager.Ins.ChangeCurrentSkin(currentWeaponIndex, currentSkinIndex);

            WeaponDataManager.Ins.ChangeCurrentSkinIndex(currentWeaponIndex, currentSkinIndex); 

            WeaponDataManager.Ins.ChangeSkinStatus(currentWeaponIndex, currentSkinIndex);

            ChangeWeaponButton();
            UpdateGold();
        }

        SoundManager.Ins.PlayButtonClickSound();
    }

    public void SelectSkin(SkinHolder skinButton)
    {
        currentSkinIndex = skinButton.GetButtonID();
        Destroy(previewWeapon);

        ShowPreviewWeapon(WeaponDataManager.Ins.GetUIWeaponPreview(currentWeaponIndex, skinButton.GetButtonID()));

        ChangeSkinButton(skinButton);
        ChangSelectText();
    } 

    private void ChangeWeaponButton()
    {
        buySkinButton.thisButton.SetActive(false);

        if(WeaponDataManager.Ins.CheckWeaponStatus(currentWeaponIndex) == true)
        {
            selectButton.thisButton.SetActive(false);
            buyWeaponButton.thisButton.SetActive(true);
            buyWeaponButton.thisText.text = WeaponDataManager.Ins.GetWeaponPrice(currentWeaponIndex).ToString();
        }
        else
        {
            selectButton.thisButton.SetActive(true);
            buyWeaponButton.thisButton.SetActive(false);
        }
    }

    private void ChangeSkinButton(SkinHolder skinButton)
    {
        if(WeaponDataManager.Ins.CheckWeaponStatus(currentWeaponIndex))
        {
            buySkinButton.thisButton.SetActive(false);
        }
        else
        {
            if(WeaponDataManager.Ins.CheckSkinStatus(currentWeaponIndex, skinButton.GetButtonID()) == true)
            {
                selectButton.thisButton.SetActive(false);
                buyWeaponButton.thisButton.SetActive(false);
                buySkinButton.thisButton.SetActive(true);
                buySkinButton.thisText.text = WeaponDataManager.Ins.GetSkinPrice(currentWeaponIndex, skinButton.GetButtonID()).ToString();
            }
            else
            {
                selectButton.thisButton.SetActive(true);
                buyWeaponButton.thisButton.SetActive(false);
                buySkinButton.thisButton.SetActive(false);
            }
        }
    }

    public void CloseShop()
    {
        DeactiveWeaponAndSkin();

        UIManager.Ins.OpenUI(UICanvasID.MainMenu);

        SoundManager.Ins.PlayButtonClickSound();

        Close();
    }
}

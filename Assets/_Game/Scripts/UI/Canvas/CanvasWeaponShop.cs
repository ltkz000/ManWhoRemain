using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasWeaponShop : UICanvas
{
    public int currentWeaponIndex;
    public CharacterCombat player;

    //UI
    [SerializeField] private Text weaponNameText;
    [SerializeField] private UIButton selectButton;
    [SerializeField] private UIButton buyButton;
    [SerializeField] private GameObject weaponPreview;
    public List<SkinHolder> skinButtonList;
    private GameObject previewWeapon;

    protected override void OnOpenCanvas()
    {
        base.OnOpenCanvas();
        ChangeWeaponNameText();
        InitSkinButton();
        InitSelectedWeapon();
        SetActiveWeaponAndSkin();
        ChangSelectText();
        ChangeButton();
       
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
        if(currentWeaponIndex == WeaponDataManager.Ins.GetListLength())
        {
            currentWeaponIndex = 0;
        }

        ChangeWeaponNameText();
        SetActiveWeaponAndSkin();
        ChangSelectText();
        ChangeButton();
    }

    public void PreviousWeapon()
    {
        DeactiveWeaponAndSkin();

        currentWeaponIndex--;
        if(currentWeaponIndex < 0)
        {
            currentWeaponIndex = WeaponDataManager.Ins.GetListLength() - 1;
        }

        ChangeWeaponNameText();
        SetActiveWeaponAndSkin();
        ChangSelectText();
        ChangeButton();
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
        if(WeaponDataManager.Ins.GetWeaponID(currentWeaponIndex) != PlayerDataManager.Ins.GetPlayerWeaponID())
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

    public void SelectWeaponButton()
    {
        PlayerDataManager.Ins.ChangePlayerWeaponID(WeaponDataManager.Ins.GetWeaponID(currentWeaponIndex));

        player.ChangePlayerWeapon();

        selectButton.thisText.text = ConstValues.EQUIPPED_TEXT;
    }

    public void BuyWeaponButton()
    {
        if(PlayerDataManager.Ins.GetPlayerGold() < WeaponDataManager.Ins.GetWeaponPrice(currentWeaponIndex))
        {
            buyButton.DisableButton();
        }
        else
        {
            PlayerDataManager.Ins.ChangePlayerGold(WeaponDataManager.Ins.GetWeaponPrice(currentWeaponIndex));

            WeaponDataManager.Ins.ChangeWeaponStatus(currentWeaponIndex);

            ChangeButton();
        }
    }

    public void SelectSkin(SkinHolder skinButton)
    {
        Destroy(previewWeapon);

        WeaponDataManager.Ins.ChangeCurrentSkinUI(currentWeaponIndex, skinButton.GetButtonID());
        WeaponDataManager.Ins.ChangeCurrentSkin(currentWeaponIndex, skinButton.GetButtonID());

        ShowPreviewWeapon(WeaponDataManager.Ins.GetUIWeaponPrefab(currentWeaponIndex));
    } 

    private void ChangeButton()
    {
        
        if(WeaponDataManager.Ins.CheckWeaponStatus(currentWeaponIndex) == true)
        {
            selectButton.thisButton.SetActive(false);
            buyButton.thisButton.SetActive(true);
            buyButton.thisText.text = WeaponDataManager.Ins.GetWeaponPrice(currentWeaponIndex).ToString();
        }
        else
        {
            selectButton.thisButton.SetActive(true);
            buyButton.thisButton.SetActive(false);
        }
    }

    public void CloseShop()
    {
        DeactiveWeaponAndSkin();

        UIManager.Ins.OpenUI(UICanvasID.MainMenu);

        Close();
    }
}

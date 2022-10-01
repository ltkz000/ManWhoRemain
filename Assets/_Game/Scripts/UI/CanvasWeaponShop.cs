using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class WeaponShop
{
    public WeaponID weaponID;
    public GameObject weaponObject;
}

public class CanvasWeaponShop : UICanvas
{
    public int currentWeaponIndex;
    public List<WeaponShop> weaponShops;
    public Text selectText;

    protected override void OnOpenCanvas()
    {
        base.OnOpenCanvas();
        GetSelectedWeapon();
    }

    public void GetSelectedWeapon()
    {
        for(int i = 0; i < weaponShops.Count; i++)
        {
            if(weaponShops[i].weaponID == PlayerDataManager.Ins.GetPlayerWeaponID())
            {
                currentWeaponIndex = i;
                weaponShops[i].weaponObject.SetActive(false);
            }
        }

        weaponShops[currentWeaponIndex].weaponObject.SetActive(true);
    }

    public void NextWeapon()
    {
        weaponShops[currentWeaponIndex].weaponObject.SetActive(false);

        currentWeaponIndex++;
        if(currentWeaponIndex == weaponShops.Count)
        {
            currentWeaponIndex = 0;
        }

        weaponShops[currentWeaponIndex].weaponObject.SetActive(true);

        if(weaponShops[currentWeaponIndex].weaponID != PlayerDataManager.Ins.GetPlayerWeaponID())
        {
            selectText.text = ConstValues.SELECT_TEXT;
        }
        else
        {
            selectText.text = ConstValues.EQUIPPED_TEXT;
        }
    }

    public void PreviousWeapon()
    {
        weaponShops[currentWeaponIndex].weaponObject.SetActive(false);

        currentWeaponIndex--;
        if(currentWeaponIndex < 0)
        {
            currentWeaponIndex = weaponShops.Count - 1;
        }

        weaponShops[currentWeaponIndex].weaponObject.SetActive(true);

        if(weaponShops[currentWeaponIndex].weaponID != PlayerDataManager.Ins.GetPlayerWeaponID())
        {
            selectText.text = ConstValues.SELECT_TEXT;
        }
        else
        {
            selectText.text = ConstValues.EQUIPPED_TEXT;
        }
    }

    public void SelectWeaponButton()
    {
        PlayerDataManager.Ins.ChangePlayerWeaponID(weaponShops[currentWeaponIndex].weaponID);

        selectText.text = ConstValues.EQUIPPED_TEXT;
    }

    public void CloseShop()
    {
        UIManager.Ins.OpenUI(UICanvasID.MainMenu);

        Close();
    }
}

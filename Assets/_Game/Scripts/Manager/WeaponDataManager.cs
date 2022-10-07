using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDataManager : Singleton<WeaponDataManager>
{
    [SerializeField] private List<WeaponData> weaponDataList;

    public int GetListLength()
    {
        return weaponDataList.Count;
    }

    public WeaponData GetWeaponData(int index)
    {
        return weaponDataList[index];
    }

    public WeaponID GetWeaponID(int index)
    {
        return weaponDataList[index].weaponID;
    }

    public int GetWeaponPrice(int index)
    {
        return weaponDataList[index].price;
    }

    public void ChangeCurrentSkinUI(int index, int newSkinUIIndex)
    {
        weaponDataList[index].currentSkinUI = weaponDataList[index].WeaponSkins[newSkinUIIndex].skinUI;
    }

    public void ChangeCurrentSkin(int index, int newSkinIndex)
    {
        weaponDataList[index].currentSkin = weaponDataList[index].WeaponSkins[newSkinIndex].skinPrefab;
    }

    public GameObject GetUIWeaponPrefab(int index)
    {
        return weaponDataList[index].currentSkinUI;
    }

    public GameObject GetWeaponByID(WeaponID weaponID)
    {
        for(int i = 0; i < weaponDataList.Count; i++)
        {
            if(weaponID == weaponDataList[i].weaponID)
            {
                return weaponDataList[i].currentSkin;
            }
        }
        return weaponDataList[0].currentSkin;
    }

    public bool CheckWeaponStatus(int index)
    {
        return weaponDataList[index].isLock;
    }

    public void ChangeWeaponStatus(int index)
    {
        weaponDataList[index].isLock = false;
    }
}

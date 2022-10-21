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

    public WeaponID GetWeaponID(int index)
    {
        return weaponDataList[index].weaponID;
    }

    public int GetWeaponPrice(int index)
    {
        return weaponDataList[index].price;
    }

    public int GetSkinPrice(int weaponIndex, int skinIndex)
    {
        return weaponDataList[weaponIndex].WeaponSkins[skinIndex].price;
    }

    public GameObject GetUIWeaponPrefab(int index)
    {
        int skinIndex = weaponDataList[index].currentSkinIndex;
        return weaponDataList[index].WeaponSkins[skinIndex].skinUI;
    }

    public GameObject GetUIWeaponPreview(int weaponIndex, int skinIndex)
    {
        return weaponDataList[weaponIndex].WeaponSkins[skinIndex].skinUI;
    }

    public GameObject GetWeaponByID(WeaponID weaponID)
    {
        int skinIndex;
        for(int i = 0; i < weaponDataList.Count; i++)
        {
            if(weaponID == weaponDataList[i].weaponID)
            {
                skinIndex = weaponDataList[i].currentSkinIndex;
                return weaponDataList[i].WeaponSkins[skinIndex].skinPrefab;
            }
        }
        skinIndex = weaponDataList[0].currentSkinIndex;
        return weaponDataList[0].currentSkin;
    }

    public int GetCurrentSkinIndex(int weaponIndex)
    {
        return weaponDataList[weaponIndex].currentSkinIndex;
    }

    public void ChangeCurrentSkinIndex(int weaponIndex, int newSkinIndex)
    {
        weaponDataList[weaponIndex].currentSkinIndex = newSkinIndex;
    }

    public bool CheckWeaponStatus(int index)
    {
        return weaponDataList[index].isLock;
    }

    public bool CheckSkinStatus(int weaponIndex, int skinIndex)
    {
        return weaponDataList[weaponIndex].WeaponSkins[skinIndex].isLock;
    }

    public void ChangeWeaponStatus(int index)
    {
        weaponDataList[index].isLock = false;
    }

    public void ChangeSkinStatus(int weaponIndex, int skinIndex)
    {
        weaponDataList[weaponIndex].WeaponSkins[skinIndex].isLock = false;
    }
}

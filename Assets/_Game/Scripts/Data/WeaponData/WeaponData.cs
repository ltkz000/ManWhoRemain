using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "My Assets/Weapon Data")]

[System.Serializable]
public class WeaponSkin
{
    public int price;
    public bool isLock;
    // public bool isEquipped;
    public GameObject skinPrefab;
    public GameObject skinUI;
}

public class WeaponData : ScriptableObject
{
    public WeaponID weaponID;
    public GameObject currentSkin;
    // public GameObject currentSkinUI;
    public int currentSkinIndex;
    public int price;
    public bool isLock;
    [NonReorderable] public List<WeaponSkin> WeaponSkins;
}
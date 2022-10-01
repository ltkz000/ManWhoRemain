using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "My Assets/Weapon Data")]

public class WeaponData : ScriptableObject
{
    public WeaponID weaponID;
    public int price;
    public bool isEquipped;
    public bool isLock;
    public List<Material> weaponSkin;
}

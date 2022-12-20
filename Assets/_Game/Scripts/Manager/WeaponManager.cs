using UnityEngine;

public enum WeaponID
{
    Axe,
    Axee,
    Boomerang,
    Candy,
    Hammer,
    Ice
}

[System.Serializable]
public class WeaponRef
{
    public WeaponID weaponID;
    public Transform weaponTranform;
}

public class WeaponManager : Singleton<WeaponManager>
{
    public Transform weaponParentTrans;
}

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

[System.Serializable]
public class WeaponPool
{
    public WeaponID weaponID;
    public GameObject weaponPrefab;
    public int poolSize;
}

public class WeaponManager : Singleton<WeaponManager>
{
    public Transform weaponParentTrans;
}

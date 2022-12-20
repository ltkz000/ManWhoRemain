using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerProfile
{
    public string playerName;
    public int playerGold;
    public int currentLevel;
    public WeaponID playerWeaponID;
    public TopType skinTopID;
    public PantType skinPantID;
    public ShieldType skinShieldID;
    public SetType skinSetID;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : Singleton<PlayerDataManager>
{
    [SerializeField] private PlayerData playerData;

    public WeaponID GetPlayerWeaponID()
    {
        return playerData.playerWeaponID;
    }

    public void ChangePlayerWeaponID(WeaponID newWeaponID)
    {
        playerData.playerWeaponID = newWeaponID;
    }

    public void UpdatePlayerGold()
    {
        playerData.playerGold += 10;
    }

    public int GetPlayerGold()
    {
        return playerData.playerGold;
    }

    public void ChangePlayerGold(int weaponPrice)
    {
        playerData.playerGold -= weaponPrice;
    }

    public string GetPlayerName()
    {
        return playerData.playerName;
    }

    public void ChangePlayerName(string newName)
    {
        playerData.playerName = newName;
    }

    public TopType GetPlayerTopID()
    {
        return playerData.skinTopID;
    }

    public void ChangePlayerTopID(TopType type)
    {
        playerData.skinTopID = type;
    }
    public PantType GetPlayerPantID()
    {
        return playerData.skinPantID;
    }

    public void ChangePlayerPantID(PantType type)
    {
        playerData.skinPantID = type;
    }
    public ShieldType GetPlayerShieldID()
    {
        return playerData.skinShieldID;
    }

    public void ChangePlayerShieldID(ShieldType type)
    {
        playerData.skinShieldID = type;
    }
    public SetType GetPlayerSetID()
    {
        return playerData.skinSetID;
    }

    public void ChangePlayerSetID(SetType type)
    {
        playerData.skinSetID = type;
    }

    public int GetPlayerLevel()
    {
        return playerData.currentLevel;
    }
}

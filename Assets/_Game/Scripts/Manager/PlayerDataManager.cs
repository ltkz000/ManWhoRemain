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

    public void changePlayerName(string newName)
    {
        playerData.playerName = newName;
    }
}

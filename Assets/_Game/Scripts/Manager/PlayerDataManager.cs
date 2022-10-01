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
}

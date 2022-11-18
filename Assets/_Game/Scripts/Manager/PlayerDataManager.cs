using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : Singleton<PlayerDataManager>
{
    [SerializeField] private Transform parentTrans;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private Player player;
    [SerializeField] private CharacterCombat characterCombat;
    [SerializeField] private PlayerSkinControll playerSkinControll;

    private void Start() 
    {
        PlayerDataManager.Ins.SpawnPlayer();    
    }

    public GameObject SpawnPlayer()
    {
        if(player != null) Destroy(player.gameObject);
        GameObject newPlayer = Instantiate(playerPrefab, Vector3.zero, Quaternion.Euler(0, 180, 0), parentTrans);
        player = newPlayer.GetComponent<Player>();
        characterCombat = newPlayer.GetComponent<CharacterCombat>();
        playerSkinControll = newPlayer.GetComponent<PlayerSkinControll>();
        return newPlayer;
    }

    public Player GetPlayer()
    {
        return player;
    }

    public void InitPlayer(Player newPlayer)
    {
        player = newPlayer;
    }

    public CharacterCombat GetCharacterCombat()
    {
        return characterCombat;
    }

    public void InitCharacterCombat(CharacterCombat newCharacterCombat)
    {
        characterCombat = newCharacterCombat;
    }

    public PlayerSkinControll GetPlayerSkinControll()
    {
        return playerSkinControll;
    }

    public void InitSkinControll(PlayerSkinControll newSkinControll)
    {
        playerSkinControll = newSkinControll;
    }

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
        playerData.playerGold += ConstValues.KILL_GOLD;
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

    public void ChangePlayerLevel()
    {
        playerData.currentLevel++;
        if(playerData.currentLevel > LevelManager.Ins.GetMaxLevel())
        {
            playerData.currentLevel = 0;
        }
    }
}

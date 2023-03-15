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
        // if(SaveData.current.playerProfile != null)
        // {
            // playerData.playerProfile = SaveData.current.playerProfile;
        // } 
    }

    public GameObject SpawnPlayer()
    {
        if(player != null) Destroy(player.gameObject);
        GameObject newPlayer = Instantiate(playerPrefab, Vector3.zero, Quaternion.Euler(0, 180, 0), parentTrans);
        // GameObject newPlayer = Instantiate(playerPrefab, Vector3Quaternion.Euler(0, 180, 0), parentTrans);
        player = newPlayer.GetComponent<Player>();
        characterCombat = newPlayer.GetComponent<CharacterCombat>();
        playerSkinControll = newPlayer.GetComponent<PlayerSkinControll>();
        return newPlayer;
    }

    public Player GetPlayer()
    {
        return player;
    }

    public PlayerData GetPlayerData()
    {
        return playerData;
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
        return playerData.playerProfile.playerWeaponID;
    }

    public void ChangePlayerWeaponID(WeaponID newWeaponID)
    {
        playerData.playerProfile.playerWeaponID = newWeaponID;
    }

    public void UpdatePlayerGold()
    {
        playerData.playerProfile.playerGold += ConstValues.KILL_GOLD;
    }

    public int GetPlayerGold()
    {
        return playerData.playerProfile.playerGold;
    }

    public void ChangePlayerGold(int weaponPrice)
    {
        playerData.playerProfile.playerGold -= weaponPrice;
    }

    public string GetPlayerName()
    {
        return playerData.playerProfile.playerName;
    }

    public void ChangePlayerName(string newName)
    {
        playerData.playerProfile.playerName = newName;
    }

    public TopType GetPlayerTopID()
    {
        return playerData.playerProfile.skinTopID;
    }

    public void ChangePlayerTopID(TopType type)
    {
        playerData.playerProfile.skinTopID = type;
    }

    public PantType GetPlayerPantID()
    {
        return playerData.playerProfile.skinPantID;
    }

    public void ChangePlayerPantID(PantType type)
    {
        playerData.playerProfile.skinPantID = type;
    }

    public ShieldType GetPlayerShieldID()
    {
        return playerData.playerProfile.skinShieldID;
    }

    public void ChangePlayerShieldID(ShieldType type)
    {
        playerData.playerProfile.skinShieldID = type;
    }

    public SetType GetPlayerSetID()
    {
        return playerData.playerProfile.skinSetID;
    }

    public void ChangePlayerSetID(SetType type)
    {
        playerData.playerProfile.skinSetID = type;
    }

    public int GetPlayerLevel()
    {
        return playerData.playerProfile.currentLevel;
    }

    public void ChangePlayerLevel()
    {
        playerData.playerProfile.currentLevel++;
        if(playerData.playerProfile.currentLevel > LevelManager.Ins.GetMaxLevel())
        {
            playerData.playerProfile.currentLevel = 0;
        }
    }
}

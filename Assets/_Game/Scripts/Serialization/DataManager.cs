// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class DataManager : Singleton<DataManager>
// {
//     public SaveData save;
//     private void Awake() 
//     {   
//         OnLoadGame();
//         save = SaveData.current;
//     }

//     private void OnLoadGame()
//     {
//         SaveData.current.playerProfile = (PlayerProfile)SerializationManager.Load(Application.persistentDataPath + "/saves/PlayerProfile.save"); 
        
//         SaveData.current.topData = (TopData)SerializationManager.Load(Application.persistentDataPath + "/saves/TopData.save");

//         SaveData.current.pantData = (PantData)SerializationManager.Load(Application.persistentDataPath + "/saves/PantData.save");

//         SaveData.current.shieldData = (ShieldData)SerializationManager.Load(Application.persistentDataPath + "/saves/ShieldData.save");

//         SaveData.current.setData = (SetData)SerializationManager.Load(Application.persistentDataPath + "/saves/SetData.save");
//     }

//     private void OnApplicationQuit() 
//     {
//         SaveData.current.playerProfile = PlayerDataManager.Ins.GetPlayerData().playerProfile;
//         SerializationManager.Save("PlayerProfile", SaveData.current.playerProfile);

//         SaveData.current.topData = SkinDataManager.Ins.GetTopData();
//         SerializationManager.Save("TopData", SaveData.current.topData);

//         SaveData.current.pantData = SkinDataManager.Ins.GetPantData();
//         SerializationManager.Save("PantData", SaveData.current.pantData);
        
//         SaveData.current.shieldData = SkinDataManager.Ins.GetShieldData();
//         SerializationManager.Save("ShieldData", SaveData.current.shieldData);

//         SaveData.current.setData = SkinDataManager.Ins.GetSetData();
//         SerializationManager.Save("SetData", SaveData.current.setData);
//     }
// }

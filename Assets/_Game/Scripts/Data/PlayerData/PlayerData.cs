using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "My Assets/Player Data")]

public class PlayerData : ScriptableObject
{
   public WeaponID playerWeaponID;
   public TopType skinTopID;
   public PantType skinPantID;
   public ShieldType skinShieldID;
   public SetType skinSetID;
   public int currentLevel;
   public int highestScore;
   public int playerGold;
   public string playerName;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "My Assets/Player Data")]

public class PlayerData : ScriptableObject
{
   public WeaponID playerWeaponID;
   public int highestScore;
   public int playerGold;
   public string playerName;
}

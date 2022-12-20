using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "My Assets/ShieldSkin Data")]
[System.Serializable]
public class ShieldSkinData : ScriptableObject
{
    public ShieldData shieldData;

    public bool GetSkinStatus(ShieldType type)
    {
        for(int i = 0; i < shieldData.ShieldSkinList.Count; i++)
        {
            if(shieldData.ShieldSkinList[i].shieldType == type)
            {
                return shieldData.ShieldSkinList[i].isLock;
            }
        }

        return true;
    }

    public void ChangeSkinStatus(ShieldType type, bool status)
    {
        for(int i = 0; i < shieldData.ShieldSkinList.Count; i++)
        {
            if(shieldData.ShieldSkinList[i].shieldType == type)
            {
                shieldData.ShieldSkinList[i].isLock = status;
            }
        }
    }

    public int GetSkinPrice(ShieldType type)
    {
        for(int i = 0; i < shieldData.ShieldSkinList.Count; i++)
        {
            if(shieldData.ShieldSkinList[i].shieldType == type)
            {
                return shieldData.ShieldSkinList[i].price;
            }
        }

        return 0;
    }
}

[System.Serializable]
public class ShieldData
{
    [SerializeField, NonReorderable] public List<ShieldSkin> ShieldSkinList;
}

[System.Serializable]
public class ShieldSkin
{
    public ShieldType shieldType;
    public int price;
    public bool isLock;
}

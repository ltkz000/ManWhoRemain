using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "My Assets/ShieldSkin Data")]

public class ShieldSkinData : ScriptableObject
{
    [SerializeField, NonReorderable] private List<ShieldSkin> ShieldSkinList;

    public bool GetSkinStatus(ShieldType type)
    {
        for(int i = 0; i < ShieldSkinList.Count; i++)
        {
            if(ShieldSkinList[i].shieldType == type)
            {
                return ShieldSkinList[i].isLock;
            }
        }

        return true;
    }

    public void ChangeSkinStatus(ShieldType type, bool status)
    {
        for(int i = 0; i < ShieldSkinList.Count; i++)
        {
            if(ShieldSkinList[i].shieldType == type)
            {
                ShieldSkinList[i].isLock = status;
            }
        }
    }

    public int GetSkinPrice(ShieldType type)
    {
        for(int i = 0; i < ShieldSkinList.Count; i++)
        {
            if(ShieldSkinList[i].shieldType == type)
            {
                return ShieldSkinList[i].price;
            }
        }

        return 0;
    }
}

[System.Serializable]
public class ShieldSkin
{
    public ShieldType shieldType;
    public int price;
    public bool isLock;
    public bool isEquip;
}

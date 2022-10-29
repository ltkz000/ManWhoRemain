using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "My Assets/SetSkin Data")]

public class SetSkinData : ScriptableObject
{
    [SerializeField, NonReorderable] private List<SetSkin> SetSkinList;

    public bool GetSkinStatus(SetType type)
    {
        for(int i = 0; i < SetSkinList.Count; i++)
        {
            if(SetSkinList[i].setType == type)
            {
                return SetSkinList[i].isLock;
            }
        }

        return true;
    }

    public void ChangeSkinStatus(SetType type, bool status)
    {
        for(int i = 0; i < SetSkinList.Count; i++)
        {
            if(SetSkinList[i].setType == type)
            {
                SetSkinList[i].isLock = status;
            }
        }
    }

    public int GetSkinPrice(SetType type)
    {
        for(int i = 0; i < SetSkinList.Count; i++)
        {
            if(SetSkinList[i].setType == type)
            {
                return SetSkinList[i].price;
            }
        }

        return 0;
    }
}

[System.Serializable]
public class SetSkin
{
    public SetType setType;
    public int price;
    public bool isLock;
    public bool isEquip;
}

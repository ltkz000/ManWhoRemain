using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "My Assets/SetSkin Data")]
[System.Serializable]
public class SetSkinData : ScriptableObject
{
    public SetData setData;

    public bool GetSkinStatus(SetType type)
    {
        for(int i = 0; i < setData.SetSkinList.Count; i++)
        {
            if(setData.SetSkinList[i].setType == type)
            {
                return setData.SetSkinList[i].isLock;
            }
        }

        return true;
    }

    public void ChangeSkinStatus(SetType type, bool status)
    {
        for(int i = 0; i < setData.SetSkinList.Count; i++)
        {
            if(setData.SetSkinList[i].setType == type)
            {
                setData.SetSkinList[i].isLock = status;
            }
        }
    }

    public int GetSkinPrice(SetType type)
    {
        for(int i = 0; i < setData.SetSkinList.Count; i++)
        {
            if(setData.SetSkinList[i].setType == type)
            {
                return setData.SetSkinList[i].price;
            }
        }

        return 0;
    }
}

[System.Serializable]
public class SetData
{
    [SerializeField, NonReorderable] public List<SetSkin> SetSkinList;
}

[System.Serializable]
public class SetSkin
{
    public SetType setType;
    public int price;
    public bool isLock;
}

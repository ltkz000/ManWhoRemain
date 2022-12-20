using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "My Assets/PantSkin Data")]
[System.Serializable]
public class PantSkinData : ScriptableObject
{
    public PantData pantData;

    public bool GetSkinStatus(PantType type)
    {
        for(int i = 0; i < pantData.PantSkinList.Count; i++)
        {
            if(pantData.PantSkinList[i].pantType == type)
            {
                return pantData.PantSkinList[i].isLock;
            }
        }

        return true;
    }

    public void ChangeSkinStatus(PantType type, bool status)
    {
        for(int i = 0; i < pantData.PantSkinList.Count; i++)
        {
            if(pantData.PantSkinList[i].pantType == type)
            {
                pantData.PantSkinList[i].isLock = status;
            }
        }
    }

    public int GetSkinPrice(PantType type)
    {
        for(int i = 0; i < pantData.PantSkinList.Count; i++)
        {
            if(pantData.PantSkinList[i].pantType == type)
            {
                return pantData.PantSkinList[i].price;
            }
        }

        return 0;
    }
}

[System.Serializable]
public class PantData
{
    [SerializeField, NonReorderable] public List<PantSkin> PantSkinList;
}

[System.Serializable]
public class PantSkin
{
    public PantType pantType;
    public int price;
    public bool isLock;
}

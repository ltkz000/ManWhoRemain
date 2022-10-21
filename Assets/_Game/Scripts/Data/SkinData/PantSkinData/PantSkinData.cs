using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "My Assets/PantSkin Data")]

public class PantSkinData : ScriptableObject
{
    [SerializeField, NonReorderable] private List<PantSkin> PantSkinList;

    public bool GetSkinStatus(PantType type)
    {
        for(int i = 0; i < PantSkinList.Count; i++)
        {
            if(PantSkinList[i].pantType == type)
            {
                return PantSkinList[i].isLock;
            }
        }

        return true;
    }

    public int GetSkinPrice(PantType type)
    {
        for(int i = 0; i < PantSkinList.Count; i++)
        {
            if(PantSkinList[i].pantType == type)
            {
                return PantSkinList[i].price;
            }
        }

        return 0;
    }
}

[System.Serializable]
public class PantSkin
{
    public PantType pantType;
    public int price;
    public bool isLock;
}

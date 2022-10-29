using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "My Assets/TopSkin Data")]

public class TopSkinData : ScriptableObject
{
    [SerializeField, NonReorderable] private List<TopSkin> TopSkinList;

    public bool GetSkinStatus(TopType type)
    {
        for(int i = 0; i < TopSkinList.Count; i++)
        {
            if(TopSkinList[i].topType == type)
            {
                return TopSkinList[i].isLock;
            }
        }

        return true;
    }

    public void ChangeSkinStatus(TopType type, bool status)
    {
        for(int i = 0; i < TopSkinList.Count; i++)
        {
            if(TopSkinList[i].topType == type)
            {
                TopSkinList[i].isLock = status;
            }
        }
    }

    public int GetSkinPrice(TopType type)
    {
        for(int i = 0; i < TopSkinList.Count; i++)
        {
            if(TopSkinList[i].topType == type)
            {
                return TopSkinList[i].price;
            }
        }

        return 0;
    }
}

[System.Serializable]
public class TopSkin
{
    public TopType topType;
    public int price;
    public bool isLock;
    public bool isEquip;
}

public enum SkinID
{
    Top, Pant, Shield, Set 
}

public enum TopType
{
    Arrow, Cowboy, Crown, Hat, Hat_Cap, Headphone, None
}

public enum PantType
{
    Batman, Chambi, Comy, Dabao, Onion, Pokemon, Rainbow, Skull, Vantim, None
}

public enum ShieldType
{
    Captain, Wakanda, None
}

public enum SetType
{
    Devil, Angle, Witch, Deadpool, Thor, None
}

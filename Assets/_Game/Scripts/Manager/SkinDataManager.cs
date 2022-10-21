using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinDataManager : Singleton<SkinDataManager>
{
    [SerializeField] private TopSkinData topSkinData;
    [SerializeField] private PantSkinData pantSkinData;
    [SerializeField] private ShieldSkinData shieldSkinData;
    [SerializeField] private SetSkinData setSkinData;

    //GetStatus
    public bool CheckIsLock(TopType type)
    {
        return topSkinData.GetSkinStatus(type);
    }
    public bool CheckIsLock(PantType type)
    {
        return pantSkinData.GetSkinStatus(type);
    }
    public bool CheckIsLock(ShieldType type)
    {
        return shieldSkinData.GetSkinStatus(type);
    }
    public bool CheckIsLock(SetType type)
    {
        return setSkinData.GetSkinStatus(type);
    }

    //GetPice
    public int GetPrice(TopType type)
    {
        return topSkinData.GetSkinPrice(type);
    }
    public int GetPrice(PantType type)
    {
        return pantSkinData.GetSkinPrice(type);
    }
    public int GetPrice(ShieldType type)
    {
        return shieldSkinData.GetSkinPrice(type);
    }
    public int GetPrice(SetType type)
    {
        return setSkinData.GetSkinPrice(type);
    }
}

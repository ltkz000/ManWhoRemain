using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinDataManager : Singleton<SkinDataManager>
{
    [SerializeField] private TopSkinData topSkinData;
    [SerializeField] private PantSkinData pantSkinData;
    [SerializeField] private ShieldSkinData shieldSkinData;
    [SerializeField] private SetSkinData setSkinData;

    private void Start() 
    {
        // topSkinData.topData = SaveData.current.topData;
        // pantSkinData.pantData = SaveData.current.pantData;
        // shieldSkinData.shieldData = SaveData.current.shieldData;
        // setSkinData.setData = SaveData.current.setData;
    }

    public TopData GetTopData()
    {
        return topSkinData.topData;
    }
    public PantData GetPantData()
    {
        return pantSkinData.pantData;
    }
    public ShieldData GetShieldData()
    {
        return shieldSkinData.shieldData;
    }
    public SetData GetSetData()
    {
        return setSkinData.setData;
    }

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

    //Unlock
    public void UnlockSkin(TopType type)
    {
        topSkinData.ChangeSkinStatus(type, false);
    }
    public void UnlockSkin(PantType type)
    {
        pantSkinData.ChangeSkinStatus(type, false);
    }
    public void UnlockSkin(ShieldType type)
    {
        shieldSkinData.ChangeSkinStatus(type, false);
    }
    public void UnlockSkin(SetType type)
    {
        setSkinData.ChangeSkinStatus(type, false);
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

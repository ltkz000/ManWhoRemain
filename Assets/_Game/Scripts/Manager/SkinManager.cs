using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkinColor
{
    Red,
    Green,
    Blue,
    Gray,
    Yellow,
    White,
    Deadpool,
    Thor
}

public class SkinManager : Singleton<SkinManager>
{
    [SerializeField] public List<Skin> skinList;

    public Material GenerateSkin()
    {
        int rdNumber = Random.Range(0, skinList.Count);
        
        return skinList[rdNumber].material;
    }
}

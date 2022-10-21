using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIChooseSet : MonoBehaviour, IChooseSkin<SetType>
{
    [SerializeField] private SetType currentType;

    public SetType GetSkinType()
    {
        return currentType;
    } 

    public void ChangeSkinType(SetType newType)
    {
        currentType = newType;
    }
}

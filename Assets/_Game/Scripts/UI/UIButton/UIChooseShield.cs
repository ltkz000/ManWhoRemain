using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIChooseShield : MonoBehaviour, IChooseSkin<ShieldType>
{
    [SerializeField] private ShieldType currentType;

    public ShieldType GetSkinType()
    {
        return currentType;
    } 

    public void ChangeSkinType(ShieldType newType)
    {
        currentType = newType;
    }
}

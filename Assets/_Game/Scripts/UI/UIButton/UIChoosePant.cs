using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIChoosePant : MonoBehaviour, IChooseSkin<PantType>
{
    [SerializeField] private PantType currentType;

    public PantType GetSkinType()
    {
        return currentType;
    } 

    public void ChangeSkinType(PantType newType)
    {
        currentType = newType;
    }
}

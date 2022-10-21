using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIChooseTop : MonoBehaviour, IChooseSkin<TopType>
{
    [SerializeField] private TopType currentType;

    public TopType GetSkinType()
    {
        return currentType;
    } 

    public void ChangeSkinType(TopType newType)
    {
        currentType = newType;
    }
}

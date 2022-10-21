using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISkinField : MonoBehaviour
{
    [SerializeField] private SkinID fieldID;
    [SerializeField] private GameObject thisField;

    public SkinID GetFieldID()
    {   
        return fieldID;
    }

    public void ActiveField()
    {
        thisField.SetActive(true);
    }

    public void DeactiveField()
    {
        thisField.SetActive(false);
    }
}

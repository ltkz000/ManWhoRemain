using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinHolder : MonoBehaviour
{
    [SerializeField] private int ID;
    [NonReorderable] public List<GameObject> skins;

    public int GetButtonID()
    {
        return this.ID;
    }
    
    public void SetButtonID(int id)
    {
        this.ID = id;
    }

    public void enableSkin(int index)
    {
        skins[index].SetActive(true);
    }

    public void disableSkin(int index)
    {
        skins[index].SetActive(false);
    }
}

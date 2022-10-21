using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TopRef
{
    [SerializeField] private TopType topType;
    [SerializeField] private GameObject topSkin;

    public TopType GetTopType()
    {
        return topType;
    }

    public GameObject GetTopSkin()
    {
        return topSkin;
    }
}

[System.Serializable]
public class PantRef
{
    [SerializeField] private PantType pantType;
    [SerializeField] private Material pantMaterial;

    public PantType GetPantType()
    {
        return pantType;
    }

    public Material GetPantMaterial()
    {
        return pantMaterial;
    }
}

[System.Serializable]
public class ShieldRef
{
    [SerializeField] private ShieldType shieldType;
    [SerializeField] private GameObject shieldSkin;

    public ShieldType GetShieldType()
    {
        return shieldType;
    }

    public GameObject GetShieldSkin()
    {
        return shieldSkin;
    }
}

[System.Serializable]
public class SetRef
{
    [SerializeField] private SetType setType;
    [SerializeField] private GameObject setHead;
    [SerializeField] private GameObject setBack;
    [SerializeField] private GameObject setLeftHand;
    [SerializeField] private Material setMaterial;

    public SetType GetSetType()
    {
        return setType;
    }

    public void ActiveSet()
    {
        if(setHead != null){    setHead.SetActive(true);    }
        if(setBack != null){    setBack.SetActive(true);    }
        if(setLeftHand != null){    setLeftHand.SetActive(true);    }
    }

    public void DeactiveSet()
    {
        if(setHead != null){    setHead.SetActive(false);    }
        if(setBack != null){    setBack.SetActive(false);    }
        if(setLeftHand != null){    setLeftHand.SetActive(false);    }
    }

    public Material GetSetMaterial()
    {
        return setMaterial;
    }

    public GameObject GetLeftHand()
    {
        return setLeftHand;
    }

    public GameObject GetTop()
    {
        return setHead;
    }
}

public class PlayerSkinControll : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer pantRenderer;
    [SerializeField] private SkinnedMeshRenderer setRenderer;
    [SerializeField] private Material defaultMaterial;
    [SerializeField, NonReorderable] private List<TopRef> topRefs;
    [SerializeField, NonReorderable] private List<PantRef> pantRefs;
    [SerializeField, NonReorderable] private List<ShieldRef> shieldRefs;
    [SerializeField, NonReorderable] private List<SetRef> setRefs;

    public void ShowPreviewTop(TopType previewType)
    {
        foreach(var temp in topRefs)
        {
            if(temp.GetTopType() == previewType)
            {
                temp.GetTopSkin().SetActive(true);
            }
            else
            {
                temp.GetTopSkin().SetActive(false);
            }
        }
    }

    public GameObject GetTop(TopType previewType)
    {
        foreach(var temp in topRefs)
        {
            if(temp.GetTopType() == previewType)
            {
                return temp.GetTopSkin();
            }
        }

        return null;
    }

    public void ShowPreviewPant(PantType previewType)
    {
        foreach(var temp in pantRefs)
        {
            if(temp.GetPantType() == previewType)
            {
                pantRenderer.material = temp.GetPantMaterial();
                break;
            }
        }
    }

    public void ShowPreviewShield(ShieldType previewType)
    {  
        foreach(var temp in shieldRefs)
        {
            if(temp.GetShieldType() == previewType)
            {
                temp.GetShieldSkin().SetActive(true);
            }
            else
            {
                temp.GetShieldSkin().SetActive(false);
            }
        }
    }

    public GameObject GetLeftHandShield(ShieldType previewType)
    {
        foreach(var temp in shieldRefs)
        {
            if(temp.GetShieldType() == previewType)
            {
                return temp.GetShieldSkin();
            }
        }

        return null;
    }

    public void ShowPreviewSet(SetType previewType)
    {
        foreach(var temp in setRefs)
        {
            if(temp.GetSetType() == previewType)
            {
                temp.ActiveSet();

                if(temp.GetSetMaterial() != null)
                {
                    Material[] newMaterials = setRenderer.materials;
                    newMaterials[0] = temp.GetSetMaterial();
                    setRenderer.materials = newMaterials;
                }
            }
            else
            {
                temp.DeactiveSet();
            }
        }
    }

    public GameObject GetTopSet(SetType previewType)
    {
        foreach(var temp in setRefs)
        {
            if(temp.GetSetType() == previewType)
            {
                return temp.GetTop();
            }
        }

        return null;
    }

    public GameObject GetLeftHandSet(SetType previewType)
    {
        foreach(var temp in setRefs)
        {
            if(temp.GetSetType() == previewType)
            {
                return temp.GetLeftHand();
            }
        }

        return null;
    }
}

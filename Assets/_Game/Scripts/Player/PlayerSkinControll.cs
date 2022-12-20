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

    public GameObject GetBack()
    {
        return setBack;
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

    //ActualSkin
    [SerializeField] private GameObject topSkin;
    [SerializeField] private Material pantMaterial;
    [SerializeField] private GameObject shieldSkin;
    [SerializeField] private SetRef setRef;

    private void Start() 
    {
        GetPlayerDataSkin();
        ChooseSkinToActive();
    }

    public void GetPlayerDataSkin()
    {
        topSkin = GetPreviewTop(PlayerDataManager.Ins.GetPlayerTopID());
        pantMaterial = GetPreviewPant(PlayerDataManager.Ins.GetPlayerPantID());
        shieldSkin = GetPreviewLeftHand(PlayerDataManager.Ins.GetPlayerShieldID());
        setRef = GetPreviewSet(PlayerDataManager.Ins.GetPlayerSetID());
    }

    public void PreviewDefault()
    {
        pantRenderer.material = defaultMaterial;
        setRenderer.material = defaultMaterial;
    }

    //Get-Set
    public GameObject GetTopSkin()
    {
        return topSkin;
    }
    public Material GetPantMaterial()
    {
        return pantMaterial;
    }
    public GameObject GetShieldSkin()
    {
        return shieldSkin;
    }
    public SetRef GetSetRef()
    {
        return setRef;
    }

    public void ChangeTopSkin(GameObject newSkin, TopType newType)
    {
        topSkin = newSkin;

        PlayerDataManager.Ins.ChangePlayerTopID(newType);
    }
    public void  ChangePantMaterial(Material newMat, PantType newType)
    {
        pantMaterial = newMat;

        PlayerDataManager.Ins.ChangePlayerPantID(newType);
    }
    public void ChangeShieldSkin(GameObject newSkin, ShieldType newType)
    {
        shieldSkin = newSkin;

        PlayerDataManager.Ins.ChangePlayerShieldID(newType);
    }
    public void ChangeSetSkin(SetType newType)
    {
        setRef = GetPreviewSet(newType);

        PlayerDataManager.Ins.ChangePlayerSetID(newType);
    }

    public GameObject GetPreviewTop(TopType previewType)
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

    public Material GetPreviewPant(PantType previewType)
    {
        foreach(var temp in pantRefs)
        {
            if(temp.GetPantType() == previewType)
            {
                return temp.GetPantMaterial();
            }
        }
        return null;
    }

    public void PreviewPant(Material pantMat)
    {
        pantRenderer.material = pantMat;
    }

    public void DisablePreviewPant()
    {
        pantRenderer.material = defaultMaterial;
    }

    public void UnequipPant()
    {
        pantRenderer.material = defaultMaterial;
    }

    public GameObject GetPreviewLeftHand(ShieldType previewType)
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

    public SetRef GetPreviewSet(SetType previewType)
    {
        foreach(var temp in setRefs)
        {
            if(temp.GetSetType() == previewType)
            {
                return temp;
            }
        }
        return null;
    }

    public void PreviewSet(Material newMat)
    {
        setRenderer.material = newMat;
    }

    public void PreviewNotSet()
    {
        setRenderer.material = defaultMaterial;
    }

    public void ActiveSetSkin()
    {
        setRef.ActiveSet();
        setRenderer.material = setRef.GetSetMaterial();
        pantRenderer.material = pantMaterial;
    }

    public void DeactiveSetSkin()
    {
        setRef.DeactiveSet();
        setRenderer.material = defaultMaterial;
    }

    public void ActiveActualSkin()
    {
        if(topSkin != null)
        {
            topSkin.SetActive(true);
        }
        if(pantMaterial != null)
        {
            pantRenderer.material = pantMaterial;
        }
        if(shieldSkin != null)
        {
            shieldSkin.SetActive(true);
        }
    }

    public void DeactiveActualSkin()
    {
        if(topSkin != null)
        {
            topSkin.SetActive(false);
        }
        if(shieldSkin != null)
        {
            shieldSkin.SetActive(false);
        }
    }

    public void ChooseSkinToActive()
    {
        if(setRef.GetSetType() != SetType.None)
        {
            DeactiveActualSkin();
            ActiveSetSkin();
        }
        else
        {
            ActiveActualSkin();
        }
    }
}

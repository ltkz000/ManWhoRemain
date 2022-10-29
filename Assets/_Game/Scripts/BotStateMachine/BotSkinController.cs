using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSkinController : MonoBehaviour
{
    [SerializeField, NonReorderable] private List<TopRef> topRefs;
    [SerializeField, NonReorderable] private List<PantRef> pantRefs;
    [SerializeField, NonReorderable] private List<ShieldRef> shieldRefs;
    [SerializeField, NonReorderable] private List<SetRef> setRefs;
    private SetRef setSkin; 

    [SerializeField] private SkinnedMeshRenderer pantRenderer;
    [SerializeField] private SkinnedMeshRenderer skinRenderer;
    public Color skinColor;

    private void Start() 
    {
        GenerateSkinColor();
        // GenerateSet();

        // if(setSkin.GetSetType() != SetType.None)
        // {
        //     setSkin.ActiveSet();
        //     skinRenderer.material = setSkin.GetSetMaterial();
        // }
        // else
        // {
        //     GenerateTop();
        //     GeneratePant();
        //     GenerateShield();
        // }

        GenerateTop();
        GeneratePant();
        GenerateShield();
    }

    private void GenerateSkinColor()
    {
        Skin skin = SkinManager.Ins.GenerateSkin();
        skinColor = skin.skinColor;
        skinRenderer.material = skin.material;
    }

    private void GenerateTop()
    {
        int randomNum = Random.Range(0, topRefs.Count - 1);
        if(topRefs[randomNum].GetTopType() != TopType.None)
        {
            topRefs[randomNum].GetTopSkin().SetActive(true);
        }
    }
    private void GeneratePant()
    {
        int randomNum = Random.Range(0, pantRefs.Count - 1);
        if(pantRefs[randomNum].GetPantType() != PantType.None)
        {
            pantRenderer.material = pantRefs[randomNum].GetPantMaterial();
        }
    }
    private void GenerateShield()
    {
        int randomNum = Random.Range(0, shieldRefs.Count - 1);
        if(shieldRefs[randomNum].GetShieldType() != ShieldType.None)
        {
            shieldRefs[randomNum].GetShieldSkin().SetActive(true);
        }
    }
    private void GenerateSet()
    {
        int randomNum = Random.Range(0, setRefs.Count - 1);
        setSkin = setRefs[randomNum];
    }
}

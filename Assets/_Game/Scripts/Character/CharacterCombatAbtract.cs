using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombatAbtract : MonoBehaviour
{
    public Transform characterTransform;
    public bool isAttackalbe;
    public bool attackIng;
    public bool alreadyAttacked;
    public bool isDead;
    public float attackRange;
    public GameObject lockedObj;
    public GameObject rangeObj;
    public AnimationController _animationController;
    public List<CharacterCombatAbtract> targetList;
    
    //Skin and WeaponData
    [SerializeField] protected List<WeaponRef> weaponRefs;
    // [SerializeField] protected SkinnedMeshRenderer weaponRenderer;
    [SerializeField] protected SkinnedMeshRenderer skinRenderer; 
    public WeaponID characterweaponID;
    public SkinColor skinColor;
    public SkinColor weaponColor;
    public Weapon characterWeaponScript;

    public void Awake() 
    {
        isDead = false;

        targetList = new List<CharacterCombatAbtract>();

        initWeapon();
        initSkin();
    }

    //Init character skin
    protected void initSkin()
    {
        for(int i = 0; i < SkinManager.Ins.skinList.Count; i++)
        {
            if(SkinManager.Ins.skinList[i].color == skinColor)
            {
                skinRenderer.material = SkinManager.Ins.skinList[i].material;
                break;
            }
        }
    }

    //Get the weapon on character hand
    protected void initWeapon()
    {
        foreach(WeaponRef temp in weaponRefs)
        {
            if(temp.weaponID == characterweaponID)
            {
                characterWeaponScript = temp.weaponScript;
                break;
            }
        }

        if(characterWeaponScript != null)
        {
            characterWeaponScript.InitOnHand();
            Debug.Log(characterWeaponScript.name);
        }
    }

    public void AddTarget(CharacterCombatAbtract target)
    {
        targetList.Add(target);
        alreadyAttacked = false;
    }

    public void RemoveTarget(CharacterCombatAbtract target)
    {
        targetList.Remove(target);
        target.lockedObj.SetActive(false);
    }

    public void UpdateOnKill(CharacterCombatAbtract target)
    {
        targetList.Remove(target);
    }

    //When character being target of other
    public void BeingLocked()
    {
        lockedObj.SetActive(true);
    }

    //When character be killed
    public void BeingKilled()
    {
        isDead = true;
        targetList.Clear();

        lockedObj.SetActive(false);

        Invoke(nameof(DisappearAfterKilled), ConstValues.DEAD_ANIM_TIME);
    }

    public void DisappearAfterKilled()
    {
        gameObject.SetActive(false);
    }
    
    //Get the weapon back to WeaponPool
    public void PoolBackWeapon(GameObject weapon)
    {
        WeaponManager.Ins.ReturnToPool(weapon);
    }

    public void ChangeAttackStatus(bool status)
    {
        alreadyAttacked = status;
    }

    public void EnableAttack(bool attack)
    {
        isAttackalbe = attack;
    }   
}

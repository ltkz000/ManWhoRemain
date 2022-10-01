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
    public CapsuleCollider capsuleCollider;
    public GameObject lockedObj;
    public GameObject rangeObj;
    public AnimationController _animationController;
    public List<CharacterCombatAbtract> targetList;

    [SerializeField] protected AttackRange attackRangeScript;
    
    //Skin and WeaponData
    [SerializeField] protected List<WeaponRef> weaponRefs;
    [SerializeField] protected SkinnedMeshRenderer skinRenderer; 
    public WeaponID characterWeaponID;

    public Weapon characterWeaponScript;

    public void Awake() 
    {
        isDead = false;

        targetList = new List<CharacterCombatAbtract>();
    
        InitSkin();
    }

    //Init character skin
    protected virtual void InitSkin()
    {
    }

    //Get the weapon on character hand
    protected void InitWeapon()
    {
        foreach(WeaponRef temp in weaponRefs)
        {
            if(temp.weaponID == characterWeaponID)
            {
                characterWeaponScript = temp.weaponScript;
                break;
            }
        }

        if(characterWeaponScript != null)
        {
            characterWeaponScript.InitOnHand();
        }
    }

    protected void InitWeaponSkin()
    {

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

    public virtual void UpdateOnKill(CharacterCombatAbtract target)
    {
        transform.localScale += transform.localScale*0.1f;
        targetList.Remove(target);
    }

    //When character being target of other
    public void BeingLocked()
    {
        lockedObj.SetActive(true);
    }

    //When character be killed
    public virtual void BeingKilled()
    {
        isDead = true;
        targetList.Clear();
        lockedObj.SetActive(false);
        capsuleCollider.enabled = false;

        attackRangeScript.enabled = false;

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

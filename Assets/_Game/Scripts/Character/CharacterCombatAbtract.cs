using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombatAbtract : MonoBehaviour
{
    //Logic
    public Transform characterTransform;
    public bool isAttackalbe;
    public bool attackIng;
    public bool alreadyAttacked;
    public bool isDead;
    public float attackRange;
    public CapsuleCollider capsuleCollider;
    public GameObject lockedObj;
    public GameObject rangeObj;
    public Animator animator;
    public List<CharacterCombatAbtract> targetList;

    [SerializeField] protected AttackRange attackRangeScript;

    //Audio
    public AudioSource throwSound;
    public AudioSource hitSound;
    public AudioSource levelSound;
    
    //Skin and Data
    [SerializeField, NonReorderable] protected List<WeaponRef> weaponRefs;
    [SerializeField] protected SkinnedMeshRenderer skinRenderer; 
    public Pooler weaponPooler;
    public WeaponID characterWeaponID;

    public Weapon characterWeaponScript;
    protected GameObject newWeapon;
    protected int level;

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
    protected void InitWeapon(GameObject weapon)
    {
        foreach(WeaponRef temp in weaponRefs)
        {
            if(temp.weaponID == characterWeaponID)
            {
                // characterWeaponScript = temp.weaponScript;
                newWeapon = Instantiate(weapon, temp.weaponTranform.position, temp.weaponTranform.rotation, temp.weaponTranform.parent);
                break;
            }
        }

        characterWeaponScript = newWeapon.GetComponent<Weapon>();
        characterWeaponScript.InitOnHand();
    }

    public GameObject GetCharacterWeapon()
    {
        return WeaponDataManager.Ins.GetWeaponByID(characterWeaponID);
    }

    public void AddTarget(CharacterCombatAbtract target)
    {
        targetList.Add(target);
        alreadyAttacked = false;
    }

    public void RemoveTarget(CharacterCombatAbtract target)
    {
        targetList.Remove(target);
        target.DisableLock();
    }

    public virtual void UpdateOnKill(CharacterCombatAbtract target)
    {
        if(level < ConstValues.MAX_LEVEL)
        {
            transform.localScale += transform.localScale*0.1f;
            attackRange += attackRange*0.1f;
        }
        level++;
        targetList.Remove(target);

        PlaySound(levelSound);
    }

    //When character being target of other
    public void BeingLocked()
    {
        lockedObj.SetActive(true);
    }

    public void DisableLock()
    {
        lockedObj.SetActive(false);
    }

    //When character be killed
    public virtual void BeingKilled()
    {
        for(int i = 0; i < targetList.Count; i++)
        {
            targetList[i].DisableLock();
        }
        targetList.Clear();
        lockedObj.SetActive(false);

        isDead = true;
        capsuleCollider.enabled = false;
        attackRangeScript.enabled = false;

        PlaySound(hitSound);
        Invoke(nameof(DisappearAfterKilled), ConstValues.DEAD_ANIM_TIME);
    }

    public virtual void DisappearAfterKilled()
    {
        gameObject.SetActive(false);
    }
    
    //Get the weapon back to WeaponPool
    public void PoolBackWeapon(GameObject weapon)
    {
        weaponPooler.ReturnObject(weapon);
    }

    public void ChangeAttackStatus(bool status)
    {
        alreadyAttacked = status;
    }

    public void EnableAttack(bool attack)
    {
        isAttackalbe = attack;
    }   

    public void PlaySound(AudioSource sound)
    {
        sound.Play();
    }

    public void TriggerAnimation(string animTrigger)
    {
        animator.SetTrigger(animTrigger);
    }

    // public AnimationController GetAnimationController()
    // {
    //     return _animationController;
    // }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombatAbtract : MonoBehaviour,IHit
{
    //Logic
    [Header ("-------LOGIC------")]
    public Transform characterTransform;
    public bool isAttackalbe;
    public bool isAttacked;
    public bool isThrowalbe;
    public bool isAttacking;
    public bool isDead;
    public bool haveUlti;
    public float attackRange;
    private float deadTimer;
    public CapsuleCollider capsuleCollider;
    public GameObject lockedObj;
    public GameObject rangeObj;
    public Animator animator;
    public List<CharacterCombatAbtract> targetList;
    [SerializeField] protected GameObject throwWeapon;
    [SerializeField] protected GameObject attackRangeObject;

    //Audio
    [Header ("-------AUDIO------")]
    public AudioSource throwSound;
    public AudioSource hitSound;
    public AudioSource levelSound;

    //VFX
    [Header ("-------VFX------")]
    [SerializeField] protected ParticleSystem hitEffect;
    [SerializeField] protected ParticleSystem upgradeEffect;
    [SerializeField] protected ParticleSystem deadEffect;
    
    //Skin and Data
    [SerializeField, NonReorderable] protected List<WeaponRef> weaponRefs;
    public Pooler weaponPooler;
    public WeaponID characterWeaponID;

    public Weapon characterWeaponScript;
    protected GameObject newWeapon;
    [SerializeField] protected int level;

    public void Awake() 
    {
        OnInit();

        targetList = new List<CharacterCombatAbtract>();
    
        InitSkin();
    }

    public void OnInit()
    {
        isAttackalbe = false;
        isAttacked = false;
        isThrowalbe = true;
        isAttacking = false;

        isDead = false;
        haveUlti = false;

        // characterTransform.position = Vector3.zero;
        // characterTransform.rotation = Quaternion.Euler(0, 180, 0);
        // characterTransform.localScale = Vector3.one;
    }

    //Init character skin
    protected virtual void InitSkin(){}

    //Get the weapon on character hand
    protected void InitWeapon(GameObject weapon)
    {
        foreach(WeaponRef temp in weaponRefs)
        {
            if(temp.weaponID == characterWeaponID)
            {
                newWeapon = Instantiate(weapon, temp.weaponTranform.position, temp.weaponTranform.rotation, temp.weaponTranform.parent);
                break;
            }
        }

        characterWeaponScript = newWeapon.GetComponent<Weapon>();
        characterWeaponScript.InitOnHand();
    }

    public Transform GetCharacterTranform()
    {
        return characterTransform;
    }

    public virtual GameObject GetCharacterWeapon()
    {
        return null;
    }

    public void AddTarget(CharacterCombatAbtract target)
    {
        targetList.Add(target);
    }

    public void RemoveTarget(CharacterCombatAbtract target)
    {
        targetList.Remove(target);
        target.DisableLock();
    }

    public virtual void UpdateOnKill(CharacterCombatAbtract target)
    {
        TriggerVFX(VFX.upgradeEffect);

        if(level < ConstValues.MAX_LEVEL)
        {
            characterTransform.localScale += characterTransform.localScale*0.1f;
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
        TriggerVFX(VFX.hitEffect);
        TriggerAnimation(ConstValues.ANIM_TRIGGER_DEAD);

        isDead = true;
        capsuleCollider.enabled = false;
        attackRangeObject.SetActive(false);

        for(int i = 0; i < targetList.Count; i++)
        {
            targetList[i].DisableLock();
        }
        targetList.Clear();
        lockedObj.SetActive(false);

        PlaySound(hitSound);
        Invoke(nameof(DisappearAfterKilled), ConstValues.DEAD_ANIM_TIME);
    }

    public virtual void DisappearAfterKilled()
    {
        TriggerVFX(VFX.deadEffect);

        gameObject.SetActive(false);
        // deadTimer = 0;
    }
    
    //Get the weapon back to WeaponPool
    public void PoolBackWeapon(GameObject weapon)
    {
        weaponPooler.ReturnObject(weapon);
    }

    public void IsAttackalbe(bool status)
    {
        isAttackalbe = status;
    }   

    public void IsAttacked(bool status)
    {
        isAttacked = status;
    }

    public void IsThrowable(bool status)
    {
        isThrowalbe = status;
    }

    public void PlaySound(AudioSource sound)
    {
        sound.Play();
    }

    public void TriggerAnimation(string animTrigger)
    {
        animator.SetTrigger(animTrigger);
    }

    public void TriggerVFX(VFX vfxEffect)
    {
        switch(vfxEffect)
        {
            case VFX.hitEffect:
                hitEffect.Play();
                break;
            case VFX.upgradeEffect:
                upgradeEffect.Play();
                break;
            case VFX.deadEffect:
                deadEffect.Play();
                break;
        }
    }

    public void OnDestroy() 
    {
        weaponPooler.DestroyPool();   
    }

    public void OnHit()
    {

    }
}

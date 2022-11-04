using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CharacterCombat : CharacterCombatAbtract
{
    [SerializeField] private Transform throwPoint;
    [SerializeField] private SkinColor skinColor;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private TextMeshPro nameText;

    //Skin
    [SerializeField] private SkinnedMeshRenderer pantSkin;

    private float delayThrowWeapon;
    private float attackAnimTime;
    private bool throwing;

    private void Start() 
    {
        InitPlayerWeapon();
        delayThrowWeapon = ConstValues.DELAY_THROWWEAPON_TIME;
        attackAnimTime = ConstValues.ATTACK_ANIM_TIME;
    }

    public void InitPlayerWeapon()
    {
        characterWeaponID = PlayerDataManager.Ins.GetPlayerWeaponID();

        InitWeapon(WeaponDataManager.Ins.GetWeaponByID(characterWeaponID));
    }

    public void ChangePlayerWeapon()
    {
        Destroy(newWeapon);

        characterWeaponID = PlayerDataManager.Ins.GetPlayerWeaponID();

        InitWeapon(WeaponDataManager.Ins.GetWeaponByID(characterWeaponID));
    }

    private void Update() 
    {
        SelectTarget(); 
    }

    private void SelectTarget()
    {
        if(targetList.Count > 0)
        {
            targetList[0].BeingLocked();

            if(alreadyAttacked == false && isAttackalbe == true)
            {
                Attack(targetList[0]);
            }
        }
        // else
        // {
        //     alreadyAttacked = false;
        //     characterWeaponScript.AppearOnHand();
        //     attackIng = false;
        //     delayThrowWeapon = ConstValues.DELAY_THROWWEAPON_TIME;
        //     attackAnimTime = ConstValues.ATTACK_ANIM_TIME;
        // }
    }

    // private void Attack(CharacterCombatAbtract target)
    // {
    //     attackIng = true;
    //     if(delayThrowWeapon > 0)
    //     {
    //         delayThrowWeapon -= Time.deltaTime;
    //     }
    //     if(attackAnimTime > 0)
    //     {
    //         attackAnimTime -= Time.deltaTime;
    //     }

    //     characterTransform.LookAt(target.transform.position);

    //     if(delayThrowWeapon < 0)
    //     {
    //         Debug.Log("throw");
    //         characterWeaponScript.DisappearOnHand();

    //         PlaySound(throwSound);

    //         GameObject throwWeapon = weaponPooler.GetObject(WeaponManager.Ins.transform);
    //         throwWeapon.transform.localScale = characterTransform.localScale;

    //         Weapon weaponScipt = throwWeapon.GetComponent<Weapon>();
    //         weaponScipt.Fly(this ,target.characterTransform);

    //         delayThrowWeapon = 0;
    //     }

    //     if(target.isDead == true)
    //     {
    //         RemoveTarget(target);
    //     }
        
    //     if(attackAnimTime < 0)
    //     {
    //         characterWeaponScript.AppearOnHand();
    //         alreadyAttacked = true;
    //         attackIng = false;
    //         delayThrowWeapon = ConstValues.DELAY_THROWWEAPON_TIME;
    //         attackAnimTime = ConstValues.ATTACK_ANIM_TIME;
    //     }
    // }

    private void Attack(CharacterCombatAbtract target)
    {
        alreadyAttacked = true;
        
        characterTransform.LookAt(target.transform.position);

        StartCoroutine(TriggerAttack());

        // GameObject throwWeapon = weaponPooler.GetObject(WeaponManager.Ins.transform);

        // throwWeapon.transform.localScale = characterTransform.localScale;
        
        // Weapon weaponScipt = throwWeapon.GetComponent<Weapon>();
        // weaponScipt.Fly(this ,target.characterTransform);
        StartCoroutine(ThrowWeapon(target));

        if(target.isDead == true)
        {
            RemoveTarget(target);
        }
    }

    IEnumerator ThrowWeapon(CharacterCombatAbtract target)
    {
        yield return new WaitForSeconds(ConstValues.DELAY_THROWWEAPON_TIME);

        characterWeaponScript.DisappearOnHand();

        GameObject throwWeapon = weaponPooler.GetObject(WeaponManager.Ins.transform);
        throwWeapon.transform.localScale = characterTransform.localScale;

        Weapon weaponScript = throwWeapon.GetComponent<Weapon>();
        weaponScript.Fly(this, target.characterTransform);
    }

    IEnumerator TriggerAttack()
    {
        attackIng = true;
        // characterWeaponScript.DisappearOnHand();

        // PlaySound(throwSound);

        yield return new WaitForSeconds(ConstValues.ATTACK_ANIM_TIME);

        attackIng = false;
        characterWeaponScript.AppearOnHand();
    }

    public override void UpdateOnKill(CharacterCombatAbtract target)
    {
        base.UpdateOnKill(target);

        if(level < ConstValues.MAX_LEVEL)
        {
            cameraController.UpdateOffset();
        }

        PlayerDataManager.Ins.UpdatePlayerGold();
    }

    public override void DisappearAfterKilled()
    {
        base.DisappearAfterKilled();
        UIManager.Ins.OpenUI(UICanvasID.Lose);
    }

    public void ActiveNameText()
    {
        nameText.text = PlayerDataManager.Ins.GetPlayerName();
        nameText.gameObject.SetActive(true);
    }
    public void DeactiveNameText()
    {
        nameText.gameObject.SetActive(false);
    }
}

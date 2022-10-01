using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : CharacterCombatAbtract
{
    [SerializeField] private Transform throwPoint;
    [SerializeField] private SkinColor skinColor;

    private void Start() 
    {
        InitPlayerWeapon();
    }

    protected override void InitSkin()
    {
        base.InitSkin();
        for(int i = 0; i < SkinManager.Ins.skinList.Count; i++)
        {
            if(SkinManager.Ins.skinList[i].color == skinColor)
            {
                skinRenderer.material = SkinManager.Ins.skinList[i].material;
                break;
            }
        }
    }

    private void InitPlayerWeapon()
    {
        characterWeaponID = PlayerDataManager.Ins.GetPlayerWeaponID();

        InitWeapon();
    }

    private void Update() 
    {
        SelectTarget();
    }

    private void SelectTarget()
    {
        if(targetList.Count > 0)
        {
            if(alreadyAttacked == false && isAttackalbe == true)
            {
                Attack(targetList[0]);
            }

            targetList[0].BeingLocked();
        }
    }

    private void Attack(CharacterCombatAbtract target)
    {
        alreadyAttacked = true;
        
        characterTransform.LookAt(target.transform.position);

        StartCoroutine(TriggerAttack());

        GameObject throwWeapon =  WeaponManager.Ins.SpawnFromPool(characterWeaponID, throwPoint.transform.position);
        
        Weapon weaponScipt = throwWeapon.GetComponent<Weapon>();
        weaponScipt.Fly(this ,target.characterTransform);
    }

    public override void UpdateOnKill(CharacterCombatAbtract target)
    {
        base.UpdateOnKill(target);
        PlayerDataManager.Ins.UpdatePlayerGold();
    }

    IEnumerator TriggerAttack()
    {
        attackIng = true;
        characterWeaponScript.DisappearOnHand();

        yield return new WaitForSeconds(ConstValues.ATTACK_ANIM_TIME);

        attackIng = false;
        characterWeaponScript.AppearOnHand();
    }
}

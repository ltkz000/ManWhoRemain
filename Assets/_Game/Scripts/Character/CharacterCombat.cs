using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : CharacterCombatAbtract
{
    [SerializeField] private Transform throwPoint;

    private void Update() 
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

        GameObject throwWeapon =  WeaponManager.Ins.SpawnFromPool(characterweaponID, throwPoint.transform.position);
        
        Weapon weaponScipt = throwWeapon.GetComponent<Weapon>();
        weaponScipt.Fly(this ,target.characterTransform);
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

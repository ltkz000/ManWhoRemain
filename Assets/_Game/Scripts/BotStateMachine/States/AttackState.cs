using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState<Character>
{
    private float delayAttackAnim;
    public void OnEnter(Character character)
    {
        Debug.Log("ATTACK");

        delayAttackAnim = ConstValues.ATTACK_ANIM_TIME;
    }

    public void OnExecute(Character character)
    {
        delayAttackAnim -= Time.deltaTime;
        character._animationController.PlayAttack();
        character.characterWeaponScript.DisappearOnHand();

        character.PlaySound(character.throwSound);
        
        if(character.alreadyAttacked == false)
        {
            Attack(character, character.targetList[0]);
        }

        if(delayAttackAnim < 0)
        {
            character.characterWeaponScript.AppearOnHand();
            character.ChangeState(character.patrolState);
        }
    }

    private void Attack(Character character, CharacterCombatAbtract target)
    {
        character.ChangeAttackStatus(true);
        character.characterTransform.LookAt(target.transform.position);

        GameObject throwWeapon = character.weaponPooler.GetObject(WeaponManager.Ins.transform);
        
        Weapon weaponScipt = throwWeapon.GetComponent<Weapon>();
        weaponScipt.Fly(character ,target.characterTransform);
    }

    public void OnExit(Character character)
    {
        
    }
}

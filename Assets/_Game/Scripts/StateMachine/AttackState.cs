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
        // AlterCoroutine.Ins.StartAlterCoroutine(TriggerAttack(character));

        GameObject throwWeapon =  WeaponManager.Ins.SpawnFromPool(character.characterweaponID, character.throwPoint.transform.position);
        
        Weapon weaponScipt = throwWeapon.GetComponent<Weapon>();
        weaponScipt.Fly(character ,target.characterTransform);
    }

    IEnumerator TriggerAttack(Character character)
    {
        // _attacker.attackIng = true;
        character.characterWeaponScript.DisappearOnHand();

        yield return new WaitForSeconds(ConstValues.ATTACK_ANIM_TIME);

        // _attacker.attackIng = false;
        character.characterWeaponScript.AppearOnHand();
    }

    public void OnExit(Character character)
    {
        
    }

}

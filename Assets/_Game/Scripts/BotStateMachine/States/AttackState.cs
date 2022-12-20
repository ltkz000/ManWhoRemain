using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState<Character>
{
    float timer;
    public void OnEnter(Character character)
    {
        timer = 0;
        character.TriggerAnimation(ConstValues.ANIM_TRIGGER_ATTACK);
    }

    public void OnExecute(Character character)
    {
        timer += Time.deltaTime;

        // character.TriggerAnimation(ConstValues.ANIM_TRIGGER_ATTACK);
        if(character.targetList.Count > 0)
        {
            character.characterTransform.LookAt(character.targetList[0].characterTransform);
        }
        character.characterWeaponScript.DisappearOnHand();

        if(timer >= ConstValues.DELAY_THROWWEAPON_TIME && character.isThrowalbe == true)
        {
            if(character.isAttackalbe == true && character.isAttacked == false && character.targetList.Count > 0)
            {
                if(character.targetList[0].isDead)
                {
                    character.RemoveTarget(character.targetList[0]);
                }
                else
                {
                    Attack(character, character.targetList[0]);
                }
            }
        }

        if(timer >= ConstValues.ATTACK_ANIM_TIME)
        {
            character.characterWeaponScript.AppearOnHand();
            character.ChangeState(character.idleState);
        }
    }

    private void Attack(Character character, CharacterCombatAbtract target)
    {
        character.isThrowalbe = false;
        character.isAttacked = true;
        // character.characterTransform.LookAt(target.transform.position);

        GameObject throwWeapon = character.weaponPooler.GetObject(WeaponManager.Ins.weaponParentTrans);
        
        Weapon weaponScipt = throwWeapon.GetComponent<Weapon>();
        weaponScipt.weaponTransform.localScale = character.GetCharacterTranform().localScale;   
        weaponScipt.Fly(character ,target.characterTransform);
    }

    public void OnExit(Character character)
    {
        
    }
}

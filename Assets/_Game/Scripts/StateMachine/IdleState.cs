using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState<Character>
{
    private float delayIdleToPatrol;
    private float delayRangeMin = 0f;
    private float delayRangeMax = 3f;
    Character _character;

    public void OnEnter(Character character)
    {
        Debug.Log("IDLE");

        _character = character;

        delayIdleToPatrol = UnityEngine.Random.Range(delayRangeMin, delayRangeMax);
        Debug.Log("delayTime: " + delayIdleToPatrol);

        character.EnableAttack(true);
    }

    public void OnExecute(Character character)
    {
        delayIdleToPatrol -= Time.deltaTime;
        character._animationController.PlayIdle();

        if(delayIdleToPatrol < 0)
        {
            character.ChangeState(character.patrolState);
        }
        else
        {
            if(character.targetList.Count > 0)
            {
                character.ChangeState(character.attackState);
            }
        }
    }

    public void OnExit(Character character)
    {

    }
}

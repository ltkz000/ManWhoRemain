using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState<Character>
{
    private float walkPointRange = 20f;
    private float moveSpeed = 5f;
    private float rotateSpeed = 9f;
    private bool walkPointSet;

    public void OnEnter(Character character)
    {
        character.TriggerAnimation(ConstValues.ANIM_TRIGGER_RUN);
        character.IsAttackalbe(false);
        character.IsAttacked(false);
        character.IsThrowable(true);
    }

    public void OnExecute(Character character)
    {
        // character.TriggerAnimation(ConstValues.ANIM_TRIGGER_RUN);

        Move(character);
    }

    private void CheckWalkPoint(Character character)
    {
        float distanceToWalkPoint = Vector3.Distance(character.GetCharacterTranform().position, character.walkPoint);

        if(distanceToWalkPoint < 2f)
        {
            character.ChangeState(character.idleState);
        }
    }

    private void Move(Character character)
    {
        Vector3 walkDir = character.walkPoint - character.GetCharacterTranform().position;
        walkDir.y = 0;
        walkDir = walkDir.normalized;
        character.GetCharacterTranform().position = Vector3.MoveTowards(character.GetCharacterTranform().position, character.GetCharacterTranform().position + walkDir, Time.deltaTime * moveSpeed);

        Vector3 direction = Vector3.RotateTowards(character.GetCharacterTranform().forward, walkDir, rotateSpeed * Time.deltaTime, 0.0f);
        character.GetCharacterTranform().rotation = Quaternion.LookRotation(direction);

        CheckWalkPoint(character);
    }

    public void OnExit(Character character)
    {

    }
}

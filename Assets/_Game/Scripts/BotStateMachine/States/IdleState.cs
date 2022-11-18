using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState<Character>
{
    private float delayIdleToPatrol;
    private float delayRangeMin = 2f;
    private float delayRangeMax = 5f;

    private float walkPointRange = 20f;

    public void OnEnter(Character character)
    {
        // Debug.Log("IDLE");

        delayIdleToPatrol = UnityEngine.Random.Range(delayRangeMin, delayRangeMax);

        character.IsAttackalbe(true);
    }

    public void OnExecute(Character character)
    {
        character.TriggerAnimation(ConstValues.ANIM_TRIGGER_IDLE);

        delayIdleToPatrol -= Time.deltaTime;

        if(character.targetList.Count > 0 && character.isAttacked == false)
        {
            character.ChangeState(character.attackState);
        }

        if(delayIdleToPatrol <= 0 || character.isAttacked == true)
        {
            SearchPatrolPoint(character);
        }
    }

    public void SearchPatrolPoint(Character character)
    {   
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        character.walkPoint = new Vector3(character.characterTransform.position.x + randomX, character.characterTransform.position.y + 1f, character.characterTransform.position.z + randomZ);

        if(Physics.Raycast(character.walkPoint, -character.characterTransform.up, Mathf.Infinity, character.Ground))
        {
            // Debug.DrawRay(character.walkPoint, -character.transform.up, Color.red, Mathf.Infinity);

            Vector3 rayDir = character.walkPoint - character.checkCollidePoint.position;
            float rayDis = Vector3.Distance(character.walkPoint, character.checkCollidePoint.position);

            if(Physics.Raycast(character.checkCollidePoint.position, rayDir, rayDis, character.Obstacle))
            {
                // Debug.DrawRay(character.checkCollidePoint.position, rayDir, Color.black, rayDis);
                delayIdleToPatrol = Random.Range(delayRangeMin, delayRangeMax);
            }
            else
            {
                character.ChangeState(character.patrolState);
            }
        }
        else
        {
            delayIdleToPatrol = Random.Range(delayRangeMin, delayRangeMax);
        }
    }

    public void OnExit(Character character)
    {

    }
}

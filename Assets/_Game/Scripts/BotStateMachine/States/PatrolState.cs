using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState<Character>
{
    private float walkPointRange = 20f;
    private float moveSpeed = 5f;
    private float rotateSpeed = 9f;
    private bool walkPointSet;
    private Vector3 walkPoint;

    public void OnEnter(Character character)
    {
        Debug.Log("PATROL");

        walkPointSet = false;

        character.EnableAttack(false);
        character.ChangeAttackStatus(false);

        SearchWalkPoint(character);
    }

    public void OnExecute(Character character)
    {
        character.TriggerAnimation(ConstValues.ANIM_TRIGGER_RUN);

        if(walkPointSet == true)
        {
            Move(character);

            CheckWalkPoint(character);
        }
        else
        {
            character.ChangeState(character.idleState);
        }
    }

    //Get random position for bot to move
    private void SearchWalkPoint(Character character)
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(character.transform.position.x + randomX, character.transform.position.y, character.transform.position.z + randomZ);

        if(Physics.Raycast(walkPoint, -character.transform.up, Mathf.Infinity, character.Ground))
        {
            Debug.DrawRay(walkPoint, -character.transform.up, Color.black, Mathf.Infinity);
            walkPointSet = true;
        }
    }

    private void CheckWalkPoint(Character character)
    {
        float distanceToWalkPoint = Vector3.Distance(character.transform.position, walkPoint);

        if(distanceToWalkPoint < 1f)
        {
            walkPointSet = false;
        }
    }

    private void Move(Character character)
    {
        Vector3 walkDir = (walkPoint - character.transform.position).normalized;
        character.transform.position = Vector3.MoveTowards(character.transform.position, character.transform.position + walkDir, Time.deltaTime * moveSpeed);

        Vector3 direction = Vector3.RotateTowards(character.transform.forward, walkDir, rotateSpeed * Time.deltaTime, 0.0f);
        character.transform.rotation = Quaternion.LookRotation(direction);
    }

    private void OnTriggerEnter(Collider other, Character character) 
    {
        if(other.CompareTag(ConstValues.OBSTACLE_TAG))
        {
            SearchWalkPoint(character);
        }
    }

    public void OnExit(Character character)
    {

    }
}

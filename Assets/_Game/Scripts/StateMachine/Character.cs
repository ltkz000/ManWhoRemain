using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : CharacterCombatAbtract
{
    //State
    private IState<Character> currentState;
    public AttackState attackState = new AttackState();
    public IdleState idleState = new IdleState();
    public PatrolState patrolState = new PatrolState();
    public DeadState deadState = new DeadState();

    //Needed Component
    public NavMeshAgent agent;

    //Attack
    public Transform throwPoint;

    //Patrol
    public LayerMask Ground;

    private void Start()
    {
        ChangeState(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead == true)
        {
            ChangeState(deadState);
        }

        if(targetList.Count > 0)
        {
            targetList[0].BeingLocked();
        }

        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }

    public void ChangeState(IState<Character> state)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }

        currentState = state;

        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }
}

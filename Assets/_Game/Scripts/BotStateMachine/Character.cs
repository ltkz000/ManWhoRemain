using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : CharacterCombatAbtract
{
    //Attack
    public Transform checkCollidePoint;
    public Color skinColor;

    //Patrol
    public Vector3 walkPoint;
    public LayerMask Ground;
    public LayerMask Obstacle;

    private GameObject botWeapon;

    //State
    private IState<Character> currentState;
    public PauseState pauseState = new PauseState();
    public AttackState attackState = new AttackState();
    public IdleState idleState = new IdleState();
    public PatrolState patrolState = new PatrolState();
    public DeadState deadState = new DeadState();

    private void Start()
    {
        InitBotWeapon();
    }

    private void InitBotWeapon()
    {
        int rdWeapon = Random.Range(0, weaponRefs.Count);
        characterWeaponID = weaponRefs[rdWeapon].weaponID;

        botWeapon = WeaponDataManager.Ins.GetBotWeapon(characterWeaponID);
        InitWeapon(botWeapon);
    }

    public void BotOnSpawn()
    {
        ChangeState(idleState);

        // characterTransform.localScale = Vector3.one;
        isDead = false;
        capsuleCollider.enabled = true;
        attackRangeObject.SetActive(true);
    }

    public override GameObject GetCharacterWeapon()
    {
        base.GetCharacterWeapon();
        return botWeapon;
    }

    public override void BeingKilled()
    {
        base.BeingKilled();
        ChangeState(deadState);
        BotManager.Ins.BotDead();
        BotManager.Ins.SpawnBotFromPool();
    }

    public override void DisappearAfterKilled()
    {
        base.DisappearAfterKilled();
        BotManager.Ins.ReturnBotToPool(this);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Ins.IsState(GameState.Pause) || GameManager.Ins.IsState(GameState.MainMenu))
        {
            ChangeState(pauseState);
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

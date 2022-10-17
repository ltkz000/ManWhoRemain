using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : CharacterCombatAbtract
{
    //State
    private IState<Character> currentState;
    public PauseState pauseState =new PauseState();
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
        InitBotWeapon();
        ChangeState(pauseState);
    }

    protected override void InitSkin()
    {
        base.InitSkin();
        skinRenderer.material = SkinManager.Ins.GenerateSkin();
    }

    private void InitBotWeapon()
    {
        int rdWeapon = Random.Range(0, weaponRefs.Count);
        characterWeaponID = weaponRefs[rdWeapon].weaponID;

        InitWeapon(WeaponDataManager.Ins.GetWeaponByID(characterWeaponID));
    }

    public void BotOnSpawn()
    {
        isDead = false;
        capsuleCollider.enabled = true;
        attackRangeScript.enabled = true;
    }

    public override void DisappearAfterKilled()
    {
        base.DisappearAfterKilled();
        BotManager.Ins.ReturnBotToPool(this.gameObject);
        BotManager.Ins.SpawnBotFromPool();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead == true)
        {
            ChangeState(deadState);
        }

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : IState<Character>
{
    public void OnEnter(Character character)
    {
        Debug.Log("DEAD");
    }

    public void OnExecute(Character character)
    {
        character._animationController.PlayDead();
    }

    public void OnExit(Character character)
    {

    }
}

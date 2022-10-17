using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : IState<Character>
{
    public void OnEnter(Character character)
    {
        Debug.Log("PAUSE");
    }

    public void OnExecute(Character character)
    {
        character.GetAnimationController().PlayIdle();

        if(GameManager.Ins.currentgameState != GameState.Pause)
        {
            character.ChangeState(character.idleState);
        }
    }

    public void OnExit(Character character)
    {

    }
}

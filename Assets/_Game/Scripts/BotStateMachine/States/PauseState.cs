using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : IState<Character>
{
    public void OnEnter(Character character)
    {
        character.TriggerAnimation(ConstValues.ANIM_TRIGGER_IDLE);
    }

    public void OnExecute(Character character)
    {
        if(GameManager.Ins.currentgameState != GameState.Pause)
        {
            Debug.Log("Execute");
            character.ChangeState(character.idleState);
        }
    }

    public void OnExit(Character character)
    {

    }
}

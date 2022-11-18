using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : IState<Character>
{
    public void OnEnter(Character character){}

    public void OnExecute(Character character)
    {
        character.TriggerAnimation(ConstValues.ANIM_TRIGGER_DEAD);
    }

    public void OnExit(Character character){}
}

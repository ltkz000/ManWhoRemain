using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    private void Awake() 
    {   
        animator = GetComponent<Animator>();    
    }
    // Start is called before the first frame update
    public void PlayIdle()
    {
        animator.SetTrigger(ConstValues.ANIM_TRIGGER_IDLE);
    }

    public void PlayRun()
    {
        animator.SetTrigger(ConstValues.ANIM_TRIGGER_RUN);
    }

    public void PlayAttack()
    {
        animator.SetTrigger(ConstValues.ANIM_TRIGGER_ATTACK);
    }

    public void PlayDead()
    {
        animator.SetTrigger(ConstValues.ANIM_TRIGGER_DEAD);
    }
}

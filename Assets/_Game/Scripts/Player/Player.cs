using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform playerTransform;

    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private CharacterCombat _characterCombat;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private Rigidbody rb;

    private string currentAnimName;

    private Vector3 moveVector;

    // float testTimer = 0;
    private void Update() 
    {
        if(_characterCombat.isDead == false)
        {
            Move();
        }
        else
        {
            // _characterCombat.TriggerAnimation(ConstValues.ANIM_TRIGGER_DEAD);
            ChangeAnim(ConstValues.ANIM_TRIGGER_DEAD);
        }
    }

    public FloatingJoystick GetJoystick()
    {
        return _joystick;
    }
    
    public void UpdateJoystick(FloatingJoystick newfloatingJoystick)
    {
        _joystick = newfloatingJoystick;
    }

    private void Move()
    {
        Vector3 direction;
        moveVector = Vector3.zero;
        if(_joystick != null && GameManager.Ins.IsState(GameState.GamePlay))
        {
            moveVector.x = _joystick.Horizontal;
            moveVector.z = _joystick.Vertical;
            // moveVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        }
        moveVector = moveVector.normalized;

        if(moveVector.magnitude != 0)
        {
            direction = Vector3.RotateTowards(playerTransform.forward, moveVector, _rotateSpeed * Time.deltaTime, 0.0f);
            playerTransform.rotation = Quaternion.LookRotation(direction);

            //Change attackable and alreadyAttack bool to let player can hit
            _characterCombat.IsAttackalbe(false);
            _characterCombat.IsAttacked(false);
            _characterCombat.IsThrowable(true);
            // _characterCombat.TriggerAnimation(ConstValues.ANIM_TRIGGER_RUN);
            ChangeAnim(ConstValues.ANIM_TRIGGER_RUN);
        }
        else if(moveVector.magnitude == 0)
        {
            if(GameManager.Ins.IsState(GameState.SkinShop))
            {
                // _characterCombat.TriggerAnimation(ConstValues.ANIM_TRIGGER_DANCESKIN);
                ChangeAnim(ConstValues.ANIM_TRIGGER_DANCESKIN);    
            }
            else
            {
                if(_characterCombat.isAttacking == false)//Start IdleAnimation
                {
                    _characterCombat.IsAttackalbe(true);
                    ChangeAnim(ConstValues.ANIM_TRIGGER_IDLE);
                    // _characterCombat.TriggerAnimation(ConstValues.ANIM_TRIGGER_IDLE);
                }
                else if(_characterCombat.isAttacking == true && _characterCombat.targetList.Count > 0)//Start AttackAnimation
                {
                    ChangeAnim(ConstValues.ANIM_TRIGGER_ATTACK);
                    // _characterCombat.TriggerAnimation(ConstValues.ANIM_TRIGGER_ATTACK);
                }
                else
                {
                    ChangeAnim(ConstValues.ANIM_TRIGGER_IDLE);
                    // _characterCombat.TriggerAnimation(ConstValues.ANIM_TRIGGER_IDLE);
                }
            }
        }

        playerTransform.position = Vector3.MoveTowards(playerTransform.position, playerTransform.position + moveVector, Time.deltaTime * _moveSpeed);
    }

    public void StopMove()
    {
        moveVector = Vector3.zero;
    }

    public void ChangeAnim(string animName)
    {
        if(currentAnimName != animName)
        {
            currentAnimName = animName;
            _characterCombat.TriggerAnimation(currentAnimName);
        }
    }
}

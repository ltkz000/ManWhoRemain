using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform playerTransform;

    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private CharacterCombat _characterCombat;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private Rigidbody rb;

    private Vector3 moveVector;

    private void Update() 
    {
        if(_characterCombat.isDead == false)
        {
            Move();
        }
        else
        {
            _characterCombat.TriggerAnimation(ConstValues.ANIM_TRIGGER_DEAD);
        }
    }

    public void OnInit(){
        
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
            _characterCombat.TriggerAnimation(ConstValues.ANIM_TRIGGER_RUN);
        }
        else if(moveVector.magnitude == 0)
        {
            if(GameManager.Ins.IsState(GameState.SkinShop))
            {
                _characterCombat.TriggerAnimation(ConstValues.ANIM_TRIGGER_DANCESKIN);
            }
            else
            {
                if(_characterCombat.isAttacking == false)//Start IdleAnimation
                {
                    _characterCombat.IsAttackalbe(true);
                    _characterCombat.TriggerAnimation(ConstValues.ANIM_TRIGGER_IDLE);
                }
                else if(_characterCombat.isAttacking == true && _characterCombat.targetList.Count > 0)//Start AttackAnimation
                {
                    _characterCombat.TriggerAnimation(ConstValues.ANIM_TRIGGER_ATTACK);
                }
                else
                {
                    _characterCombat.TriggerAnimation(ConstValues.ANIM_TRIGGER_IDLE);
                }
            }
        }

        playerTransform.position = Vector3.MoveTowards(playerTransform.position, playerTransform.position + moveVector, Time.deltaTime * _moveSpeed);
    }

    public void StopMove()
    {
        moveVector = Vector3.zero;
    }
}

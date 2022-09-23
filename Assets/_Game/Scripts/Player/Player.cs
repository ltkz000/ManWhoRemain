using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform transform;

    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private AnimationController _animationController;
    [SerializeField] private CharacterCombat _characterCombat;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    private Rigidbody rb;
    private Vector3 moveVector;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody>();   
    }

    private void Update() 
    {
        if(_characterCombat.isDead == false)
        {
            Move();
        }
        else
        {
            _animationController.PlayDead();
        }
    }

    private void Move()
    {
        Vector3 direction;
        moveVector = Vector3.zero;
        moveVector.x = _joystick.Horizontal * _moveSpeed * Time.deltaTime;
        moveVector.z = _joystick.Vertical * _moveSpeed * Time.deltaTime;

        if(_joystick.Horizontal != 0 || _joystick.Vertical != 0)//Run
        {
            direction = Vector3.RotateTowards(transform.forward, moveVector, _rotateSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(direction);

            //Change attackable and alreadyAttack bool to let player can hit
            _characterCombat.EnableAttack(false);
            _characterCombat.ChangeAttackStatus(false);

            _animationController.PlayRun();
        }
        else if(_joystick.Horizontal.Equals(0) || _joystick.Vertical.Equals(0))//Stop
        {
            if(_characterCombat.attackIng == false)//Start IdleAnimation
            {
                _characterCombat.EnableAttack(true);
                _animationController.PlayIdle();
            }
            else//Start AttackAnimation
            {
                _animationController.PlayAttack();
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, transform.position + moveVector, Time.deltaTime * _moveSpeed);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    public Transform characterTransform;
    public GameObject rangeObj;
    public bool isAttackalbe;
    public bool attackIng;
    public bool alreadyAttacked;

    [SerializeField] private AnimationController _animationController;
    [SerializeField] private MeshRenderer weaponRenderer;
    [SerializeField] private Pooling throwPoint;
    [SerializeField] protected List<CharacterCombat> targetList;
    [SerializeField] private float attackRange;

    private bool inAttackRange;
    Collider[] targetInRange;

    private void Awake() 
    {
        isAttackalbe = true;
        attackIng = false;
        alreadyAttacked = false;

        targetList = new List<CharacterCombat>();
    }

    private void Update() 
    {
        TargetInRange();

        Debug.Log("targetList: " + targetList.Count);

        if(inAttackRange && alreadyAttacked == false && isAttackalbe == true)
        {
            Attack(targetList[0]);
        }
    }

    public void AddTarget(CharacterCombat target)
    {
        targetList.Add(target);
    }

    public void RemoveTarget(CharacterCombat target)
    {
        targetList.Remove(target);
    }

    private void TargetInRange()
    {
        if(targetList.Count > 0)
        {
            inAttackRange = true;
        }
        else
        {
            inAttackRange = false;
        }
    }

    private void Attack(CharacterCombat target)
    {
        Debug.Log("Attack");
        alreadyAttacked = true;
        characterTransform.LookAt(target.transform.position);

        StartCoroutine(TriggerAttack());

        GameObject throwWeapon = throwPoint.GetObject();
        throwWeapon.transform.position = throwPoint.transform.position;
        throwWeapon.transform.rotation = transform.rotation;
        throwWeapon.SetActive(true);
        throwWeapon.transform.parent = null;
        throwWeapon.GetComponent<Weapon>().Fly(target.characterTransform);
    }

    IEnumerator TriggerAttack()
    {
        attackIng = true;
        weaponRenderer.enabled = false;

        yield return new WaitForSeconds(ConstValues.ATTACK_ANIM_TIME);

        attackIng = false;
        weaponRenderer.enabled = true;
    }

    private void UpdateKill()
    {

    }

    public void BeingKilled()
    {
        Debug.Log("haha");
        _animationController.PlayDead();
    }

    public void Targeted()
    {

    }

    public void ChangeAttackStatus(bool status)
    {
        alreadyAttacked = status;
    }

    public void EnableAttack(bool attack)
    {
        isAttackalbe = attack;
    }   
}

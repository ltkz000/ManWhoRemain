using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    public Transform characterTransform;
    public bool isAttackalbe;
    public bool attackIng;
    public bool alreadyAttacked;

    [SerializeField] private AnimationController _animationController;
    [SerializeField] private MeshRenderer weaponRenderer;
    [SerializeField] private Transform throwPoint;
    [SerializeField] protected List<CharacterCombat> targetList;
    [SerializeField] private WeaponID weaponID;
    [SerializeField] private GameObject rangeObj;
    [SerializeField] private GameObject lockedObj;
    [SerializeField] private Transform carryPoint;
    [SerializeField] private float attackRange;

    private void Awake() 
    {
        isAttackalbe = true;
        attackIng = false;
        alreadyAttacked = false;

        targetList = new List<CharacterCombat>();
    }

    private void Update() 
    {
        // TargetInRange();

        Debug.Log("targetList: " + targetList.Count);

        if(targetList.Count > 0)
        {
            if(alreadyAttacked == false && isAttackalbe == true)
            {
                Attack(targetList[0]);
            }
            
            targetList[0].BeingLocked();
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

    private void Attack(CharacterCombat target)
    {
        alreadyAttacked = true;
        characterTransform.LookAt(target.transform.position);

        StartCoroutine(TriggerAttack());

        GameObject throwWeapon =  WeaponManager.Ins.SpawnFromPool(weaponID, throwPoint.transform.position, transform.rotation);
        throwWeapon.GetComponent<Weapon>().Fly(this ,target.characterTransform);
    }

    IEnumerator TriggerAttack()
    {
        attackIng = true;
        weaponRenderer.enabled = false;

        yield return new WaitForSeconds(ConstValues.ATTACK_ANIM_TIME);

        attackIng = false;
        weaponRenderer.enabled = true;
    }

    public void UpdateOnKill(CharacterCombat target)
    {
        targetList.Remove(target);
    }

    public void BeingLocked()
    {
        lockedObj.SetActive(true);
    }

    public void BeingKilled()
    {
        _animationController.PlayDead();
        lockedObj.SetActive(false);
    }

    public void PoolBackWeapon(GameObject weapon)
    {
        WeaponManager.Ins.ReturnToPool(weapon);
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

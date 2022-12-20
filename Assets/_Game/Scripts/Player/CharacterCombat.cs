using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CharacterCombat : CharacterCombatAbtract
{
    [SerializeField] private Transform throwPoint;
    [SerializeField] private SkinColor skinColor;
    [SerializeField] private TextMeshPro nameText;
    private int mapGold;

    private void Start() 
    {
        InitPlayerWeapon();
    }

    public void InitPlayerWeapon()
    {
        characterWeaponID = PlayerDataManager.Ins.GetPlayerWeaponID();

        InitWeapon(WeaponDataManager.Ins.GetWeaponByID(characterWeaponID));
    }

    public void ChangePlayerWeapon()
    {
        Destroy(newWeapon);

        characterWeaponID = PlayerDataManager.Ins.GetPlayerWeaponID();

        InitWeapon(WeaponDataManager.Ins.GetWeaponByID(characterWeaponID));

        weaponPooler.ResetPool(WeaponDataManager.Ins.GetWeaponByID(characterWeaponID));
    }

    private float timer = 0;

    private void Update() 
    {
        SelectTarget(); 

        if(!isAttackalbe)
        {
            timer = 0;
            isAttacking = false;

            characterWeaponScript.AppearOnHand();
        }

        if(isAttackalbe && isAttacked == false && targetList.Count > 0)
        {
            timer += Time.deltaTime;
            isAttacking = true;

            if(targetList.Count > 0)
            {
                characterTransform.LookAt(targetList[0].characterTransform);
            }
            
            if(timer >= ConstValues.DELAY_THROWWEAPON_TIME && isThrowalbe == true && targetList.Count > 0)
            {
                ThrowWeapon(targetList[0]);
            }

            if(timer >= ConstValues.ATTACK_ANIM_TIME)
            {
                timer = 0;
                isAttackalbe = false;
                isAttacking = false;
                isAttacked = true;

                characterWeaponScript.AppearOnHand();
            }
        }


    }

    private void SelectTarget()
    {
        if(targetList.Count > 0)
        {
            if(targetList[0].isDead)
            {
                RemoveTarget(targetList[0]);
            }
            else
            {
                targetList[0].BeingLocked();
            }
        }
    }

    private void ThrowWeapon(CharacterCombatAbtract target)
    {
        isThrowalbe = false;
        characterWeaponScript.DisappearOnHand();

        
        throwWeapon = weaponPooler.GetObject(WeaponManager.Ins.weaponParentTrans);

        Weapon weaponScript = throwWeapon.GetComponent<Weapon>();
        weaponScript.weaponTransform.localScale = characterTransform.localScale;
        weaponScript.Fly(this, target.characterTransform);
    }

    public override void UpdateOnKill(CharacterCombatAbtract target)
    {
        base.UpdateOnKill(target);

        if(level < ConstValues.MAX_LEVEL)
        {
            CameraController.Ins.UpdateOffset();
        }

        mapGold += ConstValues.KILL_GOLD;
        PlayerDataManager.Ins.UpdatePlayerGold();
    }

    public override void BeingKilled()
    {
        base.BeingKilled();
        UIManager.Ins.OpenUI(UICanvasID.BlockRay);
    }

    public override void DisappearAfterKilled()
    {
        base.DisappearAfterKilled();
        
        UIManager.Ins.CloseUI(UICanvasID.GamePlay);
        UIManager.Ins.CloseUI(UICanvasID.BlockRay);
        UIManager.Ins.OpenUI(UICanvasID.Lose);
    }

    public override GameObject GetCharacterWeapon()
    { 
        base.GetCharacterWeapon();
        return WeaponDataManager.Ins.GetWeaponByID(characterWeaponID);
    }

    public void ResetMapGold()
    {
        mapGold = 0;
    }

    public int GetMapGold()
    {
        return mapGold;
    }

    public void ActiveNameText()
    {
        nameText.text = PlayerDataManager.Ins.GetPlayerName();
        nameText.gameObject.SetActive(true);
    }
    public void DeactiveNameText()
    {
        nameText.gameObject.SetActive(false);
    }

    public void PlayerOnMainMenu()
    {
        DeactiveNameText();
        characterTransform.position = Vector3.zero;
    }
}

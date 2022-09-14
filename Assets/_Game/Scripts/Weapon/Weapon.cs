using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponID
{
    sword,
    axe,
    hammer
}

[System.Serializable]
public class WeaponRef
{
    public WeaponID weaponID;
    public GameObject weaponPrefab;
}

public class Weapon : MonoBehaviour
{
    public BoxCollider boxCollider;
    public Rigidbody axeRb;
    public Transform transform;

    [SerializeField] private float flySpeed;
    [SerializeField] private float throwPower;

    //private CharacterCombat characterCombat;

    public void Fly(Transform target)
    {
        var velo = (target.position - transform.position).normalized * flySpeed;
        velo.y = 0;
        axeRb.velocity = velo;   
    }

    private void OnCollisionEnter(Collision other) 
    {
        CharacterCombat characterCombat = CachedCollision.GetCharacterCombatCollision(other);
        // characterCombat = other.gameObject.GetComponent<CharacterCombat>();
        if(characterCombat != null)
        {
            Debug.Log(characterCombat.gameObject.name);
            characterCombat.BeingKilled();
        }
    }

    private void OnTarGet(CharacterCombat characterCombat)
    {
        characterCombat.BeingKilled();
    }   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public BoxCollider boxCollider;
    public Rigidbody axeRb;
    public Transform transform;
    public Transform handPoint;
    private CharacterCombat _attacker;
    // public MeshRenderer WeaponSkinRenderer;

    [SerializeField] private float flySpeed;

    public void Fly(CharacterCombat attacker, Transform target)
    {
        _attacker = attacker;
        var velo = (target.position - transform.position).normalized * flySpeed;
        velo.y = 0;
        axeRb.velocity = velo;   
    }

    private void OnCollisionEnter(Collision other) 
    {
        // CharacterCombat characterCombat = CachedCollision.GetCharacterCombatCollision(other);
        // CharacterCombat characterCombat = other.gameObject.GetComponent<CharacterCombat>();
        CharacterCombat characterCombat = CachedCollision.GetCharacterCombat(other.gameObject);
        if(characterCombat != null)
        {
            OnTarGet(characterCombat);
        }
    }

    private void OnTarGet(CharacterCombat target)
    {
        target.BeingKilled();
        target.PoolBackWeapon(gameObject);
        _attacker.UpdateOnKill(target);
    }   
}

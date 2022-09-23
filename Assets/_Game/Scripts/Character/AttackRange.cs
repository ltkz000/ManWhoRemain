using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    [SerializeField] private CharacterCombatAbtract characterCombat;

    private void OnTriggerEnter(Collider other) 
    {
        CharacterCombatAbtract target = CachedCollision.GetCharacterCombatCollider(other);
        if(target != null && target != characterCombat)
        {
            characterCombat.AddTarget(target);
        }

        Transparent transparent = CachedCollision.GetTransparentCollider(other);
        if(transparent != null)
        {
            transparent.TransparentObject();
        }

    }

    private void OnTriggerExit(Collider other) 
    {
        CharacterCombatAbtract target = CachedCollision.GetCharacterCombatCollider(other);
        if(target != null)
        {
            characterCombat.RemoveTarget(target);
        }

        Transparent transparent = CachedCollision.GetTransparentCollider(other);
        if(transparent != null)
        {
            transparent.SetDefaultMat();
        }
    }
}

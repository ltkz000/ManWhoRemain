using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    [SerializeField] private CharacterCombat characterCombat;

    private void OnTriggerEnter(Collider other) 
    {
        CharacterCombat target = CachedCollision.GetCharacterCombatCollider(other);
        if(target != null)
        {
            characterCombat.AddTarget(target);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        CharacterCombat target = CachedCollision.GetCharacterCombatCollider(other);
        if(target != null)
        {
            characterCombat.RemoveTarget(target);
        }
    }
}

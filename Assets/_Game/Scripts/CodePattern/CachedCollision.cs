using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CachedCollision
{
    public static Dictionary<Collider, CharacterCombatAbtract> CharacterCombatColliderDictionary = new Dictionary<Collider, CharacterCombatAbtract>();
    public static Dictionary<GameObject, CharacterCombatAbtract> CharacterCombatDictionary = new Dictionary<GameObject, CharacterCombatAbtract>();

    public static Dictionary<Collider, Transparent> TransparentColliderDictionary = new Dictionary<Collider, Transparent>();

    public static CharacterCombatAbtract GetCharacterCombat(GameObject gameObject)
    {
        if(CharacterCombatDictionary.TryGetValue(gameObject, out CharacterCombatAbtract characterCombat)) return characterCombat;

        CharacterCombatDictionary.Add(gameObject, gameObject.GetComponent<CharacterCombatAbtract>());
        return CharacterCombatDictionary[gameObject];
    }

    public static CharacterCombatAbtract GetCharacterCombatCollider(Collider collider)
    {
        if(CharacterCombatColliderDictionary.TryGetValue(collider, out CharacterCombatAbtract characterCombat)) return characterCombat;

        CharacterCombatColliderDictionary.Add(collider, collider.gameObject.GetComponent<CharacterCombatAbtract>());
        return CharacterCombatColliderDictionary[collider];
    }

    public static Transparent GetTransparentCollider(Collider collider)
    {
        if(TransparentColliderDictionary.TryGetValue(collider, out Transparent transparent)) return transparent;

        TransparentColliderDictionary.Add(collider, collider.gameObject.GetComponent<Transparent>());
        return TransparentColliderDictionary[collider];
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CachedCollision
{
    public static Dictionary<Collision, CharacterCombat> CharacterCombatCollisionDictionary = new Dictionary<Collision, CharacterCombat>();
    public static Dictionary<Collider, CharacterCombat> CharacterCombatColliderDictionary = new Dictionary<Collider, CharacterCombat>();
    public static Dictionary<GameObject, CharacterCombat> CharacterCombatDictionary = new Dictionary<GameObject, CharacterCombat>();
    // public static Dictionary<Collision, BaseCharacter> CharacterCollisionDictionary = new Dictionary<Collision, BaseCharacter>();
    // public static Dictionary<Collision, Obstacle> ObstacleCollisionDictionary = new Dictionary<Collision, Obstacle>();
    // public static Dictionary<Collision, Wall> WallCollisionDictionary = new Dictionary<Collision, Wall>();
    // public static Dictionary<Collider, BaseCharacter> CharacterColliderDictionary = new Dictionary<Collider, BaseCharacter>();
    // public static Dictionary<Collider, BumperCars_Weapon> WeaponColliderDictionary = new Dictionary<Collider, BumperCars_Weapon>();

    // public static CharacterCombat GetCharacterCombatCollision(Collision collision)
    // {
    //     if (CharecterCombatCollisionDictionary.TryGetValue(collision, out CharacterCombat characterCombat)) return characterCombat;

    //     CharecterCombatCollisionDictionary.Add(collision, collision.gameObject.GetComponent<CharacterCombat>());
    //     return CharecterCombatCollisionDictionary[collision];
    // }
    public static CharacterCombat GetCharacterCombat(GameObject gameObject)
    {
        if(CharacterCombatDictionary.TryGetValue(gameObject, out CharacterCombat characterCombat)) return characterCombat;

        CharacterCombatDictionary.Add(gameObject, gameObject.GetComponent<CharacterCombat>());
        return CharacterCombatDictionary[gameObject];
    }
    public static CharacterCombat GetCharacterCombatCollision(Collision collision)
    {
        if(CharacterCombatCollisionDictionary.TryGetValue(collision, out CharacterCombat characterCombat)) return characterCombat;

        CharacterCombatCollisionDictionary.Add(collision, collision.gameObject.GetComponent<CharacterCombat>());
        return CharacterCombatCollisionDictionary[collision];
    }
    public static CharacterCombat GetCharacterCombatCollider(Collider collider)
    {
        if (CharacterCombatColliderDictionary.TryGetValue(collider, out CharacterCombat characterCombat)) return characterCombat;

        CharacterCombatColliderDictionary.Add(collider, collider.gameObject.GetComponent<CharacterCombat>());
        return CharacterCombatColliderDictionary[collider];
    }

    // public static BaseCharacter GetBaseCharacter(Collision collision)
    // {
    //     if (CharacterCollisionDictionary.TryGetValue(collision, out BaseCharacter baseCharacter)) return baseCharacter;

    //     CharacterCollisionDictionary.Add(collision, collision.gameObject.GetComponent<BaseCharacter>())                                                                                                                                                                   ;
    //     return CharacterCollisionDictionary[collision];
    // }

    // public static Obstacle GetObstacle(Collision collision)
    // {
    //     if (ObstacleCollisionDictionary.TryGetValue(collision, out Obstacle obstacle)) return obstacle;

    //     ObstacleCollisionDictionary.Add(collision, collision.gameObject.GetComponent<Obstacle>());
    //     return ObstacleCollisionDictionary[collision];
    // }

    // public static Wall GetWall(Collision collison)
    // {
    //     if (WallCollisionDictionary.TryGetValue(collison, out Wall wall)) return wall;

    //     WallCollisionDictionary.Add(collison, collison.gameObject.GetComponent<Wall>());
    //     return WallCollisionDictionary[collison];
    // }

    // public static BumperCars_Weapon GetWeaponByCollider(Collider collider)
    // {
    //     if (WeaponColliderDictionary.TryGetValue(collider, out BumperCars_Weapon weapon)) return weapon;

    //     WeaponColliderDictionary.Add(collider, collider.gameObject.GetComponent<BumperCars_Weapon>());
    //     return WeaponColliderDictionary[collider];
    // }

    // public static BaseCharacter GetCharacterByCollider(Collider collider)
    // {
    //     if (CharacterColliderDictionary.TryGetValue(collider, out BaseCharacter character)) return character;

    //     CharacterColliderDictionary.Add(collider, collider.gameObject.GetComponent<BaseCharacter>());
    //     return CharacterColliderDictionary[collider];
    // }
}

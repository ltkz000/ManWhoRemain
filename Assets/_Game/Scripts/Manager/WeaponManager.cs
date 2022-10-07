using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponID
{
    Axe,
    Axee,
    Boomerang,
    Candy,
    Hammer,
    Ice
}

[System.Serializable]
public class WeaponRef
{
    public WeaponID weaponID;
    // public Weapon weaponScript;
    public Transform weaponTranform;
}

[System.Serializable]
public class WeaponPool
{
    public WeaponID weaponID;
    public GameObject weaponPrefab;
    public int poolSize;
}

public class WeaponManager : Singleton<WeaponManager>
{
    public Transform transform;
    // [NonReorderable] public List<WeaponPool> pools;
    // public static Dictionary<WeaponID, Queue<GameObject>> weaponDictionary;  
    
    // void Start()
    // {
    //     weaponDictionary = new Dictionary<WeaponID, Queue<GameObject>>();  

    //     foreach (WeaponPool weaponPool in pools)
    //     {
    //         Queue<GameObject> objectPool = new Queue<GameObject>();

    //         for(int i = 0; i < weaponPool.poolSize; i++)
    //         {
    //             GameObject gameObject = GenerateNewObject(weaponPool);
    //             objectPool.Enqueue(gameObject);
    //         }

    //         weaponDictionary.Add(weaponPool.weaponID, objectPool);
    //     }  
    // }

    // public GameObject GenerateNewObject(WeaponPool weaponPool)
    // {
    //     GameObject gameObject = Instantiate(weaponPool.weaponPrefab);
    //     gameObject.SetActive(false);
    //     gameObject.transform.parent = transform;
    //     return gameObject;
    // }

    // public GameObject SpawnFromPool(WeaponID weaponID, Vector3 position)
    // {
    //     if(weaponDictionary.ContainsKey(weaponID))
    //     {
    //         GameObject objectToSpawn = weaponDictionary[weaponID].Dequeue();

    //         objectToSpawn.transform.position = position;
    //         objectToSpawn.SetActive(true);

    //         weaponDictionary[weaponID].Enqueue(objectToSpawn);

    //         return objectToSpawn;
    //     }
    //     else 
    //     {
    //         Debug.Log("Awshit don't have it!!!");
    //         return null;
    //     }
    // }

    // public void ReturnToPool(GameObject gameObject)
    // {
    //     gameObject.SetActive(false);
    //     gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);
    //     gameObject.transform.position = Vector3.zero;
    //     gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    // }

    // public void ChangeWeapon()
    // {
        
    // }
}

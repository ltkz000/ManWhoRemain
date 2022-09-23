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

public enum SkinColor
{
    Red,
    Green,
    Blue,
    Gray,
    Yellow,
    White
}

[System.Serializable]
public class WeaponRef
{
    public WeaponID weaponID;
    public Weapon weaponScript;
}

[System.Serializable]
public class WeaponPool
{
    public WeaponID weaponID;
    public GameObject weaponPrefab;
    public int poolSize;
}

[System.Serializable]
public class WeaponSkin
{
    public SkinColor skinColor;
    public Material material;
}

public class WeaponManager : Singleton<WeaponManager>
{
    public Transform weaponHolder;
    public List<WeaponPool> pools;
    public static Dictionary<WeaponID, Queue<GameObject>> weaponDictionary;  
    
    void Start()
    {
        weaponDictionary = new Dictionary<WeaponID, Queue<GameObject>>();  

        foreach (WeaponPool weaponPool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for(int i = 0; i < weaponPool.poolSize; i++)
            {
                GameObject gameObject = GenerateNewObject(weaponPool);
                objectPool.Enqueue(gameObject);
            }

            weaponDictionary.Add(weaponPool.weaponID, objectPool);
        }  
    }

    public GameObject GenerateNewObject(WeaponPool weaponPool)
    {
        GameObject gameObject = Instantiate(weaponPool.weaponPrefab);
        gameObject.SetActive(false);
        gameObject.transform.parent = weaponHolder;
        return gameObject;
    }

    public GameObject SpawnFromPool(WeaponID weaponID, Vector3 position)
    {
        if(weaponDictionary.ContainsKey(weaponID))
        {
            GameObject objectToSpawn = weaponDictionary[weaponID].Dequeue();

            objectToSpawn.transform.position = position;
            objectToSpawn.SetActive(true);

            weaponDictionary[weaponID].Enqueue(objectToSpawn);

            return objectToSpawn;
        }
        else 
        {
            Debug.Log("Awshit don't have it!!!");
            return null;
        }
    }

    public void ReturnToPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
        gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);
        gameObject.transform.position = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}

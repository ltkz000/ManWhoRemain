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

public enum WeaponColor
{
    Red,
    Green,
    Blue,
    Gray,
    Yellow,
    White
}

public class WeaponManager : Singleton<WeaponManager>
{

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
        public WeaponColor weaponColor;
        public Material material;
    }

    public Transform weaponHolder;
    public List<WeaponPool> pools;
    public List<WeaponSkin> weaponSkins;
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

    public GameObject SpawnFromPool(WeaponID weaponID, Vector3 position, Quaternion rotation)
    {
        if(weaponDictionary.ContainsKey(weaponID))
        {
            GameObject objectToSpawn = weaponDictionary[weaponID].Dequeue();

            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;
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
    }

    public void InitOnHand(Weapon weapon, Transform handPos)
    {
        
    }
}

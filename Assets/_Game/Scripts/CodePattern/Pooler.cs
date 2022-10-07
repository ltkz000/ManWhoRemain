using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    private GameObject prefab;
    [SerializeField] Transform transform;
    [SerializeField] private CharacterCombatAbtract character;
    [SerializeField] private int poolSize;
    [SerializeField] private bool expanable;
    private List<GameObject> freeList;
    private List<GameObject> usedList;

    private void Awake() 
    {
        freeList = new List<GameObject>();
        usedList = new List<GameObject>();
    }

    public GameObject GetObject(Transform parent)
    {
        int totalFree = freeList.Count;
        if(totalFree == 0 && !expanable) return null;
        else if(totalFree == 0) GenerateNewObject();

        GameObject g = freeList[freeList.Count - 1];
        g.transform.position = transform.position;
        g.transform.parent = parent;
        g.SetActive(true);

        freeList.RemoveAt(freeList.Count - 1);
        usedList.Add(g);
        return g;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.parent = transform;
        obj.transform.rotation = Quaternion.Euler(Vector3.zero);
        obj.transform.position = Vector3.zero;
        obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
        usedList.Remove(obj);
        freeList.Add(obj);
    }

    private void GenerateNewObject()
    {
        prefab = character.GetCharacterWeapon();
        GameObject g = Instantiate(prefab);
        g.SetActive(false);
        freeList.Add(g);
    }

    public void ResetPool(GameObject newPrefab)
    {
        prefab = newPrefab;

        foreach(var temp in freeList)
        {
            Destroy(temp);
        }
        foreach(var temp in usedList)
        {
            Destroy(temp);
        }

        freeList.RemoveAll(null);
        usedList.RemoveAll(null);

        for(int i = 0; i < poolSize; i++)
        {
            GenerateNewObject();
        }
    }
}

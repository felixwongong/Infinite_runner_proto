using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] List<GameObject> objPrefabs;

    List<GameObject> poolObjects;

    private void Awake()
    {
        poolObjects = new List<GameObject>();
    }

    public void Init(List<GameObject> objPrefabs)
    {
        this.objPrefabs = objPrefabs;
    }

    public GameObject Get()
    {
        //poolObjects = Shuffle(poolObjects);
        foreach (var obj in poolObjects)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        GameObject newObjPrefab = objPrefabs[Random.Range(0, objPrefabs.Count)];
        GameObject newObject = Instantiate(newObjPrefab, transform.position, transform.rotation, transform);
        poolObjects.Add(newObject);
        return newObject;
    }
    private List<GameObject> Shuffle(List<GameObject> list)
    {
        List<GameObject> newList = list;
        for (int i = 0; i < newList.Count; i++)
        {
            int rand = Random.Range(i, newList.Count);
            var item = newList[i];
            newList[i] = newList[rand];
            newList[rand] = item;
        }
        return newList;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooler : MonoBehaviour
{
    public static BulletPooler Current;
    public Bullet pooledObject;
    public int pooledAmount;
    public bool willGrow;

    private List<Bullet> pooledObjects;

    private void Awake()
    {
        Current = this;
    }

    void Start()
    {
        pooledObjects = new List<Bullet>();
        for (int i = 0; i < pooledAmount; i++)
        {
            Bullet obj = Instantiate(pooledObject);
            obj.gameObject.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public Bullet GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].gameObject.activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        if (willGrow)
        {
            Bullet obj = Instantiate(pooledObject);
            pooledObjects.Add(obj);
            return obj;
        }
        return null;
    }
}

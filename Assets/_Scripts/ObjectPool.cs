using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] protected GameObject objectToSpawn;
    [SerializeField] protected int poolSize;
    protected int currentSize;
    protected Queue<GameObject> objectPool;

    private void Awake()
    {
        objectPool = new Queue<GameObject>();
    }

    public virtual GameObject SpawnObject(GameObject currentObject = null)
    {
        if (currentObject == null)
        {
            currentObject = objectToSpawn;
        }

        GameObject spawnObject = null;

        if (currentSize < poolSize)
        {
            spawnObject = Instantiate(currentObject, transform.position, Quaternion.identity);
            spawnObject.name = currentObject.name + "_" + currentSize;
            currentSize++;
        }
        else
        {
            spawnObject = objectPool.Dequeue();
            spawnObject.transform.position = transform.position;
            spawnObject.transform.rotation = Quaternion.identity;
        }
        objectPool.Enqueue(spawnObject);
        return spawnObject;
    }
}

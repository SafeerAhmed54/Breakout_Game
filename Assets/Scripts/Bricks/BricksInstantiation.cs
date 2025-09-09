using System.Collections.Generic;
using UnityEngine;

public class BricksInstantiation : MonoBehaviour
{
    [Header("Pooling Settings")]
    [SerializeField] private GameObject prefab;   // The object to pool
    [SerializeField] private int poolSize = 10;   // Initial pool size
    [SerializeField] private bool expandable = true; // Allow expanding pool

    private Queue<GameObject> poolQueue;
    private static BricksInstantiation instance;

    private void Awake()
    {
        // Singleton pattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        poolQueue = new Queue<GameObject>();

        // Pre-instantiate objects
        for (int i = 0; i < poolSize; i++)
        {
            AddObjectToPool();
        }
    }

    private GameObject AddObjectToPool()
    {
        GameObject obj = Instantiate(prefab, transform); // ?? Parent is this GameObject
        obj.SetActive(false);
        poolQueue.Enqueue(obj);
        return obj;
    }

    public GameObject GetObject(Vector3 position, Quaternion rotation)
    {
        GameObject obj;

        if (poolQueue.Count > 0)
        {
            obj = poolQueue.Dequeue();
        }
        else if (expandable)
        {
            obj = AddObjectToPool();
        }
        else
        {
            return null; // No object available
        }

        obj.SetActive(true);
        obj.transform.SetPositionAndRotation(position, rotation);
        obj.transform.SetParent(transform); // ?? Re-parent to pool if lost
        return obj;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.SetParent(transform); // ?? Keep hierarchy clean
        poolQueue.Enqueue(obj);
    }
}

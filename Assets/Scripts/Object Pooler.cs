using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance { get; private set; }
    private Dictionary<System.Type, Queue<IPoolable>> poolDictionary = new Dictionary<System.Type, Queue<IPoolable>>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Destroy duplicate instances
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Ensures persistence across scenes if needed
        InitializePool(); // Initialize your pools here if required
    }

    private void InitializePool()
    {
        // Perform any necessary initialization here
    }

    public void SetupPool<T>(T prefab, int poolSize) where T : Component, IPoolable
    {
        var type = typeof(T);
        if (!poolDictionary.ContainsKey(type))
        {
            poolDictionary[type] = new Queue<IPoolable>();
        }

        for (int i = 0; i < poolSize; i++)
        {
            T instance = Instantiate(prefab);
            instance.gameObject.SetActive(false);
            poolDictionary[type].Enqueue(instance);
        }
    }

    public T DequeueObject<T>() where T : Component, IPoolable
    {
        var type = typeof(T);
        if (poolDictionary.ContainsKey(type) && poolDictionary[type].Count > 0)
        {
            var instance = (T)poolDictionary[type].Dequeue();
            instance.OnSpawn();
            return instance;
        }
        else
        {
            Debug.LogError($"No objects in pool for type: {type}");
            return null;
        }
    }

    public void EnqueueObject<T>(T item) where T : Component, IPoolable
    {
        item.OnDespawn();
        item.gameObject.SetActive(false);

        var type = typeof(T);
        if (!poolDictionary.ContainsKey(type))
        {
            poolDictionary[type] = new Queue<IPoolable>();
        }

        poolDictionary[type].Enqueue(item);
    }
}

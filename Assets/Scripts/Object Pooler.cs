using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ObjectPooler 
{
    public static Dictionary<string, Queue<Component>> poolDictionary = new Dictionary<string, Queue<Component>>();

    public static void EnqueueObject<T>(T item, string name) where T : Component
    {
        if (!item.gameObject.activeSelf)
        {
            return;
        }

        item.transform.position = Vector2.zero;
        if (!poolDictionary.ContainsKey(name))
        {
            poolDictionary[name] = new Queue<Component>();
        }

        poolDictionary[name].Enqueue(item);
        item.gameObject.SetActive(false);
    }

    public static T DequeueObject<T>(string key) where T : Component
    {
        if (poolDictionary.ContainsKey(key) && poolDictionary[key].Count > 0)
        {
            return (T) poolDictionary[key].Dequeue();
        }
        else
        {
            Debug.LogError("No objects in pool for key: " + key);
            return null;
        }
    }

    public static void SetupPool<T>(T pooledItemPrefab, int poolSize, string dictionaryEntry) where T : Component
    {
        if (!poolDictionary.ContainsKey(dictionaryEntry))
        {
            poolDictionary.Add(dictionaryEntry, new Queue<Component>());
        }

        for (int i = 0; i < poolSize; i++)
        {
            T pooledInstance = Object.Instantiate(pooledItemPrefab);
            pooledInstance.gameObject.SetActive(false);
            poolDictionary[dictionaryEntry].Enqueue(pooledInstance);
        }
    }
}
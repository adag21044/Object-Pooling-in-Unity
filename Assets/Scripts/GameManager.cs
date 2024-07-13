using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BulletController bulletPrefab;
    public int bulletPoolSize = 10;

    private void Awake()
    {
        InitializeObjectPooler();
    }

    private void InitializeObjectPooler()
    {
        if (ObjectPooler.Instance == null)
        {
            Debug.LogError("ObjectPooler instance is not available.");
            return;
        }

        ObjectPooler.Instance.SetupPool(bulletPrefab, bulletPoolSize);
    }
}
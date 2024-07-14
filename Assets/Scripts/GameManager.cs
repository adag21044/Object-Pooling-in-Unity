using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BulletController bulletPrefab;
    public int bulletPoolSize = 10;
    private ObjectPooler objectPooler;

    private void Awake()
    {
        objectPooler = ObjectPooler.Instance;
        if (objectPooler == null)
        {
            Debug.LogError("ObjectPooler instance is not available.");
            return;
        }
        
        InitializeObjectPooler();
    }

    private void InitializeObjectPooler()
    {
        objectPooler.SetupPool(bulletPrefab, bulletPoolSize);
    }
}
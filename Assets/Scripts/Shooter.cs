using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public BulletController bulletPrefab;
    public int bulletPoolSize = 10;

    private void Start()
    {
        if (bulletPrefab == null)
        {
            
            return;
        }
        ObjectPooler.SetupPool(bulletPrefab, bulletPoolSize, "Bullet");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            BulletController instance = ObjectPooler.DequeueObject<BulletController>("Bullet");
            if (instance != null)
            {
                instance.transform.position = transform.position; // Shooter's position
                instance.gameObject.SetActive(true);
                instance.SetTarget(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
        }
    }
}
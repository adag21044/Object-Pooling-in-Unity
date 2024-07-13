using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (ObjectPooler.Instance == null)
        {
            Debug.LogError("ObjectPooler instance is not available.");
            return;
        }

        BulletController instance = ObjectPooler.Instance.DequeueObject<BulletController>();
        if (instance != null)
        {
            instance.transform.position = transform.position;
            instance.SetTarget(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            instance.gameObject.SetActive(true);
        }
    }
}
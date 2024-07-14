using UnityEngine;

public class Shooter : MonoBehaviour
{
    private ObjectPooler objectPooler;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
        if (objectPooler == null)
        {
            Debug.LogError("ObjectPooler instance is not available.");
            return;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        BulletController instance = objectPooler.DequeueObject<BulletController>();
        if (instance != null)
        {
            instance.transform.position = transform.position;
            instance.SetTarget(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            instance.gameObject.SetActive(true);
        }
    }
}
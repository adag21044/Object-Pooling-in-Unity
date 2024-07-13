using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Vector3 targetPosition;
    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                ObjectPooler.EnqueueObject(this, "Bullet");
            }
        }
    }

    public void SetTarget(Vector3 target)
    {
        target.z = 0; // Ensure the bullet moves in 2D plane
        targetPosition = target;
    }
}
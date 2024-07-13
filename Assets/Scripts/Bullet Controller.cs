using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour, IPoolable
{
    private Vector3 targetPosition;
    public float speed = 5f;

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            MoveTowardsTarget();
        }
    }

    private void MoveTowardsTarget()    
    {
        var direction = targetPosition - new Vector3(0, 0, 0);
        direction.Normalize();
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        transform.up = direction;
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            ObjectPooler.Instance.EnqueueObject(this);
        }
    }

    public void SetTarget(Vector3 target)
    {
        target.z = 0; // Ensure the bullet moves in 2D plane
        targetPosition = target;
    }

    public void OnSpawn()
    {
        // Logic to execute when the object is spawned from the pool
    }

    public void OnDespawn()
    {
        // Logic to execute when the object is returned to the pool
    }
}
public interface IPoolable
{
    void OnSpawn();
    void OnDespawn();
}

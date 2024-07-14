using UnityEngine;

public class BulletController : MonoBehaviour, IPoolable
{
    private Vector3 targetPosition;
    public float speed = 5f;
    private ObjectPooler objectPooler;

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            MoveTowardsTarget();
        }
    }

    private void MoveTowardsTarget()
    {
        var direction = targetPosition - Vector3.zero;
        direction.Normalize();
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        transform.up = direction;
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            objectPooler.EnqueueObject(this);
        }
    }

    public void SetTarget(Vector3 target)
    {
        target.z = 0; // Ensure the bullet moves in 2D plane
        targetPosition = target;
    }

    public void SetObjectPooler(ObjectPooler pooler)
    {
        objectPooler = pooler;
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

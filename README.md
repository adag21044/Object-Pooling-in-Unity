# Object Pooling in Unity

This project demonstrates a bullet pooling system in Unity, which efficiently manages bullet instances to improve performance and memory usage.

## Project Structure

1. **BulletController.cs**: Manages the behavior of individual bullets.
2. **IPoolable.cs**: Interface for objects that can be pooled.
3. **GameManager.cs**: Initializes and manages the object pool.
4. **ObjectPooler.cs**: Manages the pooling of objects.
5. **Shooter.cs**: Handles shooting mechanics and bullet instantiation.

## BulletController.cs

### BulletController
Manages the bullet's movement and interaction with the object pool.
- **SetTarget(Vector3 target)**: Sets the bullet's target position.
- **SetObjectPooler(ObjectPooler pooler)**: Sets the object pooler for the bullet.
- **OnSpawn()**: Logic to execute when the bullet is spawned from the pool.
- **OnDespawn()**: Logic to execute when the bullet is returned to the pool.

## IPoolable.cs

### IPoolable
Defines the methods for objects that can be pooled.
- **OnSpawn()**: Logic to execute when the object is spawned from the pool.
- **OnDespawn()**: Logic to execute when the object is returned to the pool.

## GameManager.cs

### GameManager
Initializes the object pool with a specified number of bullet instances.
- **InitializeObjectPooler()**: Sets up the object pool with the bullet prefab and pool size.

## ObjectPooler.cs

### ObjectPooler
Manages the creation, storage, and reuse of pooled objects.
- **SetupPool<T>(T prefab, int poolSize)**: Initializes a pool with a specified number of prefab instances.
- **DequeueObject<T>()**: Retrieves an object from the pool.
- **EnqueueObject<T>(T item)**: Returns an object to the pool.

## Shooter.cs

### Shooter
Handles the shooting mechanics and bullet instantiation.
- **Shoot()**: Instantiates a bullet from the pool and sets its target position.

## How to Use

1. **Setup**:
   - Attach the `BulletController` script to the bullet prefab.
   - Attach the `GameManager` script to a GameObject in your scene.
   - Attach the `Shooter` script to a GameObject representing the shooter (e.g., a player or turret).
   - Ensure the `ObjectPooler` is set up in your scene.

2. **Run**:
   - Press the left mouse button to shoot bullets towards the mouse position.
   - Bullets will be pooled and reused, improving performance and memory usage.

## License

This project is licensed under the MIT License. See the LICENSE file for details.

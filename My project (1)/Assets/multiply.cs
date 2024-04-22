using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public GameObject applePrefab; // Prefab for the apple projectile
    public Transform target; // Reference to the target (e.g., arrow's transform)
    public float minSpeed = 3f; // Minimum speed of the apple projectile
    public float maxSpeed = 5f; // Maximum speed of the apple projectile
    public float spawnInterval = 2f; // Time interval between each spawn
    public AudioClip shootSound; // Sound when shooting

    float nextSpawnTime; // Time for the next spawn
    public Transform spawnPoint; // Reference to the spawn point for apples

    // Method to spawn an apple
   
    void Start()
    {
        // Set the initial spawn time
        nextSpawnTime = Time.time + spawnInterval;
    }

    public void SpawnApple()
    {
        if (applePrefab != null && spawnPoint != null)
        {
            Instantiate(applePrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Debug.LogError("Apple prefab or spawn point is not assigned!");
        }
    }


    void Update()
    {
        // Check if it's time to spawn a new apple projectile
        if (Time.time >= nextSpawnTime)
        {
            SpawnAppleProjectile();
            // Calculate the next spawn time
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnAppleProjectile()
    {
        // Instantiate the apple projectile at the spawner's position
        GameObject apple = Instantiate(applePrefab, transform.position, Quaternion.identity);

        // Calculate direction towards the target
        Vector3 direction = (target.position - transform.position).normalized;

        // Calculate a random speed for the apple projectile
        float speed = Random.Range(minSpeed, maxSpeed);

        // Set the velocity of the apple projectile
        Rigidbody2D rb = apple.GetComponent<Rigidbody2D>();
        rb.velocity = direction * speed;

        // Play shooting sound
        if (shootSound != null)
        {
            AudioSource.PlayClipAtPoint(shootSound, transform.position);
        }
    }
}

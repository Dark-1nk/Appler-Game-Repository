using UnityEngine;

public class Apple : MonoBehaviour
{
    public float speed = 5f; // Speed of the apple movement
    private Transform target; // Reference to the target position (arrow position)

    void Start()
    {
        // Find the arrow GameObject and get its position
        GameObject arrow = GameObject.FindGameObjectWithTag("Arrow");
        if (arrow != null)
        {
            target = arrow.transform;
        }
        else
        {
            Debug.LogError("Arrow GameObject not found. Make sure it's tagged as 'Arrow'.");
        }
    }

    void Update()
    {
        // Move the apple towards the arrow's position
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    // Example method to handle behavior when hit by the arrow
    public void HandleHit()
    {
        // Play particle effect, sound, or any other behavior
        // For simplicity, let's just destroy the apple
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the apple collides with the arrow
        if (other.CompareTag("Arrow"))
        {
            // Trigger game over state
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.GameOver();
            }

            // Destroy the apple
            Destroy(gameObject);
        }
    }
}

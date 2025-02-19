using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Settings")]
    public float speed = 10f;       // Speed for movement (if you prefer to move the bullet manually)
    public float lifeTime = 2f;     // Time after which the bullet is destroyed automatically

    void Start()
    {
        // Destroy the bullet after "lifeTime" seconds so it doesn't linger in the scene
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Option 1: If you're not using Rigidbody2D for bullet movement,
        // you can move the bullet manually:
        // transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Here you can add logic to check if the bullet hit an enemy and apply damage, etc.
        // For example:
        // Enemy enemy = hitInfo.GetComponent<Enemy>();
        // if (enemy != null) { enemy.TakeDamage(10); }

        // Destroy the bullet upon collision
        Destroy(gameObject);
    }
}

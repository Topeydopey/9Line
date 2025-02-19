using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Shooting Settings")]
    public GameObject bulletPrefab;    // Prefab for the bullet
    public Transform firePoint;        // The object that rotates around the player
    public float bulletSpeed = 10f;    // Speed at which the bullet travels
    public float fireRate = 0.5f;      // Delay between shots
    public float firePointRadius = 1.0f; // Distance from the player center to the firePoint

    private float nextFireTime = 0f;   // Timer for the next allowed shot

    void Update()
    {
        // Update the firePoint's position and rotation so it rotates around the player
        UpdateFirePointPosition();

        // Fire bullet on left mouse button press if fire rate allows
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Shoot();
        }
    }

    // Calculates the position and rotation of the firePoint around the player based on the mouse position
    void UpdateFirePointPosition()
    {
        // Convert mouse position from screen to world coordinates
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;

        // Determine the direction from the player to the mouse
        Vector2 direction = (mouseWorldPos - transform.position).normalized;

        // Calculate the angle (in degrees) from the player to the mouse
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Set firePoint position at a fixed radius from the player in that direction
        firePoint.position = transform.position + new Vector3(
            Mathf.Cos(angle * Mathf.Deg2Rad) * firePointRadius,
            Mathf.Sin(angle * Mathf.Deg2Rad) * firePointRadius,
            0f
        );

        // Rotate firePoint so that its "up" points outward (adjust the -90 offset if your sprite differs)
        firePoint.rotation = Quaternion.Euler(0, 0, angle - 90f);
    }

    // Spawns a bullet at the firePoint and sets its velocity in the firePoint's upward direction
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = firePoint.up * bulletSpeed;
        }
    }
}

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed;
    public Rigidbody2D body;

    // Sprites for each direction.
    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        // Get the SpriteRenderer component on the same GameObject.
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        // Set the velocity based on input.
        Vector2 velocity = new Vector2(xInput * MoveSpeed, yInput * MoveSpeed);
        body.velocity = velocity;

        // Choose which sprite to display based on movement direction.
        // Use the axis with the larger absolute value to determine the dominant direction.
        if (Mathf.Abs(xInput) > Mathf.Abs(yInput))
        {
            if (xInput > 0)
            {
                spriteRenderer.sprite = rightSprite;
            }
            else if (xInput < 0)
            {
                spriteRenderer.sprite = leftSprite;
            }
        }
        else if (Mathf.Abs(yInput) > 0)
        {
            if (yInput > 0)
            {
                spriteRenderer.sprite = upSprite;
            }
            else if (yInput < 0)
            {
                spriteRenderer.sprite = downSprite;
            }
        }
        // If there's no input, the sprite remains unchanged.
    }
}

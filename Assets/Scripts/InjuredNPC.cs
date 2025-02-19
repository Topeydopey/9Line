using UnityEngine;

public class InjuredNPC : MonoBehaviour
{
    public bool isInjured = true;

    // Call this function when the NPC is healed.
    public void Heal()
    {
        if (isInjured)
        {
            isInjured = false;
            Debug.Log("NPC healed!");
            // Example: Change the sprite color to show that the NPC is now stable.
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.color = Color.green;
            }
            // Add additional logic here (e.g., enable NPC AI or change behavior).
        }
    }
}

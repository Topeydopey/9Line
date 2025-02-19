using UnityEngine;

public class PlayerMedicalInteraction : MonoBehaviour
{
    private PlayerInventory inventory;

    private void Start()
    {
        // Get the PlayerInventory component from the player.
        inventory = GetComponent<PlayerInventory>();
        if (inventory == null)
        {
            Debug.LogError("PlayerInventory not found on the player!");
        }
    }

    // This method checks for injured NPCs in range.
    // Make sure the player has a Collider2D with "Is Trigger" enabled.
    private void OnTriggerStay2D(Collider2D other)
    {
        // Check if the collided object is tagged as an injured NPC.
        if (other.CompareTag("InjuredNPC"))
        {
            // Check if the player presses the "E" key.
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Get the InjuredNPC script from the collided object.
                InjuredNPC npc = other.GetComponent<InjuredNPC>();
                if (npc != null && npc.isInjured)
                {
                    // If the player has a med kit, heal the NPC.
                    if (inventory != null && inventory.UseMedKit())
                    {
                        npc.Heal();
                    }
                }
            }
        }
    }
}

using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // For now, we track only the number of medical kits.
    public int medKitCount = 1; // Start with one med kit for testing

    // Use a med kit. Returns true if a kit was available and used.
    public bool UseMedKit()
    {
        if (medKitCount > 0)
        {
            medKitCount--;
            Debug.Log("Used a med kit. Kits left: " + medKitCount);
            return true;
        }
        else
        {
            Debug.Log("No med kits available!");
            return false;
        }
    }
}

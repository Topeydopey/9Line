using UnityEngine;

public class DragMechanic : MonoBehaviour
{
    public KeyCode dragKey = KeyCode.E;
    private SpringJoint2D springJoint;
    private Rigidbody2D attachedNPC;

    private bool isDragging = false; // Track if we're currently dragging

    void Start()
    {
        springJoint = GetComponent<SpringJoint2D>();
        springJoint.enabled = false;
    }

    void Update()
    {
        // Check for a key press - single press toggles the drag state
        if (Input.GetKeyDown(dragKey))
        {
            if (!isDragging)
            {
                // If not currently dragging, try to attach
                TryAttachNPC();
            }
            else
            {
                // If currently dragging, release
                ReleaseNPC();
            }
        }
    }

    void TryAttachNPC()
    {
        // Example: check 1f radius around the player for an NPC
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 1f);

        foreach (var hit in hitColliders)
        {
            if (hit.CompareTag("InjuredNPC"))
            {
                attachedNPC = hit.GetComponent<Rigidbody2D>();
                if (attachedNPC)
                {
                    springJoint.connectedBody = attachedNPC;
                    springJoint.enabled = true;
                    isDragging = true; // Toggle on
                }
                break;
            }
        }
    }

    void ReleaseNPC()
    {
        springJoint.enabled = false;
        springJoint.connectedBody = null;
        attachedNPC = null;
        isDragging = false; // Toggle off
    }
}

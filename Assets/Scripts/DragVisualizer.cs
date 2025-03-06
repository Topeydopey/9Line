using UnityEngine;

public class DragVisualizer : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public SpringJoint2D springJoint;

    void Update()
    {
        if (springJoint.enabled && springJoint.connectedBody)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, springJoint.connectedBody.position);
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }
}

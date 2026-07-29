using UnityEngine;

public class GroundPlanePlacementWatcher : MonoBehaviour
{
    public Transform groundPlaneStage;

    private Vector3 lastPosition;
    private bool firstFrame = true;

    void Update()
    {
        if (!ARObjectManager.Instance.CanPlace())
            return;

        if (firstFrame)
        {
            lastPosition = groundPlaneStage.position;
            firstFrame = false;
            return;
        }

        float distance =
            Vector3.Distance(
                lastPosition,
                groundPlaneStage.position);

        if (distance > 0.02f)
        {
            Debug.Log("GROUND PLANE MOVED");

            ARObjectManager.Instance.ShowModel();
            ARObjectManager.Instance.ObjectPlaced();

            enabled = false;
        }
    }

    public void ResetWatcher()
    {
        enabled = true;

        firstFrame = true;
    }
}
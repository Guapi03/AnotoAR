using UnityEngine;

public class OrganInteractable : MonoBehaviour
{
    [Header("Info")]
    public string organName;

    [Header("Information")]

    public string organTitle;

    [TextArea(2,5)]
    public string organFunction;

    [TextArea(4,10)]
    public string organDescription;
    
    [Header("Focus Settings")]
    public float focusDistance = 0.8f;

    public float focusHeightOffset = 0.35f;

    public float focusScale = 0.35f;

    private void OnMouseDown()
    {
        if (!OrganFocusManager.Instance.CanInteract())
            return;

        OrganFocusManager.Instance
            .FocusOrgan(this);
    }
}
using UnityEngine;

public class OrganInteractable : MonoBehaviour
{
    [Header("Info")]
    public string organName;

    [Header("Information")]
    public string organTitle;

    [TextArea(2, 5)]
    public string organFunction;

    [TextArea(4, 10)]
    public string organDescription;

    [Header("Voice")]
    public AudioClip narrationClip;

    [Header("Focus Settings")]
    [Range(0.1f, 2f)]
    public float focusDistance = 0.8f;

    [Range(-1f, 1f)]
    public float focusHeightOffset = 0.35f;

    [Range(0.1f, 2f)]
    public float focusScale = 0.35f;

    private void OnMouseDown()
    {
        if (OrganFocusManager.Instance == null)
            return;

        if (!OrganFocusManager.Instance.CanInteract())
            return;

        OrganFocusManager.Instance.FocusOrgan(this);
    }
}
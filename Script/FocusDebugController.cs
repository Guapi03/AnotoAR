using TMPro;
using UnityEngine;

public class FocusDebugController : MonoBehaviour
{
    public TMP_Text debugText;

    private OrganInteractable currentOrgan;

    private void Update()
    {
        if (OrganFocusManager.Instance == null)
            return;

        if (!OrganFocusManager.Instance.IsFocused())
        {
            debugText.text =
                "No Organ Focused";

            return;
        }

        currentOrgan =
            OrganFocusManager.Instance.GetCurrentOrgan();

        if (currentOrgan == null)
            return;

        debugText.text =
            $"Organ : {currentOrgan.organName}\n\n" +
            $"Distance : {currentOrgan.focusDistance:F2}\n" +
            $"Height : {currentOrgan.focusHeightOffset:F2}\n" +
            $"Scale : {currentOrgan.focusScale:F2}";
    }

    public void DistancePlus()
    {
        if (currentOrgan == null) return;

        currentOrgan.focusDistance += 0.05f;
    }

    public void DistanceMinus()
    {
        if (currentOrgan == null) return;

        currentOrgan.focusDistance -= 0.05f;
    }

    public void HeightPlus()
    {
        if (currentOrgan == null) return;

        currentOrgan.focusHeightOffset += 0.05f;
    }

    public void HeightMinus()
    {
        if (currentOrgan == null) return;

        currentOrgan.focusHeightOffset -= 0.05f;
    }

    public void ScalePlus()
    {
        if (currentOrgan == null) return;

        currentOrgan.focusScale += 0.05f;
    }

    public void ScaleMinus()
    {
        if (currentOrgan == null) return;

        currentOrgan.focusScale -= 0.05f;
    }
}
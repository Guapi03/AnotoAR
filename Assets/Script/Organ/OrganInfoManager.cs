using TMPro;
using UnityEngine;

public class OrganInfoManager : MonoBehaviour
{
    public static OrganInfoManager Instance;

    [Header("UI")]
    [Header("UI")]
    public GameObject infoButton;
    public GameObject focusExitButton; // InfoPanel里面的Exit
    public GameObject focusModeExitButton; // 外面的Exit Button
    public GameObject infoPanel;

    [Header("Text")]
    public TMP_Text organNameText;
    public TMP_Text organFunctionText;
    public TMP_Text organDescriptionText;

    private OrganInteractable currentOrgan;

    private void Awake()
    {
        Instance = this;

        infoPanel.SetActive(false);

        infoButton.SetActive(false);

        focusExitButton.SetActive(false);
    }

    public void SetCurrentOrgan(
        OrganInteractable organ)
    {
        currentOrgan = organ;
    }

    public void ShowInfo()
    {
        if (currentOrgan == null)
            return;

        organNameText.text =
            currentOrgan.organTitle;

        organFunctionText.text =
            currentOrgan.organFunction;

        organDescriptionText.text =
            currentOrgan.organDescription;

        // 隐藏 Info Button
        infoButton.SetActive(false);

        // 隐藏 Focus Mode Exit
        focusModeExitButton.SetActive(false);

        // 显示 Panel
        infoPanel.SetActive(true);

        // 显示 Info Exit
        focusExitButton.SetActive(true);
    }

    public void HideInfo()
    {
        infoPanel.SetActive(false);

        // 显示 Info Button
        infoButton.SetActive(true);

        // 显示 Focus Mode Exit
        focusModeExitButton.SetActive(true);

        // 隐藏 Info Exit
        focusExitButton.SetActive(false);
    }

    public void ShowInfoButton()
    {
        if (infoButton != null)
            infoButton.SetActive(true);
    }

    public void HideInfoButton()
    {
        if (infoButton != null)
            infoButton.SetActive(false);
    }

    public void ForceClose()
    {
        if (infoPanel != null)
            infoPanel.SetActive(false);

        if (infoButton != null)
            infoButton.SetActive(false);

        if (focusExitButton != null)
            focusExitButton.SetActive(false);
    }
}
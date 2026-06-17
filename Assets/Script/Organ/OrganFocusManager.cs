using System.Collections;
using UnityEngine;

public class OrganFocusManager : MonoBehaviour
{
    public static OrganFocusManager Instance;

    [Header("Animation")]
    [Range(0.1f, 2f)]
    public float animationDuration = 0.5f;

    [Header("UI")]
    public GameObject menuButton;
    public OrganMenuController menuController;
    public GameObject exitButton;

    private Transform currentOrgan;
    private OrganInteractable currentInteractable;

    private Vector3 originalPosition;
    private Vector3 originalScale;
    private Quaternion originalRotation;

    private bool organInteractionEnabled = false;
    private bool isFocused = false;

    private MultiPulseOutline currentPulse;
    private bool isInFocusMode = false;

    private void Awake()
    {
        Instance = this;
    }

    public void EnableOrganInteraction()
    {
        organInteractionEnabled = true;
    }

    public void DisableOrganInteraction()
    {
        organInteractionEnabled = false;
    }

    public bool CanInteract()
    {
        return organInteractionEnabled;
    }

    public bool IsFocused()
    {
        return isFocused;
    }
    public Transform GetCurrentTransform()
    {
        return currentOrgan;
    }

    public void FocusOrgan(OrganInteractable organ)
    {
        if (!organInteractionEnabled)
            return;

        if (isFocused)
            return;

        isFocused = true;

        currentInteractable = organ;
        currentOrgan = organ.transform;
        
        if (OrganInfoManager.Instance != null)
        {
            OrganInfoManager.Instance.SetCurrentOrgan(organ);

            OrganInfoManager.Instance.ShowInfoButton();

            Debug.Log("SHOW INFO BUTTON");
        }
        
        originalPosition =
            currentOrgan.position;

        originalScale =
            currentOrgan.localScale;

        originalRotation =
            currentOrgan.rotation;

        
        // 关闭 Pulse Outline
        currentPulse =
            currentOrgan.GetComponentInParent<MultiPulseOutline>();

        if (currentPulse != null)
        {
            currentPulse.DisablePulse();
        }

        // 隐藏同系统其它器官
        Transform parent =
            currentOrgan.parent;

        foreach (Transform child in parent)
        {
            if (child != currentOrgan)
            {
                child.gameObject.SetActive(false);
            }
        }

        // 收起 ScrollView
        if (menuController != null)
        {
            menuController.OnSystemSelected();
        }

        // 隐藏菜单按钮
        if (menuButton != null)
        {
            menuButton.SetActive(false);
        }

        // 显示 Exit Button
        if (exitButton != null)
        {
            exitButton.SetActive(true);
        }
        GameObject infoButton =
            OrganInfoManager.Instance.infoButton;

        if (infoButton != null)
        {
            infoButton.SetActive(true);
        }

        StartCoroutine(FocusAnimation());
    }

    IEnumerator FocusAnimation()
    {
        float t = 0f;

        Vector3 startPosition =
            currentOrgan.position;

        Vector3 targetPosition =
            Camera.main.transform.position +
            Camera.main.transform.forward *
            currentInteractable.focusDistance -

            Camera.main.transform.up *
            currentInteractable.focusHeightOffset;

        Vector3 targetScale =
            originalScale *
            currentInteractable.focusScale;

        while (t < animationDuration)
        {
            t += Time.deltaTime;

            float p =
                Mathf.SmoothStep(
                    0f,
                    1f,
                    t / animationDuration);

            currentOrgan.position =
                Vector3.Lerp(
                    startPosition,
                    targetPosition,
                    p);

            currentOrgan.localScale =
                Vector3.Lerp(
                    originalScale,
                    targetScale,
                    p);

            currentOrgan.rotation =
                originalRotation;

            yield return null;
        }

        currentOrgan.position =
            targetPosition;

        currentOrgan.localScale =
            targetScale;

        currentOrgan.rotation =
            originalRotation;
        
        isInFocusMode = true;
    }
    private void LateUpdate()
    {
        if (!isInFocusMode)
            return;

        if (currentOrgan == null)
            return;

        if (currentInteractable == null)
            return;

        Vector3 targetPosition =
            Camera.main.transform.position +
            Camera.main.transform.forward *
            currentInteractable.focusDistance -

            Camera.main.transform.up *
            currentInteractable.focusHeightOffset;

        currentOrgan.position =
            targetPosition;

        currentOrgan.localScale =
            originalScale *
            currentInteractable.focusScale;
    }
    
    public void ExitFocus()
    {
        if (OrganInfoManager.Instance != null)
        {
            OrganInfoManager.Instance
                .ForceClose();
        }
        isInFocusMode = false;
        
        if (!isFocused)
            return;

        StartCoroutine(ReturnAnimation());
    }

    IEnumerator ReturnAnimation()
    {
        float t = 0f;

        Vector3 startPosition =
            currentOrgan.position;

        Vector3 startScale =
            currentOrgan.localScale;

        while (t < animationDuration)
        {
            t += Time.deltaTime;

            float p =
                Mathf.SmoothStep(
                    0f,
                    1f,
                    t / animationDuration);

            currentOrgan.position =
                Vector3.Lerp(
                    startPosition,
                    originalPosition,
                    p);

            currentOrgan.localScale =
                Vector3.Lerp(
                    startScale,
                    originalScale,
                    p);

            currentOrgan.rotation =
                originalRotation;

            yield return null;
        }

        currentOrgan.position =
            originalPosition;

        currentOrgan.localScale =
            originalScale;

        currentOrgan.rotation =
            originalRotation;

        // 恢复同系统其它器官
        Transform parent =
            currentOrgan.parent;

        foreach (Transform child in parent)
        {
            child.gameObject.SetActive(true);
        }

        // 恢复 Outline Pulse
        if (currentPulse != null)
        {
            currentPulse.EnablePulse();
        }

        // 恢复菜单按钮
        if (menuButton != null)
        {
            menuButton.SetActive(true);
        }

        // 隐藏 Exit Button
        if (exitButton != null)
        {
            exitButton.SetActive(false);
        }

        currentInteractable = null;
        currentPulse = null;

        isFocused = false;
    }
    public OrganInteractable GetCurrentOrgan()
    {
        return currentInteractable;
    }
    public void ForceExitFocus()
    {
        StopAllCoroutines();

        if (currentOrgan != null)
        {
            currentOrgan.position =
                originalPosition;

            currentOrgan.localScale =
                originalScale;

            currentOrgan.rotation =
                originalRotation;

            Transform parent =
                currentOrgan.parent;

            foreach (Transform child in parent)
            {
                child.gameObject.SetActive(true);
            }
        }

        if (currentPulse != null)
        {
            currentPulse.EnablePulse();
        }

        if (exitButton != null)
        {
            exitButton.SetActive(false);
        }

        isFocused = false;
        isInFocusMode = false;

        currentOrgan = null;
        currentInteractable = null;
        currentPulse = null;
    }

}
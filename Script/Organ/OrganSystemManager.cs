using System.Collections;
using UnityEngine;

public class OrganSystemManager : MonoBehaviour
{
    public OrganCategory[] categories;
    public static OrganSystemManager Instance;

    private bool isSwitching = false;

    private void Awake()
    {
        Instance = this;
    }
    public int CurrentSystemIndex
    {
        get;
        private set;
    }
    
    public void ShowCategory(int index)
    {
        OrganFocusManager.Instance
            .EnableOrganInteraction();

        if (isSwitching)
            return;

        StartCoroutine(SwitchCategory(index));
        CurrentSystemIndex = index;
    }

    IEnumerator SwitchCategory(int index)
    {
        isSwitching = true;

        // 找目前正在显示的系统
        GameObject currentSystem = null;

        foreach (var category in categories)
        {
            if (category.organObject.activeSelf)
            {
                currentSystem = category.organObject;
                break;
            }
        }

        // 如果有旧系统
        if (currentSystem != null)
        {
            Vector3 originalScale =
                currentSystem.transform.localScale;

            float t = 0f;

            while (t < 0.15f)
            {
                t += Time.deltaTime;

                currentSystem.transform.localScale =
                    Vector3.Lerp(
                        originalScale,
                        Vector3.zero,
                        t / 0.15f);

                yield return null;
            }

            currentSystem.SetActive(false);

            currentSystem.transform.localScale =
                originalScale;
        }

        // 關閉全部系統 + 關閉全部 Pulse
        foreach (var category in categories)
        {
            MultiPulseOutline pulse =
                category.organObject.GetComponent<MultiPulseOutline>();

            if (pulse != null)
            {
                pulse.DisablePulse();
            }

            category.organObject.SetActive(false);
        }

        // 開啟目標系統
        GameObject newSystem =
            categories[index].organObject;

        newSystem.SetActive(true);

        Vector3 targetScale =
            newSystem.transform.localScale;

        newSystem.transform.localScale =
            Vector3.zero;

        float t2 = 0f;

        while (t2 < 0.2f)
        {
            t2 += Time.deltaTime;

            newSystem.transform.localScale =
                Vector3.Lerp(
                    Vector3.zero,
                    targetScale,
                    t2 / 0.2f);

            yield return null;
        }

        newSystem.transform.localScale =
            targetScale;

        // 開啟當前系統 Pulse
        MultiPulseOutline selectedPulse =
            newSystem.GetComponent<MultiPulseOutline>();

        if (selectedPulse != null)
        {
            selectedPulse.EnablePulse();
        }

        isSwitching = false;
    }

    public void ShowAllSystems()
    {
        OrganFocusManager.Instance
            .DisableOrganInteraction();
        
        foreach (var category in categories)
        {
            category.organObject.SetActive(true);

            MultiPulseOutline pulse =
                category.organObject.GetComponent<MultiPulseOutline>();

            if (pulse != null)
            {
                pulse.DisablePulse();
            }
        }
    }
}
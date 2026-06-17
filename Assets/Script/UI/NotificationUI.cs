using System.Collections;
using UnityEngine;

public class NotificationUI : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public RectTransform panel;

    public float showDuration = 0.25f;
    public float displayDuration = 2f;
    public float hideDuration = 0.35f;

    private Vector2 originalPos;

    private void Awake()
    {
        originalPos =
            panel.anchoredPosition;

        canvasGroup.alpha = 0f;

        panel.localScale =
            Vector3.one;
    }

    public void ShowNotification()
    {
        gameObject.SetActive(true);

        StopAllCoroutines();

        StartCoroutine(NotificationRoutine());
    }

    IEnumerator NotificationRoutine()
    {
        Debug.Log("NOTIFICATION ROUTINE START");
        gameObject.SetActive(true);

        // SHOW

        canvasGroup.alpha = 0f;

        panel.localScale =
            Vector3.one * 0.8f;

        panel.anchoredPosition =
            originalPos;

        float t = 0f;

        while (t < showDuration)
        {
            t += Time.deltaTime;

            float p =
                Mathf.Clamp01(
                    t / showDuration);

            canvasGroup.alpha = p;

            panel.localScale =
                Vector3.Lerp(
                    Vector3.one * 0.8f,
                    Vector3.one * 1.05f,
                    p);

            yield return null;
        }

        canvasGroup.alpha = 1f;

        panel.localScale =
            Vector3.one;

        yield return new WaitForSeconds(
            displayDuration);

        // HIDE

        t = 0f;

        Vector2 startPos =
            panel.anchoredPosition;

        Vector2 targetPos =
            startPos +
            new Vector2(0, 20);

        while (t < hideDuration)
        {
            t += Time.deltaTime;

            float p =
                Mathf.Clamp01(
                    t / hideDuration);

            canvasGroup.alpha =
                1f - p;

            panel.localScale =
                Vector3.Lerp(
                    Vector3.one,
                    Vector3.one * 1.15f,
                    p);

            panel.anchoredPosition =
                Vector2.Lerp(
                    startPos,
                    targetPos,
                    p);

            yield return null;
        }

        canvasGroup.alpha = 0f;

        panel.localScale =
            Vector3.one;

        panel.anchoredPosition =
            originalPos;
    }
}
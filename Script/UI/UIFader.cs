using System.Collections;
using UnityEngine;

public class UIFader : MonoBehaviour
{
    public float fadeDuration = 0.3f;

    private CanvasGroup canvasGroup;
    private RectTransform rect;

    private Vector2 hiddenPos;
    private Vector2 shownPos;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rect = GetComponent<RectTransform>();

        shownPos = rect.anchoredPosition;
        hiddenPos = shownPos + new Vector2(0, -200);

        HideInstant();
    }

    public void HideInstant()
    {
        canvasGroup.alpha = 0f;

        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        rect.anchoredPosition = hiddenPos;

        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);

        StopAllCoroutines();

        StartCoroutine(FadeIn());
    }

    public void Hide()
    {
        StopAllCoroutines();

        StartCoroutine(FadeOut());
    }

    IEnumerator FadeIn()
    {
        float t = 0f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;

            float p = Mathf.Clamp01(t / fadeDuration);

            canvasGroup.alpha = p;

            rect.anchoredPosition =
                Vector2.Lerp(hiddenPos, shownPos, p);

            yield return null;
        }

        canvasGroup.alpha = 1f;

        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

        rect.anchoredPosition = shownPos;
    }

    IEnumerator FadeOut()
    {
        float t = 0f;

        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;

            float p = Mathf.Clamp01(t / fadeDuration);

            canvasGroup.alpha = 1f - p;

            rect.anchoredPosition =
                Vector2.Lerp(shownPos, hiddenPos, p);

            yield return null;
        }

        canvasGroup.alpha = 0f;

        rect.anchoredPosition = hiddenPos;

        gameObject.SetActive(false);
    }
}
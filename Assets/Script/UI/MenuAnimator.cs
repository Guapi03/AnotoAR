using System.Collections;
using UnityEngine;

public class MenuAnimator : MonoBehaviour
{
    public float duration = 0.25f;

    CanvasGroup canvasGroup;
    RectTransform rect;

    Vector2 hiddenPos;
    Vector2 shownPos;

    private void Awake()
    {
        canvasGroup =
            GetComponent<CanvasGroup>();

        rect =
            GetComponent<RectTransform>();

        shownPos =
            rect.anchoredPosition;

        hiddenPos =
            shownPos + new Vector2(0, -250);

        HideInstant();
    }

    public void HideInstant()
    {
        StopAllCoroutines();

        canvasGroup.alpha = 0;

        rect.anchoredPosition = hiddenPos;

        gameObject.SetActive(false);
    }

    public void Show()
    {
        StopAllCoroutines();

        gameObject.SetActive(true);

        StartCoroutine(ShowRoutine());
    }

    public void Hide()
    {
        StopAllCoroutines();

        StartCoroutine(HideRoutine());
    }

    IEnumerator ShowRoutine()
    {
        float t = 0;

        while (t < duration)
        {
            t += Time.deltaTime;

            float p =
                Mathf.Clamp01(t / duration);

            canvasGroup.alpha = p;

            rect.anchoredPosition =
                Vector2.Lerp(
                    hiddenPos,
                    shownPos,
                    p);

            yield return null;
        }
    }

    IEnumerator HideRoutine()
    {
        float t = 0;

        while (t < duration)
        {
            t += Time.deltaTime;

            float p =
                Mathf.Clamp01(t / duration);

            canvasGroup.alpha =
                1 - p;

            rect.anchoredPosition =
                Vector2.Lerp(
                    shownPos,
                    hiddenPos,
                    p);

            yield return null;
        }

        gameObject.SetActive(false);
    }
    
}
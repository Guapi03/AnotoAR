using UnityEngine;
using UnityEngine.UI;

public class OrganScrollUI : MonoBehaviour
{
    public OrganSystemManager systemManager;
    public OrganMenuController menuController;
    public RectTransform content;

    public GameObject buttonPrefab;

    [Header("Scroll")]
    public ScrollRect scrollRect;
    
    [Header("Selection Colors")]
    public Color normalColor = Color.white;

    public Color selectedColor =
        new Color(0.3f, 0.8f, 1f);

    private Button currentSelected;

    private void Start()
    {
        GenerateButtons();
    }

    void GenerateButtons()
    {
        for (int i = 0; i < systemManager.categories.Length; i++)
        {
            int index = i;

            GameObject button =
                Instantiate(buttonPrefab, content);

            RectTransform rect =
                button.GetComponent<RectTransform>();

            rect.localScale = Vector3.one;

            LayoutRebuilder.ForceRebuildLayoutImmediate(content);

            Button btn =
                button.GetComponent<Button>();

            Transform iconTransform =
                button.transform.Find("Icon");

            Image img =
                iconTransform.GetComponent<Image>();

            img.sprite =
                systemManager.categories[i].icon;

            btn.onClick.AddListener(() =>
            {
                SelectButton(btn);

                systemManager.ShowCategory(index);

                menuController.OnSystemSelected();
            });
        }
    }

    void SelectButton(Button selected)
    {
        foreach (Button btn in content.GetComponentsInChildren<Button>())
        {
            btn.transform.localScale = Vector3.one;

            Image icon =
                btn.transform.Find("Icon")
                    .GetComponent<Image>();

            icon.color = normalColor;
        }

        selected.transform.localScale =
            Vector3.one * 1.2f;

        Image selectedIcon =
            selected.transform.Find("Icon")
                .GetComponent<Image>();

        selectedIcon.color = selectedColor;

        currentSelected = selected;
    }

    public void ResetUI()
    {
        // Scroll 回最左边
        if (scrollRect != null)
        {
            Canvas.ForceUpdateCanvases();

            scrollRect.horizontalNormalizedPosition = 0f;
        }

        foreach (Button btn in content.GetComponentsInChildren<Button>())
        {
            btn.transform.localScale = Vector3.one;

            Image icon =
                btn.transform.Find("Icon")
                    .GetComponent<Image>();

            icon.color = normalColor;
        }

        currentSelected = null;
    }
}
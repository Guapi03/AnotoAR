using UnityEngine;

public class OrganMenuController : MonoBehaviour
{
    public MenuAnimator menuAnimator;

    bool opened = false;

    public void ToggleMenu()
    {
        opened = !opened;

        if (opened)
        {
            menuAnimator.Show();
            gameObject.SetActive(false);
        }
        else
        {
            menuAnimator.Hide();
        }
    }

    public void ShowButton()
    {
        opened = false;

        gameObject.SetActive(true);
    }
    
    public void OnSystemSelected()
    {
        opened = false;

        menuAnimator.Hide();

        gameObject.SetActive(true);
    }
    public void ForceCloseMenu()
    {
        opened = false;

        menuAnimator.Hide();
    }
}
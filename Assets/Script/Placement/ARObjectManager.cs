using System.Collections;
using UnityEngine;

public class ARObjectManager : MonoBehaviour
{
    public static ARObjectManager Instance;

    [Header("UI")]
    public UIFader menuButtonFader;
    public OrganMenuController menuController;
    public NotificationUI notificationUI;

    [Header("References")]
    public GameObject planeFinder;
    public GameObject groundPlaneStage;
    public GameObject model;

    [Header("Placement")]
    public GroundPlanePlacementWatcher placementWatcher;

    [Header("Organ System")]
    public OrganSystemManager organSystemManager;
    public OrganScrollUI organScrollUI;
    public OrganFocusManager focusManager;
    
    [Header("Settings")]
    [Range(1, 30)]
    public float disappearTime = 3f;

    private bool objectPlaced = false;
    private bool canPlace = true;
    private Quaternion originalRotation;

    private float invisibleTimer = 0f;

    private Renderer[] renderers;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        renderers =
            model.GetComponentsInChildren<Renderer>(true);

        originalRotation =
            model.transform.rotation;

        model.SetActive(false);

        menuButtonFader.HideInstant();
    }

    public bool CanPlace()
    {
        return canPlace;
    }

    private void Update()
    {
        if (!objectPlaced)
            return;

        bool visible = false;

        foreach (Renderer rend in renderers)
        {
            if (rend != null && rend.isVisible)
            {
                visible = true;
                break;
            }
        }

        if (visible)
        {
            invisibleTimer = 0f;
        }
        else
        {
            invisibleTimer += Time.deltaTime;

            if (invisibleTimer >= disappearTime)
            {
                ResetPlacement();
            }
        }
    }

    public void ObjectPlaced()
    {
        if (!canPlace)
            return;

        canPlace = false;

        objectPlaced = true;
        invisibleTimer = 0f;

        planeFinder.SetActive(false);

        if (organSystemManager != null)
        {
            organSystemManager.ShowAllSystems();
        }

        if (organScrollUI != null)
        {
            organScrollUI.ResetUI();
        }

        StartCoroutine(FaceUserAfterPlacement());
    }

    public void ResetPlacement()
    {
        StartCoroutine(ResetSequence());
    }

    public void ShowModel()
    {
        model.SetActive(true);

        menuButtonFader.Show();

        renderers =
            model.GetComponentsInChildren<Renderer>(true);

        StartCoroutine(SpawnAnimation());
    }
    
    void FaceUser()
    {
        Vector3 cameraPos =
            Camera.main.transform.position;

        Vector3 lookDirection =
            cameraPos - model.transform.position;

        lookDirection.y = 0f;

        if (lookDirection.sqrMagnitude > 0.001f)
        {
            model.transform.rotation =
                Quaternion.LookRotation(
                    -lookDirection.normalized)
                * Quaternion.Euler(0, 0, 0);
        }
    }
    

    IEnumerator SpawnAnimation()
    {
        Vector3 targetScale = Vector3.one;

        model.transform.localScale =
            Vector3.zero;

        float t = 0f;

        while (t < 0.25f)
        {
            t += Time.deltaTime;

            model.transform.localScale =
                Vector3.Lerp(
                    Vector3.zero,
                    targetScale * 1.1f,
                    t / 0.25f);

            yield return null;
        }

        t = 0f;

        while (t < 0.1f)
        {
            t += Time.deltaTime;

            model.transform.localScale =
                Vector3.Lerp(
                    targetScale * 1.1f,
                    targetScale,
                    t / 0.1f);

            yield return null;
        }

        model.transform.localScale =
            targetScale;
    }
    IEnumerator ResetSequence()
    {
        if (focusManager != null)
        {
            focusManager.ForceExitFocus();
        }
        if (OrganInfoManager.Instance != null)
        {
            OrganInfoManager.Instance.ForceClose();
        }
        
        canPlace = true;

        objectPlaced = false;
        invisibleTimer = 0f;
        
        if (menuController != null)
        {
            menuController.ForceCloseMenu();
        }
        menuButtonFader.Hide();
        
        if (notificationUI != null)
        {
            Debug.Log("CALL NOTIFICATION");
            notificationUI.ShowNotification();
        }
        
        yield return new WaitForSeconds(0.35f);

        model.SetActive(false);
        model.transform.rotation =
            originalRotation;

        model.transform.localScale =
            Vector3.one;

        planeFinder.SetActive(true);

        if (placementWatcher != null)
        {
            placementWatcher.ResetWatcher();
        }
    }
    IEnumerator FaceUserAfterPlacement()
    {
        yield return new WaitForEndOfFrame();

        yield return new WaitForSeconds(0.1f);

        FaceUser();
    }
}

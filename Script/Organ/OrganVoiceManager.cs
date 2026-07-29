using UnityEngine;

public class OrganVoiceManager : MonoBehaviour
{
    public static OrganVoiceManager Instance;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;

    [Header("Voice Icons")]
    [SerializeField] private GameObject soundOnIcon;
    [SerializeField] private GameObject soundOffIcon;

    private OrganInteractable currentOrgan;

    private bool isPlaying = false;
    private bool isPaused = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        UpdateVoiceIcon();
    }

    private void Update()
    {
        // Detect playback finished
        if (isPlaying &&
            !isPaused &&
            !audioSource.isPlaying)
        {
            PlaybackFinished();
        }
    }
    public void SetCurrentOrgan(OrganInteractable organ)
    {
        if (currentOrgan != organ)
        {
            StopVoice();
            currentOrgan = organ;
        }
    }

    public void OnVoiceButtonPressed()
    {
        if (currentOrgan == null)
            return;

        if (currentOrgan.narrationClip == null)
            return;

        // First Play / Replay
        if (!isPlaying)
        {
            audioSource.clip = currentOrgan.narrationClip;
            audioSource.Play();

            isPlaying = true;
            isPaused = false;

            UpdateVoiceIcon();
            return;
        }

        // Pause
        if (!isPaused)
        {
            audioSource.Pause();
            isPaused = true;

            UpdateVoiceIcon();
            return;
        }

        // Continue
        audioSource.UnPause();
        isPaused = false;

        UpdateVoiceIcon();
    }

    public void StopVoice()
    {
        audioSource.Stop();

        isPlaying = false;
        isPaused = false;

        UpdateVoiceIcon();
    }

    private void PlaybackFinished()
    {
        isPlaying = false;
        isPaused = false;

        UpdateVoiceIcon();
    }

    private void UpdateVoiceIcon()
    {
        if (soundOnIcon != null)
            soundOnIcon.SetActive(!isPlaying || isPaused);

        if (soundOffIcon != null)
            soundOffIcon.SetActive(isPlaying && !isPaused);
    }

    public bool IsPlaying()
    {
        return isPlaying && !isPaused;
    }

    public bool IsPaused()
    {
        return isPaused;
    }
}
using System.Collections.Generic;
using UnityEngine;

public class MultiPulseOutline : MonoBehaviour
{
    [Header("Outline Objects")]
    public List<Outline> outlines = new List<Outline>();

    [Header("Pulse Settings")]
    public float minWidth = 2f;
    public float maxWidth = 8f;
    public float pulseSpeed = 2f;

    private List<float> randomOffsets = new List<float>();

    private bool pulseEnabled = false;

    void Start()
    {
        randomOffsets.Clear();

        foreach (var outline in outlines)
        {
            if (outline == null)
                continue;

            outline.enabled = false;

            randomOffsets.Add(
                UnityEngine.Random.Range(
                    0f,
                    Mathf.PI * 2f));
        }
    }

    void Update()
    {
        if (!pulseEnabled)
            return;

        for (int i = 0; i < outlines.Count; i++)
        {
            if (outlines[i] == null)
                continue;

            float pulse =
                (Mathf.Sin(
                    Time.time * pulseSpeed +
                    randomOffsets[i]) + 1f) * 0.5f;

            outlines[i].OutlineWidth =
                Mathf.Lerp(
                    minWidth,
                    maxWidth,
                    pulse);
        }
    }

    public void EnablePulse()
    {
        Debug.Log("Enable Pulse : " + gameObject.name);

        pulseEnabled = true;

        foreach (var outline in outlines)
        {
            if (outline == null)
                continue;

            outline.enabled = true;
            outline.OutlineWidth = maxWidth;
        }
    }

    public void DisablePulse()
    {
        Debug.Log("Disable Pulse : " + gameObject.name);

        pulseEnabled = false;

        foreach (var outline in outlines)
        {
            if (outline == null)
                continue;

            outline.OutlineWidth = minWidth;
            outline.enabled = false;
        }
    }
}
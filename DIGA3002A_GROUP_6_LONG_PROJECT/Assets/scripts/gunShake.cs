using UnityEngine;
using Cinemachine;
using System.Collections;

public class gunShake : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinemachineVCam;
    private CinemachineBasicMultiChannelPerlin noise;

    private void Awake()
    {
        noise = cinemachineVCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    /// <summary>
    /// Trigger a one-shot shake without stacking continuously
    /// </summary>
    public void Shake(float amplitude, float frequency, float duration)
    {
        // Stop any running shake coroutine so we don’t stack shakes
        StopAllCoroutines();
        StartCoroutine(ShakeRoutine(amplitude, frequency, duration));
    }

    private IEnumerator ShakeRoutine(float amplitude, float frequency, float duration)
    {
        noise.m_AmplitudeGain = amplitude;
        noise.m_FrequencyGain = frequency;

        yield return new WaitForSeconds(duration);

        // Reset shake after duration
        noise.m_AmplitudeGain = 0f;
        noise.m_FrequencyGain = 0f;
    }
}
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AttackIndicator : MonoBehaviour
{
    public Image indicator;         // Single arrow image
    public float activeTime = 0.5f;
    public float fadeDuration = 0.5f;

    private Transform playerCamera;

    private void Start()
    {
        playerCamera = Camera.main.transform;
        indicator.gameObject.SetActive(false);
    }

    public void ShowIndicator(Vector3 attackDirection)
    {
        // Get direction relative to camera
        Vector3 localDir = playerCamera.InverseTransformDirection(attackDirection);
        localDir.y = 0;  // ignore vertical
        localDir.Normalize();

        // Compute angle in degrees
        float angle = Mathf.Atan2(localDir.x, localDir.z) * Mathf.Rad2Deg;

        // Rotate the indicator
        indicator.transform.rotation = Quaternion.Euler(0, 0, -angle);

        // Start flashing
        StartCoroutine(FlashIndicator());
    }

    private IEnumerator FlashIndicator()
    {
        indicator.gameObject.SetActive(true);
        indicator.color = new Color(1, 0, 0, 1);

        // Wait for activeTime
        yield return new WaitForSeconds(activeTime);

        // Fade out
        float elapsed = 0f;
        Color startColor = indicator.color;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(startColor.a, 0, elapsed / fadeDuration);
            indicator.color = new Color(1, 0, 0, alpha);
            yield return null;
        }

        indicator.gameObject.SetActive(false);
    }
}

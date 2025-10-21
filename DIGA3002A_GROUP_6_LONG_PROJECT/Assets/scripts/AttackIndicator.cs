using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI; 

public class AttackIndicator : MonoBehaviour
{
    public Image frontIndicator;
    public Image backIndicator;
    public Image leftIndicator;
    public Image rightIndicator;

    public float fadeDuration = 0.5f;
    public float activeTime = 0.3f;

    private Transform playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = Camera.main.transform;

        HideAll();
    }

    public void ShowIndicator(Vector3 attackDirection)
    {
        Vector3 localDir = playerCamera.InverseTransformDirection(attackDirection.normalized);

        if (Mathf.Abs(localDir.z) > Mathf.Abs(localDir.x))
        {
            if (localDir.z > 0) 
            {
                StartCoroutine(Flash(frontIndicator));
            }
            else
            {
                StartCoroutine(Flash(backIndicator)); 
            }
        }
        else
        {
            if(localDir.x > 0)
            {
                StartCoroutine(Flash(rightIndicator));
            }
            else
            {
                StartCoroutine(Flash(leftIndicator));
            }
        }
    }

    private IEnumerator Flash(Image indicator)
    {
        indicator.gameObject.SetActive(true);
        indicator.color = new Color(1, 0, 0, 1); 

        yield return new WaitForSeconds(activeTime);

        float elapsed = 0f;
        while (elapsed  < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, elapsed / fadeDuration);
            indicator.color = new Color(1, 0, 0, alpha);
            yield return null; 
        }
        indicator.gameObject.SetActive(false);
    }

    private void HideAll()
    {
        frontIndicator.gameObject.SetActive(false);
        backIndicator.gameObject.SetActive(false);
        leftIndicator.gameObject.SetActive(false);
        rightIndicator.gameObject.SetActive(false);
    }

}

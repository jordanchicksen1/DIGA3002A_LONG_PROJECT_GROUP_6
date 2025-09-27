using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform player;           
    public float followDistance = 15f; 
    public float minYRotation = -90f;  
    public float maxYRotation = 90f;  
    public float rotationSpeed = 5f;   

    void Update()
    {
        if (player == null)
            return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= followDistance)
        {
            Vector3 direction = player.position - transform.position;
            direction.y = 0f;

            if (direction.sqrMagnitude > 0.001f)
            {
                float targetY = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

                targetY = Mathf.Clamp(targetY, minYRotation, maxYRotation);

                Quaternion targetRotation = Quaternion.Euler(0f, targetY, 0f);

                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }
        }
        else
        {
            Quaternion neutralRotation = Quaternion.identity;
            transform.rotation = Quaternion.Lerp(transform.rotation, neutralRotation, Time.deltaTime * rotationSpeed);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunMovement : MonoBehaviour
{
    public Transform player;
    public float rotationSpeed = 5f; 

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return;
        }

        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0f; 

        if (direction.magnitude > 0.1f)
        {
            Quaternion targetRotation  = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }
}

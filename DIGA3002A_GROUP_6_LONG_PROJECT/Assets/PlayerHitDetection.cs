using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitDetection : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check for bullets
        if (collision.gameObject.CompareTag("BasicBullet"))
        {
            Rigidbody bulletRb = collision.rigidbody;
            Vector3 attackDir;

            // Get the direction the bullet was traveling
            if (bulletRb != null && bulletRb.velocity.sqrMagnitude > 0.001f)
                attackDir = bulletRb.velocity.normalized;
            else
                attackDir = (transform.position - collision.transform.position).normalized;

            // Show attack direction indicator
            AttackIndicator indicator = FindObjectOfType<AttackIndicator>();
            if (indicator != null)
                indicator.ShowIndicator(attackDir);
            else
                Debug.LogWarning("AttackIndicator not found in scene!");

            // Optionally handle player damage here
            // playerHealth.TakeDamage(damageAmount);

            // Optional: destroy the bullet
            // Destroy(collision.gameObject);
        }
    }
}

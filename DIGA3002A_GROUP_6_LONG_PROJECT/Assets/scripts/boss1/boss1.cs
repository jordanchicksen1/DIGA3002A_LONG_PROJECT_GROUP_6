using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss1 : MonoBehaviour
{
    public boss1HealthBar boss1HealthBar;
    public boss1Posture boss1Posture;
    public Rigidbody dummyRigidbody;
    public Transform dummyTarget;
    public float dummySpeed = 2f;
    public Transform player;
    public float knockbackForce = 1f;
    public float knockbackDuration = 0.2f;

    private bool isKnockedBack = false;

    void Update()
    {
        if(boss1Posture.isStaggered == false)
        {
            if (!isKnockedBack)
            {
                Vector3 newPos = Vector3.MoveTowards(transform.position, dummyTarget.position, dummySpeed * Time.deltaTime);
                dummyRigidbody.MovePosition(newPos);   // Rigidbody-safe movement
                transform.LookAt(player);
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 knockbackDirection = (transform.position - other.transform.position).normalized;

        if (other.CompareTag("BasicBullet"))
        {
            Destroy(other.gameObject);
            boss1HealthBar.BasicHit();
            boss1Posture.PostureHitALot();
            StartCoroutine(ApplyKnockback(knockbackDirection));
        }

        if (other.CompareTag("MachineBullet"))
        {
            Destroy(other.gameObject);
            boss1HealthBar.LaserHit();
            boss1Posture.SmallPostureHit();
            StartCoroutine(ApplyKnockback(knockbackDirection));
        }

        if (other.CompareTag("AssaultBullet"))
        {
            Destroy(other.gameObject);
            boss1HealthBar.AssaultHit();
            boss1Posture.PostureHitALot();
            StartCoroutine(ApplyKnockback(knockbackDirection));
        }

        if (other.CompareTag("LaserBullet"))
        {
            Destroy(other.gameObject);
            boss1HealthBar.LaserHit();
            boss1Posture.BigPostureHit();
            StartCoroutine(ApplyKnockback(knockbackDirection));
        }
    }

    private IEnumerator ApplyKnockback(Vector3 direction)
    {
        isKnockedBack = true;

        // Ensure knockback only happens in the XZ plane (no floating up/down)
        direction.y = 0f;

        dummyRigidbody.AddForce(direction.normalized * knockbackForce, ForceMode.Impulse);

        yield return new WaitForSeconds(knockbackDuration);

        // Stop the dummy from drifting forever
        dummyRigidbody.velocity = Vector3.zero;
        dummyRigidbody.angularVelocity = Vector3.zero;

        isKnockedBack = false;
    }
}

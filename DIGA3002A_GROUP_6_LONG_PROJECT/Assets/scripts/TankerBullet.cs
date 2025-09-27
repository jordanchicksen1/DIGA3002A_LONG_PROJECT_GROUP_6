using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankerBullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 5f;
    public GameObject explosionEffect;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed; 
        Destroy(gameObject, lifetime); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (explosionEffect != null)
        {
            GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);

            ParticleSystem ps = explosion.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                Destroy(explosion, ps.main.duration);
            }
            else
            {
                Destroy(explosion, 2f);
            }
        }

        Destroy(gameObject);
    }
}

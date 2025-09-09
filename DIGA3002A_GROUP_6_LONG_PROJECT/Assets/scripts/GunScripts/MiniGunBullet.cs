using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MiniGunBullet : MonoBehaviour
{

    [SerializeField] private float Timer;
    [SerializeField] private Rigidbody rb;

    [Header("Movement")]
    public float speed;

    [Header("damage")]
    public float Damage;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.right * speed, ForceMode.Impulse);

    }

    private void Update()
    {
        DestroyMyself();
    }

    public void DestroyMyself() 
    {
        Timer += Time.deltaTime;

        if (Timer > 4) 
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
       if (other.gameObject) 
        {
            Destroy(this.gameObject);
        }
    }
}

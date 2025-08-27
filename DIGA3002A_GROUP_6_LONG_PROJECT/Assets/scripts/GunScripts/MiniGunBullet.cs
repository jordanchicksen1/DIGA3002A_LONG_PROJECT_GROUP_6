using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MiniGunBullet : MonoBehaviour
{

    [SerializeField] private float Timer;
    [SerializeField] private Rigidbody rb;

    public float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    private void Update()
    {
        //DestroyMyself();
    }

    public void DestroyMyself() 
    {
        Timer += Time.deltaTime;

        if (Timer > 3) 
        {
            Destroy(this.gameObject);
        }
    }
}

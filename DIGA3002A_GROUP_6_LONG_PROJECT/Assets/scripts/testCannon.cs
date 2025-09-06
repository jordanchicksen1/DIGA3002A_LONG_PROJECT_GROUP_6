using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCannon : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float shootTime;
    public float bulletSpeed;
   
    public void Update()
    {
        shootTime += Time.deltaTime;

        if (shootTime > 3)
        {
            shootTime = 0;
           
            var projectile = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

            var rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = spawnPoint.forward * bulletSpeed;

            Destroy(projectile, 1f);
        }
    }
}

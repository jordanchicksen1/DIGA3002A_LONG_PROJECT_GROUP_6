using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGun : MonoBehaviour
{
    public bool Shooting;
    public GameObject Bullet;
    public Transform ShootPoint;



    private void FixedUpdate()
    {
        if (Shooting)
        {
            Debug.Log("BRRRRRRRRR");
            Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossShield : MonoBehaviour
{
    public bossShieldHealth bossShieldHealth;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "BasicBullet")
        {
            Destroy(other.gameObject);
            bossShieldHealth.BasicHit();
        }

        if(other.tag == "MachineBullet")
        {
            Destroy(other.gameObject);
            bossShieldHealth.MachineHit();
        }

        if(other.tag == "AssaultBullet")
        {
            Destroy(other.gameObject);
            bossShieldHealth.AssaultHit();

        }

        if(other.tag == "LaserBullet")
        {
            Destroy(other.gameObject) ;
            bossShieldHealth.LaserHit();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicShield : MonoBehaviour
{
    public basicShieldHealth basicShieldHealth;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyBulletSmall")
        {
            basicShieldHealth.ShieldHit();
            Destroy(other.gameObject);
        }

        if (other.tag == "EnemyBulletMedium")
        {
            basicShieldHealth.ShieldHitALot();
            Destroy(other.gameObject);
        }

        if(other.tag == "EnemyBulletLarge")
        {
            basicShieldHealth.ShieldHitATon();
            Destroy(other.gameObject);
        }
    }
}

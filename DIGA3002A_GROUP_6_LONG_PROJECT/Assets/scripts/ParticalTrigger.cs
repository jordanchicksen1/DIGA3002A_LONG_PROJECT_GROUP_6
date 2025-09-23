using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalTrigger : MonoBehaviour
{
    public GameObject AcitveBackground;
    public GameObject OtherBackground1;
    public GameObject OtherBackground2;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AcitveBackground.SetActive(true);
            OtherBackground1.SetActive(false);
            OtherBackground2.SetActive(false);
        }
    }


}

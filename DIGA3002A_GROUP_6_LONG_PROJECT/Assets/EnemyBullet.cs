using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [HideInInspector] public Vector3 direction;
    public float speed = 20f;

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}

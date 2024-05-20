using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
 Rigidbody rb;
    public float BulletSpeed;
    public float Endtime;


    // Update is called once per frame
    void Start()
    {
     rb=GetComponent<Rigidbody>();

        rb.velocity = transform.forward * BulletSpeed;
        Destroy(gameObject, Endtime);
    }
}

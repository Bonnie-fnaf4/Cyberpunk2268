using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class BulletSpeed : MonoBehaviour
{
    Rigidbody rigidbody;
    public float speed;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(transform.forward * speed);
        Destroy(gameObject, 1);
    }
    void Update()
    {
        //rigidbody.AddForce(transform.forward * speed);
    }
}

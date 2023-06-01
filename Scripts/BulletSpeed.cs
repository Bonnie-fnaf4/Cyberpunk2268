using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class BulletSpeed : MonoBehaviour
{
    Rigidbody rigidbody;
    public float speed;

    MeshRenderer mesh;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(transform.forward * speed);
        Destroy(gameObject, 1);

        mesh = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        //rigidbody.AddForce(transform.forward * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.other.tag == "Enemy")
        {
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            Destroy(mesh);
        }
    }
}

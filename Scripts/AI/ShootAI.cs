using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAI : MonoBehaviour
{
    public GameObject Bullet;

    public void Shoot()
    {
        Instantiate(Bullet, transform.position, transform.rotation);
    }
}

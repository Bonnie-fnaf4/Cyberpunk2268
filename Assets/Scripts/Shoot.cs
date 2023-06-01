using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject Player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(Bullet, transform.position, Quaternion.Euler(transform.rotation.eulerAngles));
            //Debug.Log("" + Quaternion.Euler(transform.rotation.eulerAngles));
        }
    }
}

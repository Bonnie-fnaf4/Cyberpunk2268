using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLegs : MonoBehaviour
{
    public Controller controller;

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground")
        {
            controller.isGrond = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            controller.isGrond = true;
        }
    }
}

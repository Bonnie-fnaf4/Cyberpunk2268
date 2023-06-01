using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Controller : MonoBehaviour
{
    [Header("Камера игрока")]
    public Transform maincamera;

    Quaternion quaternionPlayer = Quaternion.Euler(0, 0, 0), quaternionMainCamera = Quaternion.Euler(0, 0, 0);
    Rigidbody rigidbody;

    [Header("Чувствительность камеры")]
    public float MousSpeed = 5;

    [Header("Скорость игрока")]
    public float speed = 15;

    [Header("Ускорения на земле игрока")]
    public float speedUP = 5;

    [Header("Ускорения в воздухе игрока")]
    public float speedUPAir = 1;

    [Header("Сила прыжка игрока")]
    public float speedJump = 5;

    [Header("Сила торможения во время не движения")]
    public float drag = 10;

    [Header("Сила торможения во время движения")]
    public float dragOnSpeed = 10;

    public bool isGrond = false, isParkour = false;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        CameraController();
        Jump();
        PlayerController();

        if(Input.GetKeyDown(KeyCode.Q))
        {
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 1;
        }
    }

    public void CameraController()
    {
        quaternionPlayer = Quaternion.Euler(0, quaternionPlayer.eulerAngles.y + Input.GetAxis("Mouse X"), 0);
        quaternionMainCamera = Quaternion.Euler(quaternionMainCamera.eulerAngles.x + Input.GetAxis("Mouse Y") * -1, quaternionPlayer.eulerAngles.y + Input.GetAxis("Mouse X"), 0);

        transform.rotation = quaternionPlayer;
        maincamera.rotation = quaternionMainCamera;
    }

    public void Jump()
    {
      if (Input.GetKey(KeyCode.Space))
      {
            if (isGrond || isParkour)
            {
                rigidbody.drag = 0;
                isGrond = false;
                isParkour = false;
                rigidbody.AddForce(new Vector3(0, speedJump, 0));
            }
      }
    }

   public void PlayerController()
    {
        if (isGrond || isParkour)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                rigidbody.drag = dragOnSpeed;
            }
            else
            {
                rigidbody.drag = drag;
            }
            if (Input.GetKey(KeyCode.W))
            {
                rigidbody.AddForce(transform.forward * speedUP * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.S))
            {
                rigidbody.AddForce(transform.forward * -speedUP * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.A))
            {
                rigidbody.AddForce(transform.right * -speedUP * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D))
            {
                rigidbody.AddForce(transform.right * speedUP * Time.deltaTime);
            }
        }
        else
        {

                rigidbody.drag = 0;

            if (Input.GetKey(KeyCode.W))
            {
                rigidbody.AddForce(transform.forward * speedUPAir * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.S))
            {
                rigidbody.AddForce(transform.forward * -speedUPAir * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.A))
            {
                rigidbody.AddForce(transform.right * -speedUPAir * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D))
            {
                rigidbody.AddForce(transform.right * speedUPAir * Time.deltaTime);
            }
        }

        //if (rigidbody.velocity.x > speed || rigidbody.velocity.x < -speed)
        //{

        //    if (rigidbody.velocity.z > speed || rigidbody.velocity.z < -speed)
        //    {
        //        if (rigidbody.velocity.z > 0)
        //        {
        //            if (rigidbody.velocity.x > 0)
        //            {
        //                Vector3 vector3 = new Vector3(speed / 2, rigidbody.velocity.y, speed / 2);
        //                rigidbody.velocity = vector3;
        //            }
        //            else
        //            {
        //                Vector3 vector3 = new Vector3(-speed / 2, rigidbody.velocity.y, speed / 2);
        //                rigidbody.velocity = vector3;
        //            }
        //        }
        //        else
        //        {
        //            if (rigidbody.velocity.x > 0)
        //            {
        //                Vector3 vector3 = new Vector3(speed / 2, rigidbody.velocity.y, -speed / 2);
        //                rigidbody.velocity = vector3;
        //            }
        //            else
        //            {
        //                Vector3 vector3 = new Vector3(-speed / 2, rigidbody.velocity.y, -speed / 2);
        //                rigidbody.velocity = vector3;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (rigidbody.velocity.x > 0)
        //        {
        //            Vector3 vector3 = new Vector3(speed, rigidbody.velocity.y, rigidbody.velocity.z);
        //            rigidbody.velocity = vector3;
        //        }
        //        else
        //        {
        //            Vector3 vector3 = new Vector3(-speed, rigidbody.velocity.y, rigidbody.velocity.z);
        //            rigidbody.velocity = vector3;
        //        }
        //    }
        //}
        //if (rigidbody.velocity.z > speed || rigidbody.velocity.z < -speed)
        //{
        //    if (rigidbody.velocity.x > speed || rigidbody.velocity.x < -speed)
        //    {
        //        if (rigidbody.velocity.x > 0)
        //        {
        //            Vector3 vector3 = new Vector3(speed, rigidbody.velocity.y, rigidbody.velocity.z);
        //            rigidbody.velocity = vector3;
        //        }
        //        else
        //        {
        //            Vector3 vector3 = new Vector3(-speed, rigidbody.velocity.y, rigidbody.velocity.z);
        //            rigidbody.velocity = vector3;
        //        }
        //    }
                
        //    if (rigidbody.velocity.z > 0)
        //    {
        //        Vector3 vector3 = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, speed);
        //        rigidbody.velocity = vector3;
        //    }
        //    else
        //    {
        //        Vector3 vector3 = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, -speed);
        //        rigidbody.velocity = vector3;
        //    }
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.other.tag == "Ground")
        {
            isGrond = true;
        }
        if (collision.other.tag == "Parkour")
        {
            isParkour = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.other.tag == "Ground")
        {
            isGrond = false;
        }
        if (collision.other.tag == "Parkour")
        {
            isParkour = false;
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Ground")
    //    {
    //        isGrond = false;
    //    }
    //    if (other.tag == "Parkour")
    //    {
    //        isParkour = false;
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            isGrond = true;
        }
        if (other.tag == "Parkour")
        {
            isParkour = true;
        }
    }
}

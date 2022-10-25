using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoystickControl : MonoBehaviour
{
    public FloatingJoystick FloatingJoystick;
    public float Speed;
    public float TurnSpeed;
    public Animator PlayerAnimator;
    GameObject Background;
    Rigidbody rb;
    private void Awake()
    {
        Background = GameObject.Find("Background");
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            JoystickMovement();
            if (Background.activeInHierarchy)
            {
                PlayerAnimator.SetBool("Run", true);
            }
        }
        else
        {
            PlayerAnimator.SetBool("Run", false);
        }
    }
    public void JoystickMovement()
    {
        float horizontal = FloatingJoystick.Horizontal;
        float vertical = FloatingJoystick.Vertical;
        Vector3 addedPos = new Vector3(horizontal * Speed * Time.deltaTime, 0, vertical * Speed * Time.deltaTime);
        transform.position += addedPos;
        Vector3 direction = Vector3.forward * vertical + Vector3.right * horizontal;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), TurnSpeed * Time.deltaTime);
    }
}

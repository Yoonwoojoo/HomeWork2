using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private PlayerController playerController;
    private Rigidbody _rb;
    public float jumpPower;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        _rb = playerController.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        playerController.OnJumpEvent += Jump;
    }

    public void Jump()
    {
        _rb.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
    }

    public bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 2f, playerController.groundLayerMask))
            {
                return true;
            }
        }

        return false;
    }
}

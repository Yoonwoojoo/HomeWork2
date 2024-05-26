using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private GameController gameController;
    private Rigidbody _rb;
    public float jumpPower;

    private void Awake()
    {
        gameController = GetComponent<GameController>();
        _rb = gameController.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        gameController.OnJumpEvent += Jump;
    }

    private void Jump()
    {
        _rb.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
    }
}

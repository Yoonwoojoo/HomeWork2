using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerController playerController;
    private Rigidbody _rb;
    private Vector2 moveDirection = Vector2.zero;
    private Vector3 beforeDirection;
    public float moveSpeed ;
    private bool isJumping = false; // 점프 상태를 추적

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        _rb = playerController.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        playerController.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        if (!isJumping)
        {
            ApplyMove(moveDirection);
        }
    }

    private void Move(Vector2 direction)
    {
        moveDirection = direction;
    }
    private void ApplyMove(Vector3 direction)
    {
        direction = transform.forward * playerController.moveInput.y + transform.right * playerController.moveInput.x;
        direction *= moveSpeed;
        direction.y = _rb.velocity.y;

        if (direction != Vector3.zero)
        {
            _rb.velocity = direction;
            beforeDirection = direction;
        }

        else
        {
            if (direction != beforeDirection)
            {
                _rb.velocity = direction;
                beforeDirection = direction;
            }
        }
    }

    public void SetJumping(bool jumping)
    {
        isJumping = jumping;
    }

}
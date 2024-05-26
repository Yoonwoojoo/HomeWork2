using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameController gameController;
    private Rigidbody _rb;
    private Vector2 moveDirection = Vector2.zero;
    public float moveSpeed ;

    private void Awake()
    {
        gameController = GetComponent<GameController>();
        _rb = gameController.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        gameController.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMove(moveDirection);
    }

    private void Move(Vector2 direction)
    {
        moveDirection = direction;
    }
    private void ApplyMove(Vector3 direction)
    {
        direction = transform.forward * gameController.moveInput.y + transform.right * gameController.moveInput.x;
        direction *= moveSpeed;
        direction.y = _rb.velocity.y;

        _rb.velocity = direction;
    }

}
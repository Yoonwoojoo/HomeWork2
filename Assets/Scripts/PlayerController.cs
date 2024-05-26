using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [Header("MoveMent")]
    public float moveSpeed;
    public float jumpPower;
    private Vector2 currentMovementInput;
    private Rigidbody _rb;
    public LayerMask groundLayerMask;

    [Header("Look")]
    public Transform cameraContainer;
    public float minXLook;
    public float maxXLook;
    private float camCurrentXRot;
    public float lookSensitivity;
    private Vector2 mouseDelta;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        CameraLook();
    }

    private void Move()
    {
        Vector3 dir = (transform.forward * currentMovementInput.y) + (transform.right * currentMovementInput.x);
        dir *= moveSpeed;
        dir.y = _rb.velocity.y;

        _rb.velocity = dir;
    }
    public void OnMove(InputAction.CallbackContext context)      // SendMessage 방식이 아닌 Invoke Unity Events 이므로 InputAction을 사용
    {
        if(context.phase == InputActionPhase.Performed)
        {
            currentMovementInput = context.ReadValue<Vector2>();
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            currentMovementInput = Vector2.zero;
        }
    }

    private void CameraLook()
    {
        camCurrentXRot += mouseDelta.y * lookSensitivity; // 마우스의 y축을 고정시켜야함
        camCurrentXRot = Mathf.Clamp(camCurrentXRot, minXLook, maxXLook); // 제한하려는 대상, 최솟값 ,최댓값
        cameraContainer.localEulerAngles = new Vector3(-camCurrentXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }


    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started && IsGrounded())
        {
            _rb.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
        }
    }

    bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 2f, groundLayerMask))
            { 
                return true; 
            }
        }
        return false;
    }
}

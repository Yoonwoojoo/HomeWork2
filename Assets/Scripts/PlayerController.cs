using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
        Cursor.lockState = CursorLockMode.Locked;
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

    private void CameraLook()
    {
        camCurrentXRot += mouseDelta.y * lookSensitivity; // ���콺�� y���� �������Ѿ���
        camCurrentXRot = Mathf.Clamp(camCurrentXRot, minXLook, maxXLook); // �����Ϸ��� ���, �ּڰ� ,�ִ�
        cameraContainer.localEulerAngles = new Vector3(-camCurrentXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }

    public void OnMove(InputAction.CallbackContext context)      // SendMessage ����� �ƴ� Invoke Unity Events �̹Ƿ� InputAction�� ���
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

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimRotation : MonoBehaviour
{
    private GameController gameController;
    private Vector2 aimDirection = Vector2.right;
    public Transform cameraContainer;
    public float minXLook;
    public float maxXLook;
    private float camCurrentXRot;
    public float lookSensitivity;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gameController = GetComponent<GameController>();
    }

    private void Start()
    {
        gameController.OnLookEvent += aim;
    }

    private void LateUpdate()
    {
        CameraLook();
    }

    private void aim(Vector2 direction)
    {
        aimDirection = direction;
    }
    private void CameraLook()
    {
        camCurrentXRot += gameController.mouseDelta.y * lookSensitivity;
        camCurrentXRot = Mathf.Clamp(camCurrentXRot, minXLook, maxXLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurrentXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, gameController.mouseDelta.x * lookSensitivity, 0);
    }
}

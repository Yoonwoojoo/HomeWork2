using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 moveInput;
    public Vector2 mouseDelta;
    public LayerMask groundLayerMask;

    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnJumpEvent;
    public Action addItem;

    private PlayerJump playerJump;
    private PlayerInteraction playerInteraction;

    private void Awake()
    {
        playerInteraction = GetComponent<PlayerInteraction>();
        playerJump = GetComponent<PlayerJump>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            moveInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            moveInput = Vector2.zero;
        }
    }

    public void Look(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && playerJump.IsGrounded())
        {
            OnJumpEvent?.Invoke();
        }
    }

    public void Interaction(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && playerInteraction.iinteractable != null)
        {
            playerInteraction.iinteractable.OnInteract();
            playerInteraction.curInteractGameObject = null;
            playerInteraction.iinteractable = null;
        }
    }
}

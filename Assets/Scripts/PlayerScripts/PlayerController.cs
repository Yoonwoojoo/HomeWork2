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
    public Action OnInventory;
    public Action OnAddItem;

    public bool canLook = true; // 인벤토리 커서 전용

    private PlayerJump playerJump;
    private PlayerCondition playerCondition;
    private PlayerInteraction playerInteraction;
    private PlayerEquipment playerEquipment;

    private void Awake()
    {
        playerJump = GetComponent<PlayerJump>();
        playerCondition = GetComponent<PlayerCondition>();
        playerInteraction = GetComponent<PlayerInteraction>();
        playerEquipment = GetComponent<PlayerEquipment>();
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
        if (context.phase == InputActionPhase.Started && playerJump.IsGrounded() && !playerCondition.IsStaminaDepleted())
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

    public void Inventory(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            OnInventory?.Invoke();
            ToggleCursor();
        }
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed && playerEquipment.curEquip != null && canLook)
        {
            playerEquipment.curEquip.OnAttackInput();
        }
    }

    void ToggleCursor()
    {
        bool toggle = Cursor.lockState == CursorLockMode.Locked;
        Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
        canLook = !toggle;
    }
}

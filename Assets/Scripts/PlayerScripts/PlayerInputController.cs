using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : GameController 
{
    public void Move(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            moveInput = context.ReadValue<Vector2>();
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            moveInput = Vector2.zero;
        }

        CallMoveEvent(moveInput);
    }

    public void Look(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();

        CallLookEvent(mouseDelta);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started && IsGrounded())
        {
            CallJumpEvent();
        }
    }

    private bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
        };

        for(int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 2f, groundLayerMask))
            {
                return true;
            }
        }

        return false;
    }
}

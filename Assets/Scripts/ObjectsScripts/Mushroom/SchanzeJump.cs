using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchanzeJump : MonoBehaviour
{
    public float yPower; // ���� ���� ��
    public float directionPower; // ������ ������ ��
    public float jumpDuration; // ���� ���� ���� �ð�

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (other.TryGetComponent<Rigidbody>(out Rigidbody targetRb))
            {
                if (other.TryGetComponent<PlayerMovement>(out PlayerMovement playerMovement))
                {
                    // �÷��̾��� transform.position�� ����Ͽ� ���� ���
                    Vector3 directionToPlayer = (other.transform.position - transform.position).normalized;

                    // �������� ���� �� ���� ���
                    Vector3 jumpForce = -directionToPlayer * directionPower + Vector3.up * yPower;
                    targetRb.AddForce(jumpForce, ForceMode.VelocityChange);

                    // ���� ���� ����
                    playerMovement.SetJumping(true);
                    StartCoroutine(ResetJumpState(playerMovement));
                }
            }
        }
    }

    private IEnumerator ResetJumpState(PlayerMovement playerMovement)
    {
        yield return new WaitForSeconds(jumpDuration);
        playerMovement.SetJumping(false);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchanzeJump : MonoBehaviour
{
    public float yPower; 
    public float xPower; 
    public float jumpDuration; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (other.TryGetComponent<Rigidbody>(out Rigidbody targetRb))
            {
                if (other.TryGetComponent<PlayerMovement>(out PlayerMovement playerMovement))
                {
                    // 플레이어의 transform.position을 사용하여 방향 계산
                    Vector3 directionToPlayer = (other.transform.position - transform.position).normalized;

                    // 포물선을 위한 힘 벡터 계산
                    Vector3 jumpForce = -directionToPlayer * xPower + Vector3.up * yPower;
                    targetRb.AddForce(jumpForce, ForceMode.VelocityChange);

                    // 점프 상태 설정
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

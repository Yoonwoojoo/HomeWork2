using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchanzeJump : MonoBehaviour
{
    public float jumpPower;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if(other.TryGetComponent<Rigidbody>(out Rigidbody targetRb))
            {
                Vector3 jumpForce = new Vector3(0, jumpPower, 0);
                targetRb.AddForce(jumpForce, ForceMode.Impulse);
            }
        }
    }
}

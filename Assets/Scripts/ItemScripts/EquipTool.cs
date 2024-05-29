using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipTool : Equip
{
    public float attackCooltime;
    private bool isAttacking;
    public float attackDistance;

    [Header("Resource Gathering")]
    public bool doesGatherResources;

    [Header("Combat")]
    public bool doesDealDamage;
    public int damage;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void OnAttackInput()
    {
        if(!isAttacking)
        {
            isAttacking = true;
            animator.SetTrigger("Attack");
            Invoke("OnCanAttack", attackCooltime);
        }
    }

    void OnCanAttack()
    {
        isAttacking = false;
    }
}

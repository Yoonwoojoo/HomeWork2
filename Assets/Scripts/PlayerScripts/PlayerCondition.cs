using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{ 
    void PhysicalDamaged(int damage);
}
public class PlayerCondition : MonoBehaviour, IDamagable
{
    public ConditionController conditionController;

    private Condition hpCondition { get { return conditionController.hp; } }
    private Condition hungerCondition { get { return conditionController.hunger; } }
    private Condition staminaCondition { get { return conditionController.stamina; } }

    public float naturalDamage;

    public event Action onDamaged;

    private void Update()
    {
        hungerCondition.Decrease(hungerCondition.passiveValue * Time.deltaTime);
        staminaCondition.Decrease(staminaCondition.passiveValue * Time.deltaTime);

        if (hungerCondition.curValue <= 0f)
        {
            hpCondition.Decrease(naturalDamage * Time.deltaTime);
        }

        if(hpCondition.curValue <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Time.timeScale = 0f;
    }

    public void PhysicalDamaged(int damage)
    {
        hpCondition.Decrease(damage);
        onDamaged?.Invoke();
    }
    
}

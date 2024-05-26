using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public ConditionController conditionController;

    private Condition hpCondition { get { return conditionController.hp; } }
    private Condition hungerCondition { get { return conditionController.hunger; } }
    private Condition staminaCondition { get { return conditionController.stamina; } }

    public float naturalDamage;

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
}

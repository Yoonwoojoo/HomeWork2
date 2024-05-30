using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCondition : MonoBehaviour, IDamagable
{
    public ConditionController conditionController;

    private Condition hpCondition { get { return conditionController.hp; } }
    private Condition hungerCondition { get { return conditionController.hunger; } }
    private Condition staminaCondition { get { return conditionController.stamina; } }

    public float naturalDamage;

    public event Action onDamaged;

    private Rigidbody _rb;

    public GameObject deadUI;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        if (deadUI != null)
        {
            deadUI.SetActive(false);
        }
    }

    private void Start()
    {
        CharacterManager.Instance.Player.playerController.OnJumpEvent += DecreaseStamina;
    }

    private void Update()
    {
        hungerCondition.Decrease(hungerCondition.passiveValue * Time.deltaTime);
        staminaCondition.Increase(staminaCondition.passiveValue * Time.deltaTime);

        if (hungerCondition.curValue <= 0f)
        {
            hpCondition.Decrease(naturalDamage * Time.deltaTime);
        }

        if(hpCondition.curValue <= 0f)
        {
            Die();
        }
    }

    private void DecreaseStamina()
    {
        staminaCondition.Decrease(10f);
    }

    public bool IsStaminaDepleted()
    {
        return staminaCondition.curValue < 10f;
    }

    public void Heal(float size)
    {
        hpCondition.Increase(size);
    }

    public void Eat(float size)
    {
        hungerCondition.Increase(size);
    }

    private void Die()
    {
        
        deadUI.SetActive(true);
        StartCoroutine(DelayTimeScaleStop());
    }

    private IEnumerator DelayTimeScaleStop()
    {
        float duration = 1f;
        float elapsedTime = 0f;
        Quaternion initialRotation = transform.rotation;
        Quaternion targetRotation = initialRotation * Quaternion.Euler(0, 0, 90);

        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, elapsedTime / duration); // Quaternion.Slerp는 두 쿼터니언 사이의 구면 선형 보간을 수행, 두 회전 사이를 부드럽게 이동하는 데 사용
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation;
        Time.timeScale = 0f;
    }

    public void PhysicalDamaged(int damage)
    {
        hpCondition.Decrease(damage);
        onDamaged?.Invoke();
    }
    
}

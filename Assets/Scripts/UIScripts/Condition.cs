using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    public float curValue;    // ���簪
    public float startValue;   // ���۰�
    public float maxValue;     // �ִ�
    public float passiveValue; // ��ȭ�� 
    public Image uiBar;

    private void Start()
    {
        curValue = startValue;
    }

    private void Update()
    {
        uiBar.fillAmount = GetPercentage();
    }

    private float GetPercentage()
    {
        return curValue / maxValue;
    }

    public void Increase(float value)
    {
        curValue = Mathf.Min(curValue + value, maxValue); // ���簪 = ���߿� ������
    }

    public void Decrease(float value)
    {
        curValue = Mathf.Max(curValue - value, 0); // ���簪 = ���߿� ū��
    }
}

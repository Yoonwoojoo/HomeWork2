using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    public float curValue;    // 현재값
    public float startValue;   // 시작값
    public float maxValue;     // 최댓값
    public float passiveValue; // 변화값 
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
        curValue = Mathf.Min(curValue + value, maxValue); // 현재값 = 둘중에 작은거
    }

    public void Decrease(float value)
    {
        curValue = Mathf.Max(curValue - value, 0); // 현재값 = 둘중에 큰거
    }
}

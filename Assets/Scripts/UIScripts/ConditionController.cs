using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionController : MonoBehaviour
{
    public PlayerCondition playerCondition;
    public Condition hp;
    public Condition hunger;
    public Condition stamina;

    private void Awake()
    {
        playerCondition.conditionController = this;
    }
}

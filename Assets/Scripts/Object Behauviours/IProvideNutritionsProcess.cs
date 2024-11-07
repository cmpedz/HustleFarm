using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProvideNutritionsProcess 
{
    public float GetMaxHourForNextProviding();

    public DateTime GetLastTimeProvidingNutrition();

    public void SetLastTimeProvidingNutrition(DateTime time);
}

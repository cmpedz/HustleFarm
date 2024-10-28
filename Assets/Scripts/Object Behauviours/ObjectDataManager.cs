using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDataManager : MonoBehaviour, IProvideNutritionsProcess
{
    // Start is called before the first frame update

    public static readonly DateTime DEFAULT_LAST_TIME_PROVIDING_NUTRITIONS = new DateTime(2000, 1, 1);

    private float maxHourForNextProvidingNutritions;

    private DateTime lastTimeProvidedNutritions = DEFAULT_LAST_TIME_PROVIDING_NUTRITIONS;


    public DateTime GetLastTimeProvidingNutrition()
    {
        return this.lastTimeProvidedNutritions;
    }

    public float GetMaxHourForNextProviding()
    {
        return this.maxHourForNextProvidingNutritions;
    }
}

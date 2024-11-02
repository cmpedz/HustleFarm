using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlantsDataManager : ObjectDataManager, IDeathProcess
{
    private DateTime timeBorn;

    public DateTime TimeBorn;

    [SerializeField] private float LifeSpans;

    [SerializeField] private float MaxHoursCanSurviveInBadStatus;

    public float GetLifeSpan()
    {
        return LifeSpans;
    }

    public float GetMaxHoursCanSurviveInBadStatus()
    {
        return MaxHoursCanSurviveInBadStatus;
    }

    public DateTime GetTimeBorn()
    {
        return timeBorn;    
    }
}

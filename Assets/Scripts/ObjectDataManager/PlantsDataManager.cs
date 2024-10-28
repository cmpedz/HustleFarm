using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantsDataManager : ObjectDataManager, IDeathProcess
{
    private DateTime timeBorn;

    [SerializeField] private float lifeSpans;

    [SerializeField] private float maxHoursCanSurviveInBadStatus;

    public float GetLifeSpan()
    {
        return lifeSpans;
    }

    public float GetMaxHoursCanSurviveInBadStatus()
    {
        return maxHoursCanSurviveInBadStatus;
    }

    public DateTime GetTimeBorn()
    {
        return timeBorn;    
    }
}

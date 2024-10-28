using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDeathProcess
{
    public float GetLifeSpan();

    public float GetMaxHoursCanSurviveInBadStatus();

    public DateTime GetTimeBorn();
}

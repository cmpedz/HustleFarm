using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlantsDataManager : ObjectDataManager
{
    public DateTime TimeBorn;

    public float LifeSpans;

    public float MaxHoursCanSurviveInBadStatus;


    public void CheckPlantData() {
        Debug.Log("check " + Id +  " data : ");
        Debug.Log("check plant type : " + Type);
        Debug.Log("check plant life span : " + LifeSpans);
        Debug.Log("check Max Hours Can Survive In Bad Status : " + MaxHoursCanSurviveInBadStatus);
        Debug.Log("check point each day : " + PointEachDay);

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializedPlantData
{
    public string Id;
    public string LifeSpan;
    public float PointEachDay;
    public string Type;
    public float MaxHoursCanSurviveInBadStatus;
    public float MaxHourForNextProvidingNutritions;
    public string LastTimeProvidingNutrition;

    public void CheckSerializedPlantData() {
        Debug.Log("check " + Id + " data : ");
        Debug.Log("Life span : " + LifeSpan);
        Debug.Log("Point each day : " + PointEachDay);
        Debug.Log("Type : " + Type);
        Debug.Log("MaxHoursCanSurviveInBadStatus : " + MaxHoursCanSurviveInBadStatus);
        Debug.Log("MaxHourForNextProvidingNutritions : " + MaxHoursCanSurviveInBadStatus);
        Debug.Log("LastTimeProvidingNutrition : " + LastTimeProvidingNutrition);

    }
}

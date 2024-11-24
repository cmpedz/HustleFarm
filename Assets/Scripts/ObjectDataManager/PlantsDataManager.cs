using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantsDataManager : ObjectDataManager, IDeathProcess
{
    private DateTime timeBorn = DateTime.Now;

    private float lifeSpans;

    private float maxHoursCanSurviveInBadStatus;

    private int dirtIndex;
    public int DirtIndex
    {
        get { return dirtIndex; }
        set { dirtIndex = value; }
    }
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

    public void SetTimeBorn(DateTime timeBorn)
    {
        this.timeBorn = timeBorn;
    }

    public void SerializedPLantDataToPlantDataManager(SerializedPlantData serializedPlantData)
    {


        this.maxHoursCanSurviveInBadStatus = serializedPlantData.MaxHoursCanSurviveInBadStatus;

        this.maxHourForNextProvidingNutritions = serializedPlantData.MaxHourForNextProvidingNutritions;

        this.Type = serializedPlantData.Type;

        this.PointEachDay = serializedPlantData.PointEachDay;   

        this.lifeSpans = ConvertIntoHourUnitSystem.ConvertStringIntoHourUnit(serializedPlantData.LifeSpan);

        this.dirtIndex = serializedPlantData.DirtOrder;

        if (serializedPlantData.LastTimeProvidingNutrition != null) {
            this.SetLastTimeProvidingNutrition(DateTime.Parse(serializedPlantData.LastTimeProvidingNutrition));
        }
        else
        {
            this.SetLastTimeProvidingNutrition(DEFAULT_LAST_TIME_PROVIDING_NUTRITIONS);
        }

        
        if (serializedPlantData.TimeBorn != null && serializedPlantData.TimeBorn != "") { 
            timeBorn = DateTime.Parse(serializedPlantData.TimeBorn);
        }
        else
        {
            timeBorn = DateTime.Now;
        }

        this.IsTakenCare = serializedPlantData.IsTakenCare;

    }
}





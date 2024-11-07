using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantsDataManager : ObjectDataManager, IDeathProcess
{
    private DateTime timeBorn;

    private float lifeSpans;

    private float maxHoursCanSurviveInBadStatus;

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

    public void RetrievePlantDataFromGachaStorageSystem(SerializedPlantData serializedPlantData)
    {


        this.maxHoursCanSurviveInBadStatus = serializedPlantData.MaxHoursCanSurviveInBadStatus;

        this.maxHourForNextProvidingNutritions = serializedPlantData.MaxHourForNextProvidingNutritions;

        this.Type = serializedPlantData.Type;

        this.PointEachDay = serializedPlantData.PointEachDay;   

        this.lifeSpans = ConvertIntoHourUnitSystem.ConvertStringIntoHourUnit(serializedPlantData.LifeSpan);

        

    }
}





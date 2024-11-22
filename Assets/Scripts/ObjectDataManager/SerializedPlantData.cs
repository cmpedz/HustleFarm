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
    public string TimeBorn;
    public bool IsTakenCare;


    public void PlantDataManagerToSerializedPlantData(PlantsDataManager plantsDataManager)
    {
        this.Id = plantsDataManager.Id;
        this.LifeSpan = ConvertIntoHourUnitSystem.ConvertTimeIntoString(plantsDataManager.GetLifeSpan(), ConvertIntoHourUnitSystem.HOUR);
        this.PointEachDay = plantsDataManager.PointEachDay;
        this.Type = plantsDataManager.Type;
        this.MaxHourForNextProvidingNutritions = plantsDataManager.GetMaxHourForNextProviding();
        this.MaxHoursCanSurviveInBadStatus = plantsDataManager.GetMaxHoursCanSurviveInBadStatus();
        this.LastTimeProvidingNutrition = plantsDataManager.GetLastTimeProvidingNutrition().ToString();
        this.IsTakenCare = plantsDataManager.IsTakenCare;
    }
}

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


    public void CheckSerializedPlantData() {
        Debug.Log("check " + Id + " data : ");
        Debug.Log("Life span : " + LifeSpan);
        Debug.Log("Point each day : " + PointEachDay);
        Debug.Log("Type : " + Type);
        Debug.Log("MaxHoursCanSurviveInBadStatus : " + MaxHoursCanSurviveInBadStatus);
        Debug.Log("MaxHourForNextProvidingNutritions : " + MaxHoursCanSurviveInBadStatus);
        Debug.Log("LastTimeProvidingNutrition : " + LastTimeProvidingNutrition);

    }

    public void PlantDataManagerToSerializedPlantData(PlantsDataManager plantsDataManager)
    {
        this.Id = plantsDataManager.Id;
        this.LifeSpan = ConvertIntoHourUnitSystem.ConvertTimeIntoString(plantsDataManager.GetLifeSpan(), ConvertIntoHourUnitSystem.HOUR);
        this.PointEachDay = plantsDataManager.PointEachDay;
        this.Type = plantsDataManager.Type;
        this.MaxHourForNextProvidingNutritions = plantsDataManager.GetMaxHourForNextProviding();
        this.MaxHoursCanSurviveInBadStatus = plantsDataManager.GetMaxHoursCanSurviveInBadStatus();
        this.LastTimeProvidingNutrition = plantsDataManager.GetLastTimeProvidingNutrition().ToString();
    }
}

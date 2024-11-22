using System.Diagnostics;

namespace HustleFarmServer.Controllers.Model.UserDataForm
{
    [System.Serializable]
    public class PlantData
    {
        public string? Id;
        public string? LifeSpan;
        public float PointEachDay;
        public string? Type;
        public float MaxHoursCanSurviveInBadStatus;
        public float MaxHourForNextProvidingNutritions;
        public string? LastTimeProvidingNutrition;
        public string? TimeBorn = null;
        public bool IsTakenCare;
       
    }

}

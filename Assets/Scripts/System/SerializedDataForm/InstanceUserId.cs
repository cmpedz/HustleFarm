using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceUserId : Singleton<InstanceUserId>
{
    private string userId;
    public string UserId
    {
        get { return this.userId; }
        set { this.userId = value; }
    }

    private void Start()
    {
        string data = "{\"Id\":\"Crop\",\"LifeSpan\":\"5 days\",\"PointEachDay\":2.0,\"Type\":\"Common\",\"MaxHoursCanSurviveInBadStatus\":20.0,\"MaxHourForNextProvidingNutritions\":1.0,\"LastTimeProvidingNutrition\":null,\"TimeBorn\":\"11/21/2024 5:13:08 PM\"}";

        SerializedPlantData plant =  JsonUtility.FromJson<SerializedPlantData>(data);

        Debug.Log("check deserialized data : " +  JsonConvert.SerializeObject(plant));   
    }
}

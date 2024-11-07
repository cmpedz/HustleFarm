using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ObjectDataManager : MonoBehaviour, IProvideNutritionsProcess
{
    // Start is called before the first frame update

    public static readonly DateTime DEFAULT_LAST_TIME_PROVIDING_NUTRITIONS = new DateTime(2000, 1, 1);

    protected float maxHourForNextProvidingNutritions;

    private DateTime LastTimeProvidedNutritions = DEFAULT_LAST_TIME_PROVIDING_NUTRITIONS;

    private float pointEachDay;
    public float PointEachDay
    {
        get { return this.pointEachDay; }
        set { this.pointEachDay = value; }
    }

    private string type;
    public string Type
    {
        get { return this.type; }
        set { this.type = value; }
    }

    [SerializeField] private string id;
    public string Id
    {
        get { return this.id; }
       
    }

    public DateTime GetLastTimeProvidingNutrition()
    {
        return this.LastTimeProvidedNutritions;
    }

    public float GetMaxHourForNextProviding()
    {
        return this.maxHourForNextProvidingNutritions;
    }

    public void SetLastTimeProvidingNutrition(DateTime time)
    {
        this.LastTimeProvidedNutritions = time;
    }

   
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ObjectDataManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static readonly DateTime DEFAULT_LAST_TIME_PROVIDING_NUTRITIONS = new DateTime(2000, 1, 1);

    public float MaxHourForNextProvidingNutritions;

    public DateTime LastTimeProvidedNutritions = DEFAULT_LAST_TIME_PROVIDING_NUTRITIONS;

    public float PointEachDay;

    public string Type;

    public string Id;
}

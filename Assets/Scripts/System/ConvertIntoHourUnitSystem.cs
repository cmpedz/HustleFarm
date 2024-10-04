using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConvertIntoHourUnitSystem
{
    public static readonly string DAY = "day";

    public static readonly string HOUR = "hour";

    public static readonly string SECOND = "second";

    public static readonly string MINUTE = "minute";

    private static readonly Dictionary<string, float> EXCHANGE_VALUES = new Dictionary<string, float>
    {
        { ConvertIntoHourUnitSystem.DAY, 24 },

        { ConvertIntoHourUnitSystem.HOUR, 1 },

        { ConvertIntoHourUnitSystem.SECOND, 1f/3600f},

        { ConvertIntoHourUnitSystem.MINUTE, 1f/60f},

    };

    public static float ConvertStringIntoHourUnit(string time) { 

           string[] timeIngredients = time.Split(" ");

           if (timeIngredients.Length != 2) return 0;

           float _time = float.Parse(timeIngredients[0]);

           string unit = timeIngredients[1];

           return _time;
    }

    public static float ConvertTimeIntoHourUnit(float time, string unit)
    {

        return time * EXCHANGE_VALUES.GetValueOrDefault(unit);
    }

}

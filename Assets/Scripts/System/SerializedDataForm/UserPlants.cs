using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class UserPlants
{
    public static readonly string Id = "UserPlants";

    public List<string> Plants;

    public UserPlants() { Plants = new List<string>(); }

}

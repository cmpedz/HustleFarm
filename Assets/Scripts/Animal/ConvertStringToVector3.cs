
using UnityEngine;

public static class ConvertStringToVector3 
{
    public static Vector3 StringToVector3(string s)
    {
        string[] vectorPos = s.Split('(', ')');

        float x = float.Parse(vectorPos[0]);
        float y = float.Parse(vectorPos[1]);
        float z = float.Parse(vectorPos[2]);

        return new Vector3(x, y, z);
    }
}

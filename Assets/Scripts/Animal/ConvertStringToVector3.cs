
using UnityEngine;

public static class ConvertStringToVector3 
{
    public static Vector3 StringToVector3(string s)
    {

        

        string[] vectorPos = s.Split('(', ')', ',');

        Debug.Log("check vector after split : " + vectorPos.Length);
        for (int i = 0; i<vectorPos.Length; i++)
        {
            Debug.Log("Pos : " + vectorPos[i]);
        }

        float x = float.Parse(vectorPos[1]);
        float y = float.Parse(vectorPos[2]);
        float z = float.Parse(vectorPos[3]);

        return new Vector3(x, y, z);
    }
}

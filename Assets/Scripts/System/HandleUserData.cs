using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class HandleUserData<T> :  HandleUserDataFunction
{
    public override void HandleData(string jsondata)
    {
        Debug.Log("check json data before deserialized : " + jsondata);
        T jsonToTObject = JsonUtility.FromJson<T>(jsondata);

        if(jsonToTObject != null)
        {
            

            HandleDataEvent(jsonToTObject);
        }
        else
        {
            Debug.Log("jsonToObject is null");
        }
    }

    public abstract void HandleDataEvent(T data);

   
}

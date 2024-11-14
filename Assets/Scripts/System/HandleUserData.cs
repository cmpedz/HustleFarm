using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class HandleUserData<T> : Singleton<HandleUserData<T>>, IHandleUserData where T : IItemData
{
    public void HandleData(string jsondata)
    {
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

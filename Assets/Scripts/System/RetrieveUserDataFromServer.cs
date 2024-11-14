using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetrieveUserDataFromServer : Singleton<RetrieveUserDataFromServer>
{
    [System.Serializable]
    public class HandleFunction
    {
        public string DataId;

        //public HandleUserData<IItemData> handleFunction = new HandleBagUserData();
    }
    [SerializeField] private List<HandleFunction> handleFucntions = new List<HandleFunction>();
     public void HandleDataRetrievedFromSever(string data)
    {
        JObject jsonToObject = JObject.Parse(data);

        foreach(var dataId in jsonToObject)
        {
            Debug.Log("check data id : " + dataId);

            Debug.Log("check data : " + dataId.Value);

        }
    }
}

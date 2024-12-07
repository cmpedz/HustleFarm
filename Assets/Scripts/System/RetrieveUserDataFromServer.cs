using Newtonsoft.Json;
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

        public HandleUserDataFunction handleFunction;
    }
    [SerializeField] private List<HandleFunction> handleFucntions = new List<HandleFunction>();

    private Dictionary<string, HandleUserDataFunction> handleFunctionsDic = new Dictionary<string, HandleUserDataFunction>();

    private void Start()
    {
        foreach (HandleFunction handleFunction in handleFucntions) {
            handleFunctionsDic.Add(handleFunction.DataId, handleFunction.handleFunction);
        }
    }
    public void HandleDataRetrievedFromSever(string data)
    {
        Debug.Log("check data receive : " + data);
        if (data == null || data == "") { return; }

        JObject jsonToObject = JObject.Parse(data);


        foreach(var dataId in jsonToObject)
        {
            Debug.Log("check data id : " + dataId.Key);

            Debug.Log("check data : " + dataId.Value);

            if(handleFunctionsDic.TryGetValue(dataId.Key, out HandleUserDataFunction handleFunc))
            {
                handleFunc.HandleData(dataId.Value.ToString());
            }

        }
    }
}

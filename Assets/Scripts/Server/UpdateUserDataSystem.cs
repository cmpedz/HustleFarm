using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UpdateUserDataSystem : ServerRequestController, IOnDataChangeEvent
{
    // Start is called before the first frame update

    private static readonly string UpdateUserDataRouter = "UserDataUpdate";


    private static UpdateUserDataSystem instance;
    public static UpdateUserDataSystem Instance { get { return instance; } }

    [SerializeField] private DataChangeScriptTableObject dataChangeScriptTableObject;

    private  void Awake()
    {
        if(instance == null)
        {
            instance = this;

            
            
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }

    

    }

    private void SubcribesToSubject()
    {

        dataChangeScriptTableObject.AddEvent(this);
    }

    private void UnSubcribesToSubject()
    {


        dataChangeScriptTableObject.RemoveEvent(this);
    }


    public void OnDataChange(object dataChange)
    {
        UpdateUserData(dataChange);
    }


    public void UpdateUserData(object data)
    {
        Debug.Log("on update user data process");

        if (data == null) return;


        Type typeOfUserData = data.GetType();

        UserData serializedUserData = new UserData();


        serializedUserData.SetDataRelyOnDataType(typeOfUserData, data);

        string userDataToJson = serializedUserData.ConvertToJson();

       

        if (userDataToJson != null)
        {
            Debug.Log("check user data to json : " + userDataToJson);

            StartCoroutine(SendPostRequest(UpdateUserDataRouter, userDataToJson));
        }

    }



    protected override void HandleDataRetrievedFromServer(UnityWebRequest request)
    {
        
    }

    private void OnEnable()
    {
        SubcribesToSubject();
    }


    private void OnDisable()
    {
        UnSubcribesToSubject();
    }

    private void OnDestroy()
    {
        UnSubcribesToSubject();
    }


}

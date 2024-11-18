using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UpdateUserDataSystem : ServerRequestController
{
    // Start is called before the first frame update
    private Dictionary<string, object> userData;

    private static UpdateUserDataSystem instance;
    public static UpdateUserDataSystem Instance {  get { return instance; } }   
   

    public void UpdateUserData(object data, string id)
    {
        if (userData == null) return;

         userData[id] = data;

    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            userData = new Dictionary<string, object>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }   
    }

    protected override void HandleDataRetrievedFromServer(UnityWebRequest request)
    {
        
    }

    private void OnDestroy()
    {

        string userDataToJson = JsonConvert.SerializeObject(userData);

        Debug.Log("check update user data : " + userDataToJson);
    }
}

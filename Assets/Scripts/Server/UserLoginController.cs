using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class UserLoginController : ServerRequestController
{
    private static readonly string USER_LOGIN_ROUTER = "UserLogin";

    private static UserLoginController instance;
    public static UserLoginController Instance
    {
        get { return instance; }
    }

    private void Start()
    {
        if (instance == null) {
            instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }

    protected override void HandleDataRetrievedFromServer(UnityWebRequest request)
    {
        Debug.Log("response from server after constructing user : " + request.downloadHandler.text);
    }


    public void ConstructUserAccount(string userId)
    {
        string userIdToJson = "{userId : " + userId + "}";
        StartCoroutine(SendPostRequest(USER_LOGIN_ROUTER ,userIdToJson));
    }
}

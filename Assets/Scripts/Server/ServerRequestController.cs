using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public abstract class ServerRequestController : MonoBehaviour
{
    private static readonly string SERVER_URL = "https://localhost:7218";


    public  IEnumerator ExecuteGetRequestToServer(string router) { 

            string url = SERVER_URL + "/" + router;

            UnityWebRequest request = UnityWebRequest.Get(url);

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("error from server : " + request.error);
             }
            else
            {
                HandleDataRetrievedFromServer(request);
            }
    }

    public  abstract void HandleDataRetrievedFromServer(UnityWebRequest request);


}

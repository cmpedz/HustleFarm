using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public abstract class ServerRequestController : MonoBehaviour
{
    private static readonly string SERVER_URL = "https://localhost:7218";


    protected  IEnumerator SendGetRequest(string router) { 

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

    protected IEnumerator SendPostRequest(string router, string jsonData)
    {

        string url = SERVER_URL + "/" + router;

        UnityWebRequest request = new UnityWebRequest(url, "POST");
        

        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
       
        
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);

        request.downloadHandler = new DownloadHandlerBuffer();

        request.SetRequestHeader("Content-Type", "application/json");

    
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error when connecting : " + request.error);

        }
        else
        {
            HandleDataRetrievedFromServer(request);
        }

  
        
        
    }

    protected  abstract void HandleDataRetrievedFromServer(UnityWebRequest request);


}

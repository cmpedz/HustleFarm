using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class GachaSystemController : MonoBehaviour
{
    // Start is called before the first frame update
    private static readonly string SERVER_PROVIDING_GACHA_ITEM_URL = "https://localhost:7218/GachaServer";

    [SerializeField] private TextMeshProUGUI result;
    void Start()
    {
        
    }

    public void GetRateFromServer(int time) {

        this.result.text = "";

        for (int i = 0; i < time; i++) {
            StartCoroutine(GetRateFromServerCoroutine());
        }
   
    }

    private IEnumerator GetRateFromServerCoroutine() {

        UnityWebRequest getRequest = UnityWebRequest.Get(SERVER_PROVIDING_GACHA_ITEM_URL);

        yield return getRequest.SendWebRequest();

        if (getRequest.result == UnityWebRequest.Result.ConnectionError || getRequest.result == UnityWebRequest.Result.ProtocolError) {
            result.text += "error : " + getRequest.error + "\n";
        }
        else
        {
            result.text += getRequest.downloadHandler.text + "\n";
        }
    }

    
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameNotificationController : Singleton<GameNotificationController>   
{
    [SerializeField] private TextMeshProUGUI messageSend;

    [SerializeField] private GameObject messageAnnocement;

    [SerializeField] private Button turnOffNotificationButton;

   
    public void NotifyMessage(string message, bool isTurnOffErrorButtonDisplay)
    {
        messageSend.text = message;

        messageAnnocement.SetActive(true);

        if (turnOffNotificationButton != null)
        {
            turnOffNotificationButton.gameObject.SetActive(isTurnOffErrorButtonDisplay);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

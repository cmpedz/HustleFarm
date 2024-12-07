using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ErrorNotificationController : Singleton<ErrorNotificationController>   
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI errorSend;

    [SerializeField] private GameObject errorAnnocement;

    [SerializeField] private Button turnOffErrorButton;

   
    public void NotifyError(string error, bool isTurnOffErrorButtonDisplay)
    {
        errorSend.text = error;

        errorAnnocement.SetActive(true);

        if (isTurnOffErrorButtonDisplay && turnOffErrorButton != null)
        {
            turnOffErrorButton.gameObject.SetActive(isTurnOffErrorButtonDisplay);
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

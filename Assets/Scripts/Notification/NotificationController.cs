using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotificationController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI messageDisplay;

    private static NotificationController instance;
    public static NotificationController Instance
    {
        get { return instance; }
    }

    private NotificationController() { }

    void Start()
    {
        if(instance == null)
        {
            instance = this;

            DontDestroyOnLoad(instance);
        }
        else
        {
            if (instance != this) {
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NotifyMessage(string message) {
        if (messageDisplay != null) { 
            messageDisplay.text = message;
        }

        gameObject.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UserInputNameController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI userName;

    [SerializeField] private Button confirmButton;

    private UnityEvent changeSceneEvent;


    private void OnConfirmEventHandle()
    {
        InstanceUserGeneralInfors.Instance.UserName = userName.text;

        changeSceneEvent.Invoke();
        
    }

    void Start()
    {
        if(confirmButton != null)
        {
            confirmButton.onClick.RemoveAllListeners();
            confirmButton.onClick.AddListener(OnConfirmEventHandle);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

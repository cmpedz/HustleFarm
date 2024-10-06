using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectInforsController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Image objectSprite;

    [SerializeField] private TextMeshProUGUI lifeSpan;

    [SerializeField] private TextMeshProUGUI consumingTime;

    [SerializeField] private TextMeshProUGUI remainTimeSurviveInBadStatus;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayLifeSpan(float hours) { 
        lifeSpan.text = "LifeSpan : " + hours.ToString() + " hours";
    }
    public void DisplayConsumingTime(float hours)
    {
        consumingTime.text = "Consuming Durations : " + hours.ToString() + " hours";
    }

    public void DisplayTimeSurviveRemainInBadStatus(float hours) {
        remainTimeSurviveInBadStatus.text = "Will Died After : " + hours + " hours if not being provided nutritions";
    
    }

}

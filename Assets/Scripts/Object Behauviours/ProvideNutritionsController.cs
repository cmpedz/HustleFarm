using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class ProvideNutritionsController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Slider consumeBar;

    [SerializeField] private GameObject needNutritionsAnnoucement;

    [SerializeField] private ObjectInforsController objectInforsDisplay;
    public GameObject NeedNutritionsAnnoucement
    {
       get { return needNutritionsAnnoucement; }
    }

    private IProvideNutritionsProcess providingNutritionsProcess;

    [SerializeField] private Animator provideNutritionsEffect;

    public void ActiveClickEvent()
    {
        if (CheckConditionsProvidingNutritions()) {

            providingNutritionsProcess.SetLastTimeProvidingNutrition( DateTime.Now);

            if (provideNutritionsEffect != null)
            {
                provideNutritionsEffect.gameObject.SetActive(true);

                Debug.Log("check pouring water effect :" + provideNutritionsEffect);

                StartCoroutine(ActiveEventsAfterProvidingsEffectsEnds(provideNutritionsEffect));
            }
            else
            {
                ProvideNutritions();

            }
        }
        
    }

    public abstract void OnLastTimeProvidingNutritionChange();


    protected void Start()
    {
        ObjectDataManager objectDataManager = GetComponent<ObjectDataManager>();

        if (objectDataManager != null) {

            providingNutritionsProcess = (IProvideNutritionsProcess) objectDataManager;

           
        }
        else
        {
            Debug.Log("object data manager is null");
        }

        

        needNutritionsAnnoucement.SetActive(true);

        if (objectDataManager.IsTakenCare)
        {
            ProvideNutritions();
        }
    }


    private IEnumerator ActiveEventsAfterProvidingsEffectsEnds(Animator effect)
    {
        while (effect.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.99) { 

            yield return null;
        }

        effect.gameObject.SetActive(false);

        ProvideNutritions();
    }

    private void ProvideNutritions() {

        GetComponent<ObjectDataManager>().IsTakenCare = true;

        needNutritionsAnnoucement.SetActive(false);

        if (consumeBar != null)
        {
            consumeBar.gameObject.SetActive(true);
        }

        OnLastTimeProvidingNutritionChange();

        StartCoroutine(ConsumeNutritions());

    }

    private IEnumerator ConsumeNutritions()
    {
        double progressValue = 0;

        float maxHourForNextProvidingNutritions = providingNutritionsProcess.GetMaxHourForNextProviding();

        do {

            double consumedTime = (DateTime.Now - providingNutritionsProcess.GetLastTimeProvidingNutrition()).TotalHours;

            double remainTime = maxHourForNextProvidingNutritions - consumedTime;

            //objectInforsDisplay.DisplayConsumingTime((float)remainTime);

            progressValue =  consumedTime / maxHourForNextProvidingNutritions;

            if (consumeBar != null) {

                consumeBar.value = (float) progressValue;

            }

            yield return new WaitForSeconds(1);
        }
        while(progressValue < 1);

        EventAfterCompletingConsumingNutritions();

        if (consumeBar != null)
        {
            consumeBar.value = 0;

            consumeBar.gameObject.SetActive(false);

        }

        GetComponent<ObjectDataManager>().IsTakenCare = false;


    }

    public abstract void EventAfterCompletingConsumingNutritions();

    public abstract bool CheckConditionsProvidingNutritions();


    // Update is called once per frame
    void Update()
    {
        
    }
}

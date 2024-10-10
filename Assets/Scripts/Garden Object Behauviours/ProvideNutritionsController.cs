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
    public static readonly DateTime DEFAULT_LAST_TIME_PROVIDING_NUTRITIONS = new DateTime(2000, 1, 1);
    // Start is called before the first frame update
    [SerializeField] private Slider consumeBar;

    [SerializeField] private GameObject needNutritionsAnnoucement;

    [SerializeField] private ObjectInforsController objectInforsDisplay;
    public GameObject NeedNutritionsAnnoucement
    {
       get { return needNutritionsAnnoucement; }
    }

    [SerializeField] private Animator provideNutritionsEffect;

    private DateTime lastTimeProvidedNutritions = DEFAULT_LAST_TIME_PROVIDING_NUTRITIONS;
    public DateTime LastTimeProvideNutritions
    {
        get { return lastTimeProvidedNutritions; }
    }

    [SerializeField] private float maxHourForNextProvidingNutritions;


    protected bool isTakenCare;
    public bool IsTakenCare
    {
        get { return isTakenCare;  }
        
    }

    public void ActiveClickEvent()
    {
        if (CheckConditionsProvidingNutritions()) {

            isTakenCare = true;

            needNutritionsAnnoucement.SetActive(false);

            lastTimeProvidedNutritions = DateTime.Now;

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

    void Start()
    {
        lastTimeProvidedNutritions = DateTime.Now;

        needNutritionsAnnoucement.SetActive(true);
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

        if (consumeBar != null)
        {
            consumeBar.gameObject.SetActive(true);
        }

        StartCoroutine(ConsumeNutritions());

    }

    private IEnumerator ConsumeNutritions()
    {
        double progressValue = 0;

        do {

            double consumedTime = (DateTime.Now - lastTimeProvidedNutritions).TotalHours;

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

        isTakenCare = false;


    }

    public abstract void EventAfterCompletingConsumingNutritions();

    public abstract bool CheckConditionsProvidingNutritions();


    // Update is called once per frame
    void Update()
    {
        
    }
}

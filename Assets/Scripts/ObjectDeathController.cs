using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectDeathController : MonoBehaviour
{
    [SerializeField] private float lifeSpanToHours;

    [SerializeField] private DateTime timeBorn;

    [SerializeField] private float maxHoursCanSurviveInBadStatus;

    [SerializeField] private ProvideNutritionsController provideNutritionsController;

    [SerializeField] private List<MonoBehaviour> lifeActivities;

    [SerializeField] private Color deathSymbols;

    [SerializeField] private Image sprite;

    [SerializeField] private ObjectInforsController objectInfors;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckDeathStatus());
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private IEnumerator CheckDeathStatus()
    {

        while (IsSurviveInBadStatus()) {

            float NextCheckingDurations = 1;

            yield return new WaitForSeconds(NextCheckingDurations);

        }

        ActiveDeathStatus();
    }
           

    private void ActiveDeathStatus() {

        Debug.Log("Death Status");

        sprite.color = new Color(deathSymbols.r, deathSymbols.g, deathSymbols.b);

        provideNutritionsController.NeedNutritionsAnnoucement.SetActive(false);

        if (lifeActivities != null) { 
            foreach(MonoBehaviour activity in lifeActivities)
            {
                activity.enabled = false;
            }
        }


    }

    private bool IsSurviveInBadStatus() {

        bool isNotProvidedNutritions = !provideNutritionsController.IsTakenCare;

        bool isLastTimeProvideNutritionsDefault = provideNutritionsController.LastTimeProvideNutritions
            .Equals(ProvideNutritionsController.DEFAULT_LAST_TIME_PROVIDING_NUTRITIONS);

        if(isNotProvidedNutritions && !isLastTimeProvideNutritionsDefault)
        {
            double hoursLackOfNutritionsDurations = (DateTime.Now - provideNutritionsController.LastTimeProvideNutritions).TotalHours;

            double remainTime = maxHoursCanSurviveInBadStatus - hoursLackOfNutritionsDurations;

            objectInfors.DisplayTimeSurviveRemainInBadStatus((float)remainTime);

            return remainTime > 0;
        }

        return true;
    }

    private bool IsOutOfLifeSpan() {

        double hoursSurvived = (DateTime.Now - timeBorn).TotalHours;

        return hoursSurvived > lifeSpanToHours;
    }
}

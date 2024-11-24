using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectDeathController : MonoBehaviour
{

    [SerializeField] private ProvideNutritionsController provideNutritionsController;

    [SerializeField] private List<MonoBehaviour> lifeActivities;

    [SerializeField] private Color deathSymbols;

    [SerializeField] private Image sprite;

    [SerializeField] private ObjectInforsController objectInfors;

    private PlantsDataManager plantDataManager;

    // Start is called before the first frame update
    void Start()
    {

        this.plantDataManager = GetComponent<PlantsDataManager>();

    

        StartCoroutine(CheckDeathStatus());
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private IEnumerator CheckDeathStatus()
    {

        while (IsSurviveInBadStatus() && !IsOutOfLifeSpan()) {

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

        bool isNotProvidedNutritions = !plantDataManager.IsTakenCare;

        bool isLastTimeProvideNutritionsDefault = plantDataManager.GetLastTimeProvidingNutrition()
            .Equals(ObjectDataManager.DEFAULT_LAST_TIME_PROVIDING_NUTRITIONS);

        Debug.Log("check last time provided : " + plantDataManager.GetLastTimeProvidingNutrition());

        if(isNotProvidedNutritions && !isLastTimeProvideNutritionsDefault)
        {
            double hoursLackOfNutritionsDurations = (DateTime.Now - plantDataManager.GetLastTimeProvidingNutrition()).TotalHours;

            double remainTime = plantDataManager.GetMaxHoursCanSurviveInBadStatus() - hoursLackOfNutritionsDurations;

            //objectInfors.DisplayTimeSurviveRemainInBadStatus((float)remainTime);

            return remainTime > 0;
        }

        return true;
    }

    private bool IsOutOfLifeSpan() {

        double hoursSurvived = (DateTime.Now - plantDataManager.GetTimeBorn()).TotalHours;

        return hoursSurvived > plantDataManager.GetLifeSpan();
    }
}

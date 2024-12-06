using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class PouringWaterController : ProvideNutritionsController
{

    [SerializeField] private GameObject harvestingAnnocement;

    [SerializeField] private UserPLantsChangeControllerSystem plantsChangeControllerSystem;

    [SerializeField] private CurrentUserPointController currentUserPointController;

    private PlantSeedsProcessController dirtContains;

    private PlantsDataManager plantsDataManager;

    private float pointPlus;

    new protected void Start()
    {
        base.Start();

        plantsDataManager = GetComponent<PlantsDataManager>();

        pointPlus = plantsDataManager.PointEachDay;

        plantsChangeControllerSystem = FindAnyObjectByType<UserPLantsChangeControllerSystem>();

        dirtContains = transform.parent.gameObject.GetComponent<PlantSeedsProcessController>();

        currentUserPointController = FindAnyObjectByType<CurrentUserPointController>();
        
    }
    public override bool CheckConditionsProvidingNutritions()
    {
        return !plantsDataManager.IsTakenCare && NeedNutritionsAnnoucement.activeSelf;
    }

    public override void EventAfterCompletingConsumingNutritions()
    {
        harvestingAnnocement.SetActive(true);

        currentUserPointController.IncreaseCurrentUserPoint(InstanceUserGeneralInfors.Instance.UserId, pointPlus, 0);
    }

   

    public override void OnLastTimeProvidingNutritionChange()
    {
        if (dirtContains != null && plantsDataManager != null) {

            int indexOfDirtContains = plantsDataManager.DirtIndex;

            Debug.Log("check last time pouring water : " + plantsDataManager.GetLastTimeProvidingNutrition());

            plantsChangeControllerSystem.OnObjectDataChanging(indexOfDirtContains.ToString(), GetComponent<PlantsDataManager>());

        }
        else
        {
            Debug.Log("plant data manager los dirt contains is null");
        }

    }
}

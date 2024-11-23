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

    new protected void Start()
    {
        base.Start();

        plantsChangeControllerSystem = FindAnyObjectByType<UserPLantsChangeControllerSystem>();
    }
    public override bool CheckConditionsProvidingNutritions()
    {
        return !isTakenCare && NeedNutritionsAnnoucement.activeSelf;
    }

    public override void EventAfterCompletingConsumingNutritions()
    {
        harvestingAnnocement.SetActive(true);
    }

    public override void OnLastTimeProvidingNutritionChange()
    {
        PlantSeedsProcessController dirtContains = transform.parent.gameObject.GetComponent<PlantSeedsProcessController>();

        if (dirtContains != null) {

            DirtStatusControllerSystem garden = FindAnyObjectByType<DirtStatusControllerSystem>();

            if (garden != null) {

                int indexOfDirtContains = garden.GetIndexOfSpecifideDirt(dirtContains);

                Debug.Log("index of dirt having changed plant : " + indexOfDirtContains);
            }

        }
        else
        {
            Debug.Log("dirt contains is null");
        }
    }
}

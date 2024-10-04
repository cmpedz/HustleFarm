using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouringWaterController : ProvideNutritionsController
{

    [SerializeField] private GameObject harvestingAnnocement;

    [SerializeField] private GameObject needWaterAnnocement;
    public override bool CheckConditionsProvidingNutritions()
    {
        return !isTakenCare && needWaterAnnocement.activeSelf;
    }

    public override void EventAfterCompletingConsumingNutritions()
    {
        harvestingAnnocement.SetActive(true);
    }

    
}

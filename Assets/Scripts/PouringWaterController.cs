using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouringWaterController : ProvideNutritionsController
{

    [SerializeField] private GameObject harvestingAnnocement;
    public override bool CheckConditionsProvidingNutritions()
    {
        return !isTakenCare && NeedNutritionsAnnoucement.activeSelf;
    }

    public override void EventAfterCompletingConsumingNutritions()
    {
        harvestingAnnocement.SetActive(true);
    }

    
}

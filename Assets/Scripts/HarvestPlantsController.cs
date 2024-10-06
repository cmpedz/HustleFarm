using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HarvestPlantsController : MonoBehaviour
{
    [SerializeField] private GameObject harvestingAnnocement;

    [SerializeField] private GameObject needWaterAnnocement;

    [SerializeField] private BagMenu userBag;

    [SerializeField] private Item itemCollected;
    public void ActiveClickEvents()
    {
        if(harvestingAnnocement.activeSelf)
        {
            harvestingAnnocement.SetActive(false);

            ActiveEventAfterHarvestingPlants();

            needWaterAnnocement.SetActive(true);
        }
    }

    public void ActiveEventAfterHarvestingPlants() {

        Debug.Log("harvest products");

        if (userBag != null && itemCollected != null) {

            userBag.AddItem(itemCollected.GetClone());

        }
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HarvestPlantsController : MonoBehaviour
{
    [SerializeField] private GameObject harvestingAnnocement;

    [SerializeField] private GameObject needWaterAnnocement;

    [SerializeField] private BagMenu userBag;
    public BagMenu UserBag { get { return userBag; } set {  userBag = value; } }

    [SerializeField] private Item itemCollected;
    public Item ItemCollected { get {  return itemCollected; }  }

    [SerializeField] private ItemReceiveNotificationSetUp itemReceiveNotification;

   
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

        int quantitiesItemReceived = itemReceiveNotification.QuantitiesReceived;

        if (userBag != null && itemCollected != null) {

            for(int i = 0; i < quantitiesItemReceived; i++)
            {
                userBag.AddItem(itemCollected.GetClone());
            }

            if(itemReceiveNotification != null )
            {
                itemReceiveNotification.NotifyItemReceived(itemCollected.GetItemSprite(), true);
            }
           
        }
    }

    
}

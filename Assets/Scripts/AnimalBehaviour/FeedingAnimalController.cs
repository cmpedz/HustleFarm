using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedingAnimalController : ProvideNutritionsController
{
    [SerializeField] private List<Item> foodsNeed = new List<Item>();

    [SerializeField] private BagMenu userBag;

    private Item foodNeed;

    [SerializeField] private SpriteRenderer foodNeedDisplay;

    [SerializeField] private NotificationController notificationController;

    new void Start()
    {
        base.Start();

        foodNeed = GetFoodNeed();

        foodNeedDisplay.sprite = foodNeed.GetItemSprite();

    }

    private Item GetFoodNeed(){

        int indexFoodNeed = Random.Range(0, foodsNeed.Count);

        if(foodsNeed.Count > 0) { 
           return foodsNeed[indexFoodNeed]; 
        }

        return null;
    }
    public override bool CheckConditionsProvidingNutritions()
    {
        Debug.Log("prodvide food for animal");
        return MeetAnimalDemand() && !isTakenCare && NeedNutritionsAnnoucement.activeSelf;
    }

    public override void EventAfterCompletingConsumingNutritions()
    {
        Debug.Log("animal has consumed energy!");

        foodNeed = GetFoodNeed();

        foodNeedDisplay.sprite = foodNeed.GetItemSprite();

        NeedNutritionsAnnoucement.SetActive(true);
    }

    private bool MeetAnimalDemand() {

        if(userBag == null || foodNeed== null) return false;

        bool isSatisfiedAnimalDemand = userBag.HasItem(foodNeed.GetItemId());

        if (isSatisfiedAnimalDemand)
        {
            userBag.RemoveItem(foodNeed);
        }
        else {

            string message = "Not Satisfied Animal Food Demand";

            if (notificationController != null) {

                notificationController.NotifyMessage(message);
            }
            
        }

        return isSatisfiedAnimalDemand;
    }

    public override void OnLastTimeProvidingNutritionChange()
    {
        
    }
}

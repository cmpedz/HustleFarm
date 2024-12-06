using System.Collections.Generic;
using UnityEngine;

public class FeedingAnimalController : ProvideNutritionsController
{
    [SerializeField] private List<Item> foodsNeed = new List<Item>();

    [SerializeField] private BagMenu userBag = BagMenu.Instance;

    private Item foodNeed;

    [SerializeField] private SpriteRenderer foodNeedDisplay;

    [SerializeField] private NotificationController notificationController;

    [SerializeField] private PlayerPointChangeScriptableObject playerPointChangeScriptableObject;

    [SerializeField] private CurrentUserPointController currentUserRankController;
    public NotificationController NotificationController
    {
        get { return this.notificationController; }

        set { this.notificationController = value; }
    }

    [SerializeField] private AnimalDataManager animalDataManager;

    private float pointRate;


    new void Start()
    {
        base.Start();

        foodNeed = GetFoodNeed();

        userBag = FindAnyObjectByType<BagMenu>();

        foodNeedDisplay.sprite = foodNeed.GetItemSprite();

        animalDataManager = GetComponent<AnimalDataManager>();

        currentUserRankController = FindAnyObjectByType<CurrentUserPointController>();

        pointRate = animalDataManager.PointBonusRate;

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
        return MeetAnimalDemand() && !animalDataManager.IsTakenCare && NeedNutritionsAnnoucement.activeSelf;
    }

    public override void EventAfterCompletingConsumingNutritions()
    {
        Debug.Log("animal has consumed energy!");

        foodNeed = GetFoodNeed();

        foodNeedDisplay.sprite = foodNeed.GetItemSprite();

        NeedNutritionsAnnoucement.SetActive(true);

        currentUserRankController.IncreaseCurrentUserPoint(InstanceUserGeneralInfors.Instance.UserId, 
            0, pointRate);
    }

   

    private bool MeetAnimalDemand() {

        if(userBag == null || foodNeed== null) return false;

        bool isSatisfiedAnimalDemand = userBag.HasItem(foodNeed.GetItemId());

        if (isSatisfiedAnimalDemand)
        {
            userBag.RemoveItem(foodNeed, true);
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

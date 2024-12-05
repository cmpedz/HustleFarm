using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlantSeedsProcessController : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] private GameObject plantedSeed;

    [SerializeField] private Transform plantingPos;

    [SerializeField] private GameObject arrow;

    [SerializeField] private UserPLantsChangeControllerSystem pLantsChangeControllerSystem;


    public GameObject Arrow
    {
        get { return arrow; }
    }

    [SerializeField] private HarvestPlantsController seedProvided;
    public HarvestPlantsController SeedProvided
    {
        get { return seedProvided;  }

        set { seedProvided = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        pLantsChangeControllerSystem = FindAnyObjectByType<UserPLantsChangeControllerSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsDirtEmpty() {

        if (plantedSeed != null) return false;

        return true;
    }

    public void RemoveCurrentOwnPlant()
    {
        pLantsChangeControllerSystem.OnRemovingOldObject(plantedSeed.GetComponent<PlantsDataManager>().DirtIndex.ToString());

        Destroy(plantedSeed);
    }

    public void PlantSeed(HarvestPlantsController seed, SerializedPlantData plantsData) {

          Debug.Log("planted seed");

          GameObject _seed = Instantiate(seed.gameObject);
            
          plantedSeed = _seed;

          if(plantsData == null && plantedSeed != null)
          {
             plantsData = GachaStorageSystem.Instance.RetrieveItemGachaData(plantedSeed.GetComponent<PlantsDataManager>().Id);

             plantsData.DirtOrder = DirtStatusControllerSystem.Instance.GetIndexOfSpecifideDirt(this);

           }

          

          ConstructSeedAttributes(plantsData);

          DirtStatusControllerSystem.Instance.RemoveDirtFromEmptyDirts(this);

    }

    private void ConstructSeedAttributes(SerializedPlantData plantsData)
    {
        plantedSeed.GetComponent<PlantsDataManager>().SerializedPLantDataToPlantDataManager(plantsData);

        plantedSeed.SetActive(true);

        plantedSeed.transform.parent = transform;

        plantedSeed.transform.position = plantingPos.position;

        plantedSeed.transform.localScale = new Vector3(1, 1, 1);
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if(arrow != null && seedProvided != null) {

            if (arrow.activeSelf) {

                PlantSeed(seedProvided, null);

                DirtStatusControllerSystem.Instance.ActiveSymbolOfEmptyDirt(false);

                DirtStatusControllerSystem.Instance.RemoveQuantitiesSeedItemClicked();

                this.arrow.SetActive(false);

                pLantsChangeControllerSystem.OnHavingNewObject(plantedSeed.GetComponent<PlantsDataManager>());

            }
        }
    }
}

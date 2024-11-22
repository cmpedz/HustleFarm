using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlantSeedsProcessController : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] private GameObject plantedSeed;

    [SerializeField] private Transform plantingPos;

    [SerializeField] private GameObject arrow;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsDirtEmpty() {

        if (plantedSeed != null) return false;

        return true;
    }

    public void PlantSeed(HarvestPlantsController seed, SerializedPlantData plantsData) {

          Debug.Log("planted seed");

          GameObject _seed = Instantiate(seed.gameObject);
            
          plantedSeed = _seed;

          if(plantsData == null && plantedSeed != null)
          {
             plantsData = GachaStorageSystem.Instance.RetrieveItemGachaData(plantedSeed.GetComponent<PlantsDataManager>().Id);
        }

          Debug.Log("check plant seed id : " + plantedSeed.GetComponent<PlantsDataManager>().Id);

          plantedSeed.GetComponent<PlantsDataManager>().SerializedPLantDataToPlantDataManager(plantsData);

          plantedSeed.SetActive(true);

          plantedSeed.transform.parent = transform;

          plantedSeed.transform.position = plantingPos.position;

          plantedSeed.transform.localScale = new Vector3(1, 1, 1);

          DirtStatusControllerSystem.Instance.RemoveDirtFromEmptyDirts(this);

    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if(arrow != null && seedProvided != null) {

            if (arrow.activeSelf) {

                PlantSeed(seedProvided, null);

                DirtStatusControllerSystem.Instance.ActiveSymbolOfEmptyDirt(false);

                DirtStatusControllerSystem.Instance.RemoveQuantitiesSeedItemClicked();

                this.arrow.SetActive(false);
                
            }
        }
    }
}

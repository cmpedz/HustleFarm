using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleUserDataPlants : HandleUserData<UserPlants>
{

    private List<SerializedPlantData> plantsUserHas = new List<SerializedPlantData>();
    public List<SerializedPlantData> PlantUserHas { get { return this.plantsUserHas; } }

    [SerializeField] private List<PlantsDataManager> plantsStorage;

    private Dictionary<string, HarvestPlantsController> plantsDictionary = new Dictionary<string, HarvestPlantsController>();

    private void Start()
    {
        foreach(PlantsDataManager plant in plantsStorage)
        {
            plantsDictionary.Add(plant.Id, plant.gameObject.GetComponent<HarvestPlantsController>());
        }
    }
    public override void HandleDataEvent(UserPlants data)
    {
        Debug.Log("check user plants currently has : " + JsonConvert.SerializeObject(data));

        foreach(string jsonStringPlant in data.Plants)
        {
            SerializedPlantData jsonStringToObject = JsonUtility.FromJson<SerializedPlantData>(jsonStringPlant);

            plantsUserHas.Add(jsonStringToObject);
        }

    }

    public HarvestPlantsController GetSpecifiedSeed(string plantId)
    {
        return this.plantsDictionary[plantId];
    }
}

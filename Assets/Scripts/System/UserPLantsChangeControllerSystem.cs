using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserPLantsChangeControllerSystem : MonoBehaviour, IObjectChangeDataSystem<PlantsDataManager>
{
    [SerializeField] private HandleUserDataPlants handleUserDataPlants;
    void Start()
    {
        handleUserDataPlants = FindAnyObjectByType<HandleUserDataPlants>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public string ConvertUserPlantsDataIntoJson()
    {
        UserPlants userPlants = new UserPlants();

        List<SerializedPlantData> currentPlantsUserHas = handleUserDataPlants.GetObjectsHas();

        foreach(SerializedPlantData sePlantData in currentPlantsUserHas)
        {
            string plantDataToJson = JsonUtility.ToJson(sePlantData);

            userPlants.Plants.Add(plantDataToJson);
        }

        return JsonUtility.ToJson(userPlants);

    }



    public void OnHavingNewObject(PlantsDataManager plantData)
    {
        SerializedPlantData serializedPlantData = new SerializedPlantData();

        serializedPlantData.PlantDataManagerToSerializedPlantData(plantData);

        handleUserDataPlants.GetObjectsHas().Add(serializedPlantData);

        Debug.Log(ConvertUserPlantsDataIntoJson());
    }

    public void OnRemovingOldObject(int plantIndex)
    {
        handleUserDataPlants.GetObjectsHas().RemoveAt(plantIndex);

        Debug.Log(ConvertUserPlantsDataIntoJson());
    }

    public void OnObjectDataChanging(int plantIndex, PlantsDataManager newPlantData)
    {
        SerializedPlantData serializedPlantData = new SerializedPlantData();

        serializedPlantData.PlantDataManagerToSerializedPlantData(newPlantData);

        handleUserDataPlants.GetObjectsHas()[plantIndex] = serializedPlantData;

        Debug.Log(ConvertUserPlantsDataIntoJson());
    }
}

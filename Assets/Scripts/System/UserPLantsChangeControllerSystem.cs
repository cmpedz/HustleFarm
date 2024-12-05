using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserPLantsChangeControllerSystem : MonoBehaviour, IObjectChangeDataSystem<PlantsDataManager>
{
    [SerializeField] private HandleUserDataPlants handleUserDataPlants;

    [SerializeField] private DataChangeScriptTableObject dataChangeScriptTableObject;
    void Start()
    {
        handleUserDataPlants = FindAnyObjectByType<HandleUserDataPlants>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public UserPlants GetUserPlantsData()
    {
        UserPlants userPlants = new UserPlants();

        List<SerializedPlantData> currentPlantsUserHas = handleUserDataPlants.GetObjectsHas();

        foreach(SerializedPlantData sePlantData in currentPlantsUserHas)
        {
            string plantDataToJson = JsonUtility.ToJson(sePlantData);

            userPlants.Plants.Add(plantDataToJson);
        }

        return userPlants;

    }



    public void OnHavingNewObject(PlantsDataManager plantData)
    {
        SerializedPlantData serializedPlantData = new SerializedPlantData();

        serializedPlantData.PlantDataManagerToSerializedPlantData(plantData);

        handleUserDataPlants.GetObjectsHas().Add(serializedPlantData);

        dataChangeScriptTableObject.OnDataChange(GetUserPlantsData());
    }

    public void OnRemovingOldObject(string dirtOrderToString)
    {
        int dirtOrder = int.Parse(dirtOrderToString);

        for (int i = 0; i < handleUserDataPlants.GetObjectsHas().Count; i++)
        {
            if (handleUserDataPlants.GetObjectsHas()[i].DirtOrder == dirtOrder)
            {
                handleUserDataPlants.GetObjectsHas().RemoveAt(i);
                break;
            }
        }

        dataChangeScriptTableObject.OnDataChange(GetUserPlantsData());


    }

    public void OnObjectDataChanging(string dirtOrderToString, PlantsDataManager newPlantData)
    {
        SerializedPlantData serializedPlantData = new SerializedPlantData();

        int dirtOrder = int.Parse(dirtOrderToString);

        serializedPlantData.PlantDataManagerToSerializedPlantData(newPlantData);

        for(int i =0; i< handleUserDataPlants.GetObjectsHas().Count; i++)
        {
            if(handleUserDataPlants.GetObjectsHas()[i].DirtOrder == dirtOrder)
            {
                handleUserDataPlants.GetObjectsHas()[i] = serializedPlantData;
                break;
            }
        }

        dataChangeScriptTableObject.OnDataChange(GetUserPlantsData());
    }
}

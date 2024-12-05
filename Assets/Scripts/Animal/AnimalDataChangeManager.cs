using Assets.Scripts.ObjectDataManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalDataChangeManager : MonoBehaviour, IObjectChangeDataSystem<AnimalDataManager>
{
    // Start is called before the first frame update
    [SerializeField] private HandleUserAnimalsData handleUserAnimalsData;

    [SerializeField] private DataChangeScriptTableObject dataChangeScriptTable;

    void Start()
    {
        handleUserAnimalsData = FindAnyObjectByType<HandleUserAnimalsData>();
    }


    public UserAnimals GetUserAnimalsData()
    {
        UserAnimals userAnimals = new UserAnimals();

        Dictionary<string, SerializedAnimalData> currentAnimalsUserHas = handleUserAnimalsData.GetAnimalsUserHas();

        foreach (var currantAnimal in currentAnimalsUserHas)
        {
            string animalDataToJson = JsonUtility.ToJson(currantAnimal.Value);

            userAnimals.Animals.Add(animalDataToJson);
        }

        return userAnimals;

    }


    public void OnHavingNewObject(AnimalDataManager newObject)
    {
        
    }

    public void OnObjectDataChanging(string animalId, AnimalDataManager newData)
    {
        SerializedAnimalData serializedAnimalData = new SerializedAnimalData();

        serializedAnimalData.ConvertFromAnimalDataManager(newData);

        handleUserAnimalsData.ChangeDataOfSpecifiedAnimal(animalId, serializedAnimalData);

        dataChangeScriptTable.OnDataChange(GetUserAnimalsData());
        
    }

    public void OnAnimalsPositionChanging(List<AnimalDataManager> animals)
    {
        foreach (AnimalDataManager animal in animals)
        {
            SerializedAnimalData serializedAnimalData = new SerializedAnimalData();

            serializedAnimalData.ConvertFromAnimalDataManager(animal);

            handleUserAnimalsData.ChangeDataOfSpecifiedAnimal(animal.Id, serializedAnimalData);
        }

        dataChangeScriptTable.OnDataChange(GetUserAnimalsData());
    }

    public void OnRemovingOldObject(string animalId)
    {
        
    }

 
}

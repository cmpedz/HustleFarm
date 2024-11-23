using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlantsUserHasSystem : MonoBehaviour
{

    [SerializeField] private DirtStatusControllerSystem dirtStatusControllerSystem;

    [SerializeField] private HandleUserDataPlants handleUserDataPlants;

    // Start is called before the first frame update
    void Start()
    {
        handleUserDataPlants = FindAnyObjectByType<HandleUserDataPlants>();

        int index = 0;

        foreach(SerializedPlantData plantData in handleUserDataPlants.GetObjectsHas())
        {
            HarvestPlantsController seedPlanted = handleUserDataPlants.GetSpecifiedSeed(plantData.Id);

            dirtStatusControllerSystem.GetSpecifiedDirt(index).PlantSeed(seedPlanted, plantData);

            index++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

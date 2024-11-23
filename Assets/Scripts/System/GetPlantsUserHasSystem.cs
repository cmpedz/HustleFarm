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


        foreach(SerializedPlantData plantData in handleUserDataPlants.GetObjectsHas())
        {
            int dirtIndex = plantData.DirtOrder;

            HarvestPlantsController seedPlanted = handleUserDataPlants.GetSpecifiedSeed(plantData.Id);

            dirtStatusControllerSystem.GetSpecifiedDirt(dirtIndex).PlantSeed(seedPlanted, plantData);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

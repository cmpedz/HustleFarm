using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSeedsController : MonoBehaviour
{

    [SerializeField] private GameObject testSeed;

    [SerializeField] private GameObject plantedSeed;

    [SerializeField] private Transform plantingPos;

    // Start is called before the first frame update
    void Start()
    {
        CheckPlantingSeed(testSeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckPlantingSeed(GameObject seed) {

        if (seed == null || plantedSeed != null) return false;

        PlantSeed(seed);

        return true;
    }

    private void PlantSeed(GameObject seed) { 

          GameObject _seed = Instantiate(seed);
            
          plantedSeed = _seed;

          plantedSeed.transform.position = plantingPos.position;
            
    }


}

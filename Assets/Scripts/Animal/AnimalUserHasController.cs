using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalUserHasController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private ConvertAnimalIdToAnimalObject convertAnimalIdToAnimalObject;

    [SerializeField] private DisplayAnimalsUserHas displayAnimalsHas;

    private List<AnimalDataManager> animalsOwned = new List<AnimalDataManager>();


    void Start()
    {
        foreach(int animalId in GetNftAnimalUserHas.Instance.IdNftOwned)
        {
            animalsOwned.Add(convertAnimalIdToAnimalObject.GetAnimalObject(animalId.ToString()));
        }

        if(displayAnimalsHas != null)
        {
            displayAnimalsHas.EnableAnimalsUserHas(animalsOwned);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

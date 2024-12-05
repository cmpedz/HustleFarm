using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalUserHasController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private ConvertAnimalIdToAnimalObject convertAnimalIdToAnimalObject;

    [SerializeField] private DisplayAnimalsUserHas displayAnimalsHas;

    [SerializeField] private AnimalDataChangeManager animalDataChangeManager;

    private List<AnimalDataManager> animalsOwned = new List<AnimalDataManager>();

    private const float MAX_TIME_UPDATE_ANIMALS_POSTION = 10f;


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

        InvokeRepeating("UpdateAnimalsPostion",0, MAX_TIME_UPDATE_ANIMALS_POSTION);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateAnimalsPostion()
    {
        Debug.Log("update animal postions");
         animalDataChangeManager.OnAnimalsPositionChanging(animalsOwned);
        
        
    }
}

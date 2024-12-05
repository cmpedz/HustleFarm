using Assets.Scripts.ObjectDataManager;
using Org.BouncyCastle.Bcpg.Sig;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertAnimalIdToAnimalObject : MonoBehaviour
{
    // Start is called before the first frame update
    [System.Serializable]
    public class AnimalObject
    {
        public string id;
        public AnimalDataManager animalData;

    }

    [SerializeField] private List<AnimalObject> animalsData = new List<AnimalObject>();

    private Dictionary<string, AnimalDataManager> animalsDictionary = new Dictionary<string, AnimalDataManager>();

    private HandleUserAnimalsData handleUserAnimalsData;

    void Awake()
    {
        foreach (AnimalObject animalData in animalsData)
        {
            Debug.Log("adding animal with id : " + animalData.id);
            animalsDictionary.Add(animalData.id, animalData.animalData);
        }

        handleUserAnimalsData = FindAnyObjectByType<HandleUserAnimalsData>();
    }

    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AnimalDataManager GetAnimalObject(string id)
    {
        if (animalsDictionary.ContainsKey(id))
        {
            SerializedAnimalData initialData = null;

            if (handleUserAnimalsData.GetAnimalDataFromServer(id) != null)
            {
                Debug.Log("animal data from server with id : " + id);
                initialData = handleUserAnimalsData.GetAnimalDataFromServer(id);
            }
            else
            {
                Debug.Log("use origin animal data with id : " + id);
                initialData = AnimalDataFromServerController.Instance.GetSpecifiedAnimalData(id);
            }
            

            AnimalDataManager animalObject = Instantiate(animalsDictionary[id]);

            animalObject.ConvertFromSerializedAnimalData(initialData);

            return animalObject;
        }
        else
        {
            Debug.Log("animal dictionary doesnt has id : " + id);
        }

        return null;
    }
}

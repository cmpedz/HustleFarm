using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ConvertAnimalIdToAnimalObject;

public class DisplayAnimalsUserHas : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Transform startPointSummon;

    [SerializeField] private Transform endPointSummon;

    [SerializeField] private NotificationController notificationController;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 GetRandomLocation()
    {
        float randomX = Random.Range(startPointSummon.position.x, endPointSummon.position.x);

        float randomY = Random.Range(startPointSummon.position.y, endPointSummon.position.y);

        return new Vector3(randomX, randomY, 0);
    }

    public void EnableAnimalsUserHas(List<AnimalDataManager> animalsOwned)
    {
        foreach (AnimalDataManager animal in animalsOwned)
        {

            if(animal.Position == null)
            {

                animal.transform.position = GetRandomLocation();
                Debug.Log("check random location animal retrieved : " + animal.transform.position);
            }

            animal.GetComponent<FeedingAnimalController>().NotificationController = notificationController;

            animal.gameObject.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlantSeedsController : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] private GameObject plantedSeed;

    [SerializeField] private Transform plantingPos;

    [SerializeField] private GameObject arrow;

    [SerializeField] private DirtStatusControllerSystem dirtStatus;
    public GameObject Arrow
    {
        get { return arrow; }
    }

    [SerializeField] private GameObject seedProvided;
    public GameObject SeedProvided
    {
        get { return seedProvided;  }

        set { seedProvided = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsDirtEmpty() {

        if (plantedSeed != null) return false;

        return true;
    }

    private void PlantSeed(GameObject seed) {

          Debug.Log("planted seed");

          GameObject _seed = Instantiate(seed);
            
          plantedSeed = _seed;

          plantedSeed.SetActive(true);

          plantedSeed.transform.parent = transform;

          plantedSeed.transform.position = new Vector3(0, 0, 0);

          plantedSeed.transform.localScale = new Vector3(1, 1, 1);

          
            
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(arrow != null && seedProvided != null) {

            if (arrow.activeSelf) {

                PlantSeed(seedProvided);

                dirtStatus.ActiveSymbolOfEmptyDirt(false);

                dirtStatus.RemoveDirtFromEmptyDirts(this);
                
            }
        }
    }
}

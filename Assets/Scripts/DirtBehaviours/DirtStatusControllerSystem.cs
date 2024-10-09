using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtStatusControllerSystem : MonoBehaviour
{
    [SerializeField] private List<PlantSeedsController> dirts = new List<PlantSeedsController>();

    [SerializeField] private List<PlantSeedsController> emptyDirts = new List<PlantSeedsController>();

    [SerializeField] private GameObject terminateFunctionButton;

    [SerializeField] private GameObject seedProvided;

    private static DirtStatusControllerSystem instance;
    public static DirtStatusControllerSystem Instance
    {
        get { return instance; }
        private set { instance = value; }
    }

    private DirtStatusControllerSystem() { }
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;

            foreach (PlantSeedsController dirt in dirts)
            {
                if (dirt != null) {

                    if (dirt.IsDirtEmpty())
                    {
                        emptyDirts.Add(dirt);
                    }
                }
                   
            }
        }
        else
        {
            if(instance != this) {
                Destroy(gameObject);
            }
        }

       

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) {

            ActiveSymbolOfEmptyDirt(true);

            ProvideSeedForEmptyDirt(seedProvided);

        }
        
    }

    public void RemoveDirtFromEmptyDirts(PlantSeedsController dirt) {
           emptyDirts.Remove(dirt);
    }

    public void ProvideSeedForEmptyDirt(GameObject seed)
    {
        foreach (PlantSeedsController emptyDirt in emptyDirts)
        {

            if (emptyDirt != null && seedProvided != null) emptyDirt.SeedProvided = seed;

        }
    }

    public void ActiveSymbolOfEmptyDirt(bool active) {

        Debug.Log("active symbol of empty dirt");

        foreach (PlantSeedsController emptyDirt in emptyDirts) {
            
            if(emptyDirt != null) emptyDirt.Arrow.SetActive(active);

        }

        terminateFunctionButton.SetActive(active);
    }




}

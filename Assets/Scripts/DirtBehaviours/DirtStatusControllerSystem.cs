using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtStatusControllerSystem : MonoBehaviour
{
    [SerializeField] private List<PlantSeedsController> dirts = new List<PlantSeedsController>();

    [SerializeField] private List<PlantSeedsController> emptyDirts = new List<PlantSeedsController>();

    [SerializeField] private GameObject terminateFunctionButton;

    [SerializeField] private HarvestPlantsController seedProvided;
    public HarvestPlantsController SeedProvided
    {
        get { return seedProvided; }

        set { seedProvided = value; }
    }

    [SerializeField] private SeedsItem seedItemInBagClicked;

    public SeedsItem SeedItemInBagClicked { 
        get { return seedItemInBagClicked; }
        set { seedItemInBagClicked = value;}
    }

    private static DirtStatusControllerSystem instance;
    public static DirtStatusControllerSystem Instance
    {
        get { return instance; }
        private set { instance = value; }
    }

    [SerializeField] private BagMenu userBag;
    private DirtStatusControllerSystem() { }
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;

            userBag = BagMenu.Instance;

            terminateFunctionButton = FunctionBarController.Instance
                .GetFunctionByName(FunctionBarController.EFunctionName.Terminate_Function);

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
        
    }

    public void RemoveDirtFromEmptyDirts(PlantSeedsController dirt) {
        
        emptyDirts.Remove(dirt);


    }


    public void RemoveQuantitiesSeedItemClicked() { 
        if(seedItemInBagClicked != null && userBag != null) {
            userBag.RemoveItem(seedItemInBagClicked);
            userBag.UpdateItemsChangeIntoServer();
        }
    }

    public void ProvideSeedForEmptyDirt()
    {
        foreach (PlantSeedsController emptyDirt in emptyDirts)
        {

            if (emptyDirt != null && seedProvided != null) emptyDirt.SeedProvided = SeedProvided;

        }
    }

    public void ActiveSymbolOfEmptyDirt(bool active) {

        Debug.Log("active symbol of empty dirt");

        if(active)
        {
            ProvideSeedForEmptyDirt();
        }

        foreach (PlantSeedsController emptyDirt in emptyDirts) {
            
            if(emptyDirt != null) emptyDirt.Arrow.SetActive(active);

        }

        terminateFunctionButton.SetActive(active);
    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaItemDisplaySystem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List<ObjectData> plantSeeds;

    [SerializeField] private GachaItemController itemForm;

    [SerializeField] private GameObject content;

    private Dictionary<string, Sprite> plantSeedsDictionaries = new Dictionary<string, Sprite>();

    void Start()
    {
        foreach (ObjectData plantSeed in plantSeeds) {
            Debug.Log("check seed name : " + plantSeed.itemName);
            plantSeedsDictionaries.Add(plantSeed.itemName, plantSeed.sprite);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayGachaItem(string name) {

        if(!plantSeedsDictionaries.ContainsKey(name)) {
            Debug.Log("seed is not exsists");
            return; 
        }

        Sprite plantSeedSprite = plantSeedsDictionaries[name];

        if (plantSeedSprite != null) { 

            GachaItemController gachaItem = Instantiate(itemForm.gameObject).GetComponent<GachaItemController>();

            gachaItem.ItemSprite = plantSeedSprite;

            gachaItem.transform.SetParent(content.transform);

            gachaItem.gameObject.SetActive(true);

            
        }  
    }

    public void ResetData() {
        Transform contentTransform = content.transform;
        for (int i = contentTransform.childCount - 1; i >= 0 ; i--) {
            Destroy(contentTransform.GetChild(i).gameObject);
        }
    }
}

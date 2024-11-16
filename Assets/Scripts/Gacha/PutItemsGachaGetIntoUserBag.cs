using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutItemsGachaGetIntoUserBag : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List<SeedsItem> seedItems;

    private Dictionary<string, SeedsItem> seedItemsDictionary = new Dictionary<string, SeedsItem>();

    private BagMenu userBag;
    void Start()
    {
        userBag = BagMenu.Instance;

        foreach(SeedsItem seeditem in seedItems) { 
               seedItemsDictionary.Add(seeditem.GetItemId(), seeditem);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PutItemsGachaIntoUserBag(string seedItemId) {

        if (!seedItemsDictionary.ContainsKey(seedItemId)) return;

        SeedsItem seeditem = seedItemsDictionary[seedItemId];

        Debug.Log("check seed item : " + seeditem);

        GameObject _seedItem = Instantiate(seeditem.gameObject);

        userBag.AddItem(_seedItem.GetComponent<SeedsItem>());
    }

   
}

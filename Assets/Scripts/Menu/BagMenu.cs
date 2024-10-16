using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class BagMenu : Menu<string>
{
    public List<Item> itemsAdd = new List<Item>();

    private Dictionary<string, Item> bagItems = new Dictionary<string, Item>();

    private void Start()
    {
        foreach (Item item in itemsAdd) {
            AddItem(item);
        }
    }
    public override void AddItem(Item item)
    {
        string itemId = item.GetItemId();

        if(bagItems.ContainsKey(itemId))
        {
            int numberIncreasing = 1;

            bagItems.GetValueOrDefault(itemId).InscreaseQuantitiesItem(numberIncreasing);

        }
        else
        {
            GameObject _item = Instantiate(item.gameObject);

            bagItems.Add(itemId, _item.GetComponent<Item>());

            _item.transform.parent = this.content.transform;

            if (_item.GetComponent<SeedsItem>() != null) {

                _item.GetComponent<SeedsItem>().UserBag = this;
            }
        }
    }

    public override void RemoveItem(Item item)
    {
        string itemId = item.GetItemId();

        if (bagItems.ContainsKey(itemId))
        {
            int numberDecreasing = 1;

            Item selectedItem = bagItems.GetValueOrDefault(itemId);

            selectedItem.DescreaseQuantitiesItem(numberDecreasing);

            if (selectedItem.Quantities <= 0) {

                bagItems.Remove(itemId); 

                Destroy(selectedItem.gameObject);
            }
        }
     
    }

    public override Item GetItem(string itemId)
    {
        if (bagItems.ContainsKey(itemId)){ 
            return bagItems[itemId];
        }

        return null;
    }

    public bool HasItem(string itemId) { 
    
        return bagItems.ContainsKey(itemId); 
    }


}

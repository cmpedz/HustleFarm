using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class BagMenu : Menu<string>
{
    private Dictionary<string, Item> bagItems = new Dictionary<string, Item>();
    public override void AddItem(Item item)
    {
        string itemId = item.GetItemId();

        if(bagItems.ContainsKey(itemId))
        {
            int numberIncreasing = 1;

            bagItems.GetValueOrDefault(itemId).InscreaseQuantitiesItem(numberIncreasing);

            Destroy(item);
        }
        else
        {
            bagItems.Add(itemId, item);

            item.transform.parent = this.content.transform;
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
        else
        {
            Destroy(item);
        }
    }

    public override Item GetItem(string itemId)
    {
        if (bagItems.ContainsKey(itemId)){ 
            return bagItems[itemId];
        }

        return null;
    }


}

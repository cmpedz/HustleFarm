using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleBagUserData : HandleUserData<ItemsBagData>
{
    [SerializeField] private BagMenu userBag;
    public override void HandleDataEvent(ItemsBagData data)
    {
        if (userBag != null) { 
            userBag.gameObject.SetActive(true);
        }

        foreach(string itemId in data.Items)
        {
            Debug.Log("item in bag from firebase : " + itemId);

            GameObject item = ItemStorageSystem.Instance.ConvertItemFromItemId(itemId);

            userBag.AddItem(item.GetComponent<Item>());
        }


        userBag.gameObject.SetActive(false);
    }
}


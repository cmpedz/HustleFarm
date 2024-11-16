using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStorageSystem : Singleton<ItemStorageSystem>
{
    [System.Serializable]
    class ItemStorageForm
    {
        public string Id;

        public GameObject item;

    }

    [field : SerializeField, Header("Item Storage")]
    private List<ItemStorageForm> itemsStorage = new List<ItemStorageForm>();

    private Dictionary<string, int> itemsIndexInStorage = new Dictionary<string, int>();

  

    private void Start()
    {
        int index = 0;

        foreach (ItemStorageForm item in itemsStorage) { 
            itemsIndexInStorage.Add(item.Id, index);
            index++;
        }
    }

    public GameObject ConvertItemFromItemId(string itemId)
    {
        if (itemsIndexInStorage.TryGetValue(itemId, out int itemIndex)) {
            return itemsStorage[itemIndex].item;
        }

        return null;
    }



}

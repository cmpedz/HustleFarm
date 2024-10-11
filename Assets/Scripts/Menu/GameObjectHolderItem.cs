using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameObjectHolderItem<T> : Item
{
    [SerializeField] private GameObject itemHolder;

    [SerializeField] protected BagMenu bagMenu;

    public T GetItemHolder() {

        if (itemHolder == null) return default(T);

        return itemHolder.GetComponent<T>();
    }
}

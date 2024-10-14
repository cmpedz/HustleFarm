using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameObjectHolderItem<T> : Item where T : MonoBehaviour
{
    [SerializeField] private GameObject itemHolder;

    private BagMenu userBag;
    public BagMenu UserBag { 
        get { return userBag; } 
        set { userBag = value; }    
    }

    public T GetItemHolder() {

        if (itemHolder == null) return default;

        return itemHolder.GetComponent<T>();
    }
}

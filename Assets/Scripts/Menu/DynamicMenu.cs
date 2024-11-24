using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DynamicMenu<T> : MonoBehaviour
{
    [SerializeField] protected GameObject content;

    public abstract void AddItem(Item item, bool isNotifyChangingToServer);
    public abstract void RemoveItem(Item item, bool isNotifyChangingToServer);

    public abstract Item GetItem(T feature);
}

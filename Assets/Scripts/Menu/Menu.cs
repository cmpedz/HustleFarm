using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Menu<T> : MonoBehaviour
{
    [SerializeField] protected GameObject content;

    public abstract void AddItem(Item item);
    public abstract void RemoveItem(Item item);

    public abstract Item GetItem(T feature);
}

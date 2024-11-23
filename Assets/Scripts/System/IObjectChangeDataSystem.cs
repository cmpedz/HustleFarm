using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectChangeDataSystem<T>
{
    public void OnHavingNewObject(T newObject);

    public void OnRemovingOldObject(int objectIndex);

    public void OnObjectDataChanging(int objectIndex, T newObjectData);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectChangeDataSystem<T>
{
    public void OnHavingNewObject(T newObject);

    public void OnRemovingOldObject(string objectId);

    public void OnObjectDataChanging(string objectId, T newObjectData);

}

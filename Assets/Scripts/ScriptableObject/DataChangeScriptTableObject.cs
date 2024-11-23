using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataChange", menuName = "ScriptableObject/DataChange")]
public class DataChangeScriptTableObject : ScriptableObject
{
    private List<IOnDataChangeEvent> events = new List<IOnDataChangeEvent>();

    public void OnDataChange(object data)
    {
        foreach (IOnDataChangeEvent _event in events)
        {
            _event.OnDataChange(data);
        }
    }

    public void AddEvent(IOnDataChangeEvent _event)
    {
        this.events.Add(_event);
    }

    public void RemoveEvent(IOnDataChangeEvent _event)
    {
        this.events.Remove(_event);
    }
}

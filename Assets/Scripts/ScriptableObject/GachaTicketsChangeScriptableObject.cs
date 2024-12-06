using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GachaTicketsChange", menuName = "ScriptableObject/GachaTicketsChange")]
public class GachaTicketsChangeScriptableObject : ScriptableObject
{
   private List<IOnGachaTicketsChange> onGachaTicketsChange = new List<IOnGachaTicketsChange>();

   public void OnGachaTicketsChange(int quantities)
   {
        Debug.Log("on gacha ticket change");
        foreach(IOnGachaTicketsChange listener in onGachaTicketsChange)
        {
            listener.OnGachaTicketsChange(quantities);
        }
   }

    public void AddListener(IOnGachaTicketsChange listener)
    {
        this.onGachaTicketsChange.Add(listener);
    }

    public void RemoveListener(IOnGachaTicketsChange listener) { 
        this.onGachaTicketsChange.Remove(listener);
    }
}

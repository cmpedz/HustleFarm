using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerPointChange", menuName = "ScriptableObject/PlayerPointChange")]
public class PlayerPointChangeScriptableObject : ScriptableObject
{
   private List<IOnPlayerPointChange> onPlayerPointChanges = new List<IOnPlayerPointChange>();


    public void AddListener(IOnPlayerPointChange listener)
   {

        if (!onPlayerPointChanges.Contains(listener))
        {
            onPlayerPointChanges.Add(listener);
        }
        
   }

    public void RemoveListener(IOnPlayerPointChange listener) { 
        onPlayerPointChanges.Remove(listener);
    }

    public void OnPlayerPointChanges(string userId, string pointChange)
    {
        foreach (IOnPlayerPointChange listener in onPlayerPointChanges)
        {
            listener.OnPlayerPointChange(userId, pointChange);
        }
    }
}

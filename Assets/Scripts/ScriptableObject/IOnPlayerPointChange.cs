using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOnPlayerPointChange
{
    public void OnPlayerPointChange(string userId, string pointAdd);
}

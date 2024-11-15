using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HandleUserDataFunction : Singleton<HandleUserDataFunction>
{
    public abstract void HandleData(string jsondata);
   
}

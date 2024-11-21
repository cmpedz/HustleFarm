using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HandleUserDataFunction : MonoBehaviour
{
    public abstract void HandleData(string jsondata);
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserBag 
{
    public static readonly  string Id = "UserBag";
    public List<string> Items;
    public UserBag() { 
        Items = new List<string>();
    }
}

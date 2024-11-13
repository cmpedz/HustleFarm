using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : Singleton<UserData>
{
    private string userId;
    public string UserId
    {
        get { return this.userId; }
        set { this.userId = value; }
    }
   
}

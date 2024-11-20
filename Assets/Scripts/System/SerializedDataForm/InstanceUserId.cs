using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceUserId : Singleton<InstanceUserId>
{
    private string userId;
    public string UserId
    {
        get { return this.userId; }
        set { this.userId = value; }
    }

   
}

using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceUserGeneralInfors : Singleton<InstanceUserGeneralInfors>
{
    private string userId;
    public string UserId
    {
        get { return this.userId; }
        set { this.userId = value; }
    }

    private string userName;

    public string UserName
    {
        get { return this.userName; }
        set { this.userName = value; }
    }
}

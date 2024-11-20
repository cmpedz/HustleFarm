using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEventDataChange 
{

    public event Action<object> DataChangeEvent;
}

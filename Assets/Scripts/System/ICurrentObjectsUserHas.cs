using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICurrentObjectsUserHas<T>
{
    public List<T> GetObjectsHas();
}

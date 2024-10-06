using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectData", menuName = "ScriptableObject/ObjectData")]
public class ObjectData : ScriptableObject
{
    [SerializeField] public Sprite sprite;

    [SerializeField] public string name;
}

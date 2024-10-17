using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlantData", menuName = "ScriptableObject/ObjectData/ObjectData")]
public class ObjectData : ScriptableObject
{
    [SerializeField] public Sprite sprite;

    [SerializeField] public string name;
}

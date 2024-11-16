using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionBarEnableSystem : MonoBehaviour
{
    [SerializeField] private List<FunctionBarController.EFunctionName> enabledFunctions = 
        new List<FunctionBarController.EFunctionName> ();
    void Start()
    {
        FunctionBarController.Instance.EnableFunctions(enabledFunctions, true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

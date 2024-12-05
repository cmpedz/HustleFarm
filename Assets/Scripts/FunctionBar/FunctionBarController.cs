using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static FunctionBarController;

public class FunctionBarController : Singleton<FunctionBarController>
{
    public enum EFunctionName
    {
        Move_To_Garden,
        Move_To_Animal,
        Zoom_In,
        Zoom_out,
        Go_Back_Home,
        User_Bag,
        Terminate_Function,
        Gacha,
        Shovel,
        LeaderBoard
    }

    [System.Serializable]
    public class FunctionsInFunctionBar
    {
        public EFunctionName name;
        public GameObject function;
    }

    [SerializeField] private List<FunctionsInFunctionBar> functions = new List<FunctionsInFunctionBar>();

    public void EnableFunctions(List<EFunctionName> eFunctionsName, bool isActive)
    {
        foreach (FunctionsInFunctionBar function in functions) {
            if (eFunctionsName.Contains(function.name)) { 
                function.function.SetActive(isActive);
            }
            else
            {
                function.function.SetActive(!isActive);
            }
        }
    }


    public GameObject GetFunctionByName(EFunctionName name) {
        foreach (FunctionsInFunctionBar function in functions)
        {
            if (function.name.Equals(name)) {
                return function.function;
            }
        }

        return null;
    }
}

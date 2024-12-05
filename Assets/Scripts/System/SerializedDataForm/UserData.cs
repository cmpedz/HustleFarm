using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData 
{   
   public string UserId = InstanceUserGeneralInfors.Instance.UserId;

   public UserBag UserBag { get; set; }

   public UserInfors UserInfors { get; set; }

   public UserPlants UserPlants { get; set; }

   public UserAnimals UserAnimals { get; set; }

   private Dictionary<Type, object> userDatasStorage;

   public T GetDataRelyOnDataType<T>()
    {
        if (userDatasStorage.ContainsKey(typeof(T)))
        {
            return (T)userDatasStorage[typeof(T)];   
        }

        return default;
    }

    public void SetDataRelyOnDataType(Type type, object model)
    {
        userDatasStorage[type] = model;
        
    }

    public UserData() {

        userDatasStorage = new Dictionary<Type, object>();
        
        userDatasStorage.Add(typeof(UserInfors), this.UserInfors);

        userDatasStorage.Add(typeof(UserBag), this.UserBag);

        userDatasStorage.Add(typeof(UserPlants), this.UserPlants);

        userDatasStorage.Add(typeof(UserAnimals), this.UserAnimals);
    }

    public string ConvertToJson()
    {
        this.UserBag = GetDataRelyOnDataType<UserBag>();

        this.UserInfors = GetDataRelyOnDataType<UserInfors>();

        this.UserPlants = GetDataRelyOnDataType<UserPlants>();

        this.UserAnimals = GetDataRelyOnDataType<UserAnimals>();

        return JsonConvert.SerializeObject(this);

    }

}

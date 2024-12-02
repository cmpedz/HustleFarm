﻿
using HustleFarmServer.Controllers.Model.UserDataForm;

namespace HustleFarmServer.Controllers.Model
{
    public class UserAccountBagDataManager : UserAccountDataManager
    {
        public UserAccountBagDataManager() : base(KeysDataFB.EKeysDataFB.UserBag)
        {
        }

        protected override void ConstructInitialData(Dictionary<string, object> initialData, IntitialUserInfors intitialUserInfors)
        {
            List<string> initialItem = new List<string>(){

                KeyItemsInBag.GetItemInBag(KeyItemsInBag.EKeyItemsInBag.Seed_Crop),

                KeyItemsInBag.GetItemInBag(KeyItemsInBag.EKeyItemsInBag.Food_Crop),

                KeyItemsInBag.GetItemInBag(KeyItemsInBag.EKeyItemsInBag.Food_Rice),

                KeyItemsInBag.GetItemInBag(KeyItemsInBag.EKeyItemsInBag.Seed_Rice)};

                

        initialData.Add(UserBag.ItemsField, initialItem);
        }

        
    }
}

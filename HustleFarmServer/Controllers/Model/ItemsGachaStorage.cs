using System.Collections.Generic;

namespace HustleFarmServer.Controllers.Model
{
    public class ItemsGachaStorage
    {
        private Dictionary<string, List<object>>? gachaItemsDictionary;

        private Dictionary<string, List<string>>? checkItemExistFlag; 

        public Dictionary<string, List<object>>? GachaItemsDictionary {
            get { return gachaItemsDictionary; }
        }
        public Dictionary<string, List<string>>? CheckItemExistFlag
        {
            get { return checkItemExistFlag; }
        }


        private static ItemsGachaStorage? instance;


        private ItemsGachaStorage() {

            gachaItemsDictionary = [];

            checkItemExistFlag = [];
        }

        public void AddNewItemGachaIntoStorage(string typeItemGet, Dictionary<string, object> itemGet) {

            string keyItemId = KeysDataFB.GetKeysDataFB(KeysDataFB.EKeysDataFB.Id);

            itemGet.TryGetValue(keyItemId, out var itemId);

            if (checkItemExistFlag == null || itemId == null || gachaItemsDictionary == null) return;


            if (gachaItemsDictionary.TryGetValue(typeItemGet, out List<object>? itemsGetInSpecifiedType)) {

                if (checkItemExistFlag.TryGetValue(typeItemGet, out List<string>? itemsId)) {

                    if (!itemsId.Contains(itemId)) {

                        itemsGetInSpecifiedType.Add(itemGet);

                        itemsId.Add((string)itemId);
                    }

                   

                }
            }
            else
            {
                gachaItemsDictionary.Add(typeItemGet, []);

                gachaItemsDictionary[typeItemGet].Add(itemGet);

                checkItemExistFlag.Add(typeItemGet, []);

                checkItemExistFlag[typeItemGet].Add((string)itemId);

            }
        }


        public static ItemsGachaStorage GetInstance() {

            if (instance == null) { 
                instance = new ItemsGachaStorage(); 
            }

            return instance;    
        }

    }
}

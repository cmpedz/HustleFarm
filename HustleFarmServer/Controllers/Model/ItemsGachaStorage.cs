using System.Collections.Generic;

namespace HustleFarmServer.Controllers.Model
{
    public class ItemsGachaStorage
    {
        private Dictionary<string, List<object>>? gachaItemsDictionary;

        private static ItemsGachaStorage? instance;


        private ItemsGachaStorage() {

            gachaItemsDictionary = [];
        }

        public void AddNewItemGachaIntoStorage(string typeItemGet,  object itemGet) {

            if(gachaItemsDictionary == null) return;

            if (gachaItemsDictionary.TryGetValue(typeItemGet, out List<object>? itemsGetInSpecifiedType)) {

                if (!itemsGetInSpecifiedType.Contains(itemGet)) { 

                    itemsGetInSpecifiedType.Add(itemGet);

                  
                }
            }
            else
            {
                gachaItemsDictionary.Add(typeItemGet, []);

                gachaItemsDictionary[typeItemGet].Add(itemGet);

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

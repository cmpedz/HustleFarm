using System.Collections.Generic;

namespace HustleFarmServer.Controllers.Model
{
    public class ItemsGachaStorage
    {
        private Dictionary<string, List<object>>? gachaItemsDictionary;

        private SortedDictionary<string, float>? gachaItemsRate;
        public SortedDictionary<string, float>? GachaItemsRate { get { return gachaItemsRate;  } }

        private static ItemsGachaStorage? instance;

        public static readonly string ITEM_GACHA_RATE = "GachaRate";

        private ItemsGachaStorage() {

            gachaItemsDictionary = [];

            gachaItemsRate = [];
        }

        public void AddNewItemGachaIntoStorage(string typeItemGet,  object itemGet) {

            if(gachaItemsDictionary == null) return;

            if (gachaItemsDictionary.TryGetValue(typeItemGet, out List<object>? itemsGetInSpecifiedType)) {

                if (!itemsGetInSpecifiedType.Contains(itemGet)) { 

                    itemsGetInSpecifiedType.Add(itemGet);

                    AddItemRateIntoStorage(typeItemGet, itemGet);
                }
            }
            else
            {
                gachaItemsDictionary.Add(typeItemGet, []);

                gachaItemsDictionary[typeItemGet].Add(itemGet);

                AddItemRateIntoStorage(typeItemGet, itemGet);
            }
        }

        private void AddItemRateIntoStorage(string typeItemGet, object item) {

               if( gachaItemsRate == null || item.GetType() != typeof(Dictionary<string, object>) 
                || gachaItemsRate.ContainsKey(typeItemGet)) return;

                Dictionary<string, object> _item = (Dictionary<string, object>) item;

                if (!_item.TryGetValue(ITEM_GACHA_RATE, out var rate)) return;

                gachaItemsRate.Add(typeItemGet, (float)rate);
            
        }

        public static ItemsGachaStorage GetInstance() {

            if (instance == null) { 
                instance = new ItemsGachaStorage(); 
            }

            return instance;    
        }

    }
}

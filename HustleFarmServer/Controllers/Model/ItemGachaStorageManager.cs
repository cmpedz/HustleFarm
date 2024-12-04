using Google.Cloud.Firestore;

namespace HustleFarmServer.Controllers.Model
{
    public class ItemGachaStorageManager
    {
        private FirestoreDb? firestoreDb;


        private ItemsGachaStorage itemsGachaStorage = ItemsGachaStorage.GetInstance();

        private static ItemGachaStorageManager? instance;

        private ItemGachaStorageManager() {
            GetItemsGachaFromFireBaseAsync().Wait();
        }
        public async Task GetItemsGachaFromFireBaseAsync()
        {

            List<Dictionary<string, object>> itemsGachaDataList = await
                RetrieveGameObjectDataFromServer.Instance.GetItemsGachaFromFireBaseAsync(KeysDataFB.EKeysDataFB.Plants);

            foreach(Dictionary<string, object> itemGachaDataDictionary in itemsGachaDataList )
            {
                AddNewItemIntoItemsGachaStorage(itemGachaDataDictionary);
            }


        }


        private void AddNewItemIntoItemsGachaStorage(Dictionary<string, object> itemDatas) {

                string keyItemType = KeysDataFB.GetKeysDataFB(KeysDataFB.EKeysDataFB.Type);

                if (itemDatas.TryGetValue(keyItemType, out var itemType)) {

                    itemsGachaStorage.AddItemGachaDataIntoStorage((string)itemType, itemDatas);

                }
            
        }

        
        public static ItemGachaStorageManager GetInstance() { 

            if(instance == null)
            {
                instance = new ItemGachaStorageManager();
            }

            return instance;
        }


    }

}

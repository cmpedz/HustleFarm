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

            firestoreDb = FireStoreController.GetInstace().FireStoreDb;

            string keyPlants = KeysDataFB.GetKeysDataFB(KeysDataFB.EKeysDataFB.Plants);

            Query gachaItemsQuery = firestoreDb.Collection(keyPlants);

            QuerySnapshot gachaItemsQuerySnapShot = await gachaItemsQuery.GetSnapshotAsync();

            foreach (DocumentSnapshot gachaItemDocumentSnapShot in gachaItemsQuerySnapShot.Documents)
            {

                if (gachaItemDocumentSnapShot != null)
                {
                    Dictionary<string, object> itemGachaDataDictionary = [];

                    await FormatItemGachaDataToDictionary(gachaItemDocumentSnapShot, itemGachaDataDictionary);

                    AddNewItemIntoItemsGachaStorage(itemGachaDataDictionary);
                }
            }


        }

        private void AddNewItemIntoItemsGachaStorage(Dictionary<string, object> itemDatas) {

                string keyItemType = KeysDataFB.GetKeysDataFB(KeysDataFB.EKeysDataFB.Type);

                if (itemDatas.TryGetValue(keyItemType, out var itemType)) {

                    itemsGachaStorage.AddNewItemGachaIntoStorage((string)itemType, itemDatas);

                }
            
        }

        private async Task FormatItemGachaDataToDictionary(DocumentSnapshot itemGachaData, Dictionary<string, object> itemGachaDataDictionary)
        {

            if (itemGachaData == null) return;

            foreach (KeyValuePair<string, object> pair in itemGachaData.ToDictionary())
            {

                if (pair.Value.GetType() == typeof(DocumentReference))
                {

                    DocumentReference documentReference = (DocumentReference)pair.Value;

                    DocumentSnapshot documentSnapshot = await documentReference.GetSnapshotAsync();

                    await FormatItemGachaDataToDictionary(documentSnapshot, itemGachaDataDictionary);
                }
                else
                {
                    itemGachaDataDictionary.Add(pair.Key, pair.Value);
                }

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

using Google.Cloud.Firestore;

namespace HustleFarmServer.Controllers.Model
{
    public class ItemGachaStorageManager
    {
        private FirestoreDb? firestoreDb;

        private const string NAME_COLLECTION_GET = "Plants";

        private const string TYPE_ITEM_GACHA = "Type";

        private ItemsGachaStorage itemsGachaStorage = ItemsGachaStorage.GetInstance();

        private static ItemGachaStorageManager? instance;
        public async Task GetItemsGachaFromFireBaseAsync()
        {

            firestoreDb = FireStoreController.GetInstace().FireStoreDb;

            Query gachaItemsQuery = firestoreDb.Collection(NAME_COLLECTION_GET);

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

            

                if (itemDatas.TryGetValue(TYPE_ITEM_GACHA, out var itemType)) {

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

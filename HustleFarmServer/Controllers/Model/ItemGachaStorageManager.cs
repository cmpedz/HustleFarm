using Google.Cloud.Firestore;

namespace HustleFarmServer.Controllers.Model
{
    public class ItemGachaStorageManager
    {
        private FirestoreDb? firestoreDb;

        private const string NAME_COLLECTION_GET = "Plants";

        private ItemsGachaStorage itemsGachaStorage = ItemsGachaStorage.GetInstance();
        private async Task GetItemsGachaFromFireBaseAsync()
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


                }
            }


        }

        private void AddNewItemIntoItemsGachaStorage(Dictionary<string, object> itemDatas) {

            if (itemDatas.TryGetValue(ItemsGachaStorage.ITEM_GACHA_RATE, out var rate)) { 
                
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


    }

}

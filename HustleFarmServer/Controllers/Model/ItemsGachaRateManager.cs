using Google.Cloud.Firestore;

namespace HustleFarmServer.Controllers.Model
{
    public class ItemsGachaRateManager
    {
        private Dictionary<string, int[]> itemsGachaTypeRange = [];

        public Dictionary<string, int[]> ItemsGachaTypeRange
        {
            get { return itemsGachaTypeRange; }
        }

        private FireStoreController firestoreDbController = FireStoreController.GetInstace();

        private static ItemsGachaRateManager? instance;

        private ItemsGachaRateManager(){

            GetRateOfEachTypeFromFB().Wait();
           

        }

        public static ItemsGachaRateManager GetInstance() {

            if (instance == null) {
                instance = new ItemsGachaRateManager();
            }

            return instance;
        }
        private async Task GetRateOfEachTypeFromFB() {

            string keyGameItemType = KeysDataFB.GetKeysDataFB(KeysDataFB.EKeysDataFB.GameItemType);

            Query itemsGachaRateQuery = firestoreDbController.FireStoreDb.Collection(keyGameItemType);

            QuerySnapshot itemsGachaRateQuerySnapShots = await itemsGachaRateQuery.GetSnapshotAsync();

            int startBorder = 0;

            int sumQuantitiesCase = 10000;

            foreach (DocumentSnapshot itemsRateDcSnapShot in itemsGachaRateQuerySnapShots.Documents) {

                Dictionary<string, object> itemsRateToDictionary = itemsRateDcSnapShot.ToDictionary();

                string keyItemType = KeysDataFB.GetKeysDataFB(KeysDataFB.EKeysDataFB.Type);

                if (itemsRateToDictionary.TryGetValue(keyItemType, out var type)) {

                    string keyGachaRate = KeysDataFB.GetKeysDataFB(KeysDataFB.EKeysDataFB.GachaRate);

                    if (itemsRateToDictionary.TryGetValue(keyGachaRate, out var rate))
                    {

                        int lastBorder = (int)((double)rate * sumQuantitiesCase) + startBorder;

                        itemsGachaTypeRange.Add((string)type, [startBorder, lastBorder]);

                        startBorder = lastBorder;
                    }

                }

                

            }

          
        }
    }
}

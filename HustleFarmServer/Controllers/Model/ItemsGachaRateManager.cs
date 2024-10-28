using Google.Cloud.Firestore;

namespace HustleFarmServer.Controllers.Model
{
    public class ItemsGachaRateManager
    {
        private Dictionary<string, int[]> itemsGachaRateRange = [];

        public Dictionary<string, int[]> ItemsGachaRateRange
        {
            get { return itemsGachaRateRange; }
        }

        private FireStoreController firestoreDbController = FireStoreController.GetInstace();

        private static ItemsGachaRateManager? instance;

        public static readonly int MAX_RANGE = 10000;

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

            int sumQuantitiesCase = MAX_RANGE;

            foreach (DocumentSnapshot itemsRateDcSnapShot in itemsGachaRateQuerySnapShots.Documents) {

                Dictionary<string, object> itemsRateToDictionary = itemsRateDcSnapShot.ToDictionary();

                string keyItemType = KeysDataFB.GetKeysDataFB(KeysDataFB.EKeysDataFB.Type);

                if (itemsRateToDictionary.TryGetValue(keyItemType, out var type)) {

                    string keyGachaRate = KeysDataFB.GetKeysDataFB(KeysDataFB.EKeysDataFB.GachaRate);

                    if (itemsRateToDictionary.TryGetValue(keyGachaRate, out var rate))
                    {

                        int lastBorder = (int)((double)rate * sumQuantitiesCase) + startBorder;

                        itemsGachaRateRange.Add((string)type, [startBorder, lastBorder]);

                        startBorder = lastBorder;
                    }

                }

                

            }

          
        }
    }
}

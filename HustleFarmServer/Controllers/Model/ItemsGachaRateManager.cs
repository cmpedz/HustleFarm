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

        private static readonly string COLLECTIONS_NAME = "GameItemType";

        public static readonly string ITEM_GACHA_RATE = "GachaRate";

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

            Query itemsGachaRateQuery = firestoreDbController.FireStoreDb.Collection(COLLECTIONS_NAME);

            QuerySnapshot itemsGachaRateQuerySnapShots = await itemsGachaRateQuery.GetSnapshotAsync();

            int startBorder = 0;

            int sumQuantitiesCase = 10000;

            foreach (DocumentSnapshot itemsRateDcSnapShot in itemsGachaRateQuerySnapShots.Documents) {

                Dictionary<string, object> itemsRateToDictionary = itemsRateDcSnapShot.ToDictionary();

                if (itemsRateToDictionary.TryGetValue("Type", out var type)) {

                    if (itemsRateToDictionary.TryGetValue(ITEM_GACHA_RATE, out var rate))
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

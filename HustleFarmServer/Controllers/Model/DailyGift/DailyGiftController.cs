using Google.Cloud.Firestore;
using HustleFarmServer.Controllers.Model.UserDataForm;

namespace HustleFarmServer.Controllers.Model.DailyGift
{
    public class DailyGiftController
    {

        private FirestoreDb firestoreDb = FireStoreSetup.GetInstace().FireStoreDb;

        private static DailyGiftController? instance;

        public static DailyGiftController? Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new DailyGiftController();
                }

                return instance;
            }
        }

        private CollectionReference dailyGiftsCollections;

        private DailyGiftController()
        {
            this.dailyGiftsCollections = firestoreDb.Collection(KeysDataFB.GetKeysDataFB(KeysDataFB.EKeysDataFB.DailyGifts));
        }

        public async void AddingUserIntoDailyGifts(string userId)
        {

            // Check if the document exists
            DocumentSnapshot docSnapshot = await dailyGiftsCollections.Document(userId).GetSnapshotAsync();

            if (!docSnapshot.Exists)
            {
                Dictionary<string, object> user = new Dictionary<string, object>()
                 {
                     { "IsRetrieved" , false}
                 };

                await dailyGiftsCollections.Document(userId).SetAsync(user);
            }


        }

        public async Task<bool> didUserReceivedDailyGifts(string userId)
        {
            DocumentSnapshot userStatus = await this.dailyGiftsCollections.Document(userId).GetSnapshotAsync();

            Dictionary<string, object> userStatusToDic = userStatus.ToDictionary();

            if(userStatusToDic.TryGetValue(UserDailyGiftStatus.STATUS_FIELD, out var status))
            {
                bool isReceived = (bool)status;

                return isReceived;
            }

            return true;

        }

    }
}

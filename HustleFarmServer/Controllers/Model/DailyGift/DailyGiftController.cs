using Google.Cloud.Firestore;
using HustleFarmServer.Controllers.Model.RepeatedTask;
using HustleFarmServer.Controllers.Model.UserDataForm;

namespace HustleFarmServer.Controllers.Model.DailyGift
{
    public class DailyGiftController : IOnAccountCreatedEvent
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
                     { "IsReceived" , false}
                 };

                await dailyGiftsCollections.Document(userId).SetAsync(user);
            }


        }

        public async void ChangeDailyGiftReceivedStatus(string userId, bool status)
        {
            Dictionary<string, object> newStatus = new Dictionary<string, object>()
            {
                     { "IsReceived" , status}
            };

            await dailyGiftsCollections.Document(userId).UpdateAsync(newStatus);

        }

        public async void ResetDailyGift()
        {
            QuerySnapshot usersQuerySnapShot = await dailyGiftsCollections.GetSnapshotAsync();

            List<Task> resetDailyStatusTasks = new List<Task>();

            foreach (DocumentSnapshot user in usersQuerySnapShot.Documents) {

                DocumentReference userRef = user.Reference;

                Dictionary<string, object> resetStatus = new Dictionary<string, object>()
                {
                    { UserDailyGiftStatus.STATUS_FIELD, false}
                };

                resetDailyStatusTasks.Add(userRef.UpdateAsync(resetStatus));
            }

            await Task.WhenAll(resetDailyStatusTasks);
        }

        public async Task<bool> IsUserReceivedDailyGifts(string userId)
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

        public void OnAccountCreated(string userId)
        {
            AddingUserIntoDailyGifts(userId);
        }
    }
}

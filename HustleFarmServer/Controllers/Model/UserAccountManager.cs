using Google.Cloud.Firestore;
using System.Text.Json;


namespace HustleFarmServer.Controllers.Model
{
    public class UserAccountManager
    {
        private readonly string USERS_COLLECTIONS = KeysDataFB.GetKeysDataFB(KeysDataFB.EKeysDataFB.Users);

        private FirestoreDb firestoreDb;

        private CollectionReference usersCollections;

        private readonly string  USERS_DATA_COLLECTIONS = KeysDataFB.GetKeysDataFB(KeysDataFB.EKeysDataFB.UserData);

        private CollectionReference userDataCollection;

        private List<UserAccountDataManager> userDatasManager = new List<UserAccountDataManager>();

        public UserAccountManager()
        {
            this.firestoreDb =FireStoreController.GetInstace().FireStoreDb;

            this.usersCollections = firestoreDb.Collection(USERS_COLLECTIONS);

            userDatasManager.Add(new UserAccountBagDataManager());

            userDatasManager.Add(new UserAccountInforsManager());

        }
        public async Task<string> CreateAccount(string userId)
        {

            DocumentReference user = this.usersCollections.Document(userId);

            this.userDataCollection = user.Collection(USERS_DATA_COLLECTIONS);

            QuerySnapshot documentSnapshots = await userDataCollection.GetSnapshotAsync();

            bool isAccountCreated = documentSnapshots.Documents.Count > 0;

            if (isAccountCreated)
            {
                return GetUserData().Result;
            }

            List<Task> taskExecuted = new List<Task>(); 

            foreach(var userDataManager in userDatasManager)
            {
                taskExecuted.Add(userDataManager.SetUpData(userDataCollection));
            }

            await Task.WhenAll(taskExecuted);

            return GetUserData().Result;

        }


        public async Task<string> GetUserData()
        {
            Dictionary<string, string> userDatasDicionary = new Dictionary<string, string>();

            List<Task> tasksRetrievedUserData = new List<Task>();

            foreach(UserAccountDataManager userDataManager in userDatasManager)
            {
                Task getUserDataTask = Task.Run(() =>
                {

                    KeyValuePair<string, string> userDataRetrieved = userDataManager.GetUserData(this.userDataCollection).Result;

                    userDatasDicionary.Add(userDataRetrieved.Key, userDataRetrieved.Value);
                }
                );

                tasksRetrievedUserData.Add(getUserDataTask);
            }

            await Task.WhenAll(tasksRetrievedUserData);

            return JsonSerializer.Serialize(userDatasDicionary, new JsonSerializerOptions());
        }
    }
}

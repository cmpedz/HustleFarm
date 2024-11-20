using Google.Cloud.Firestore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;



namespace HustleFarmServer.Controllers.Model
{
    public class UserAccountManager
    {
        private readonly string USERS_COLLECTIONS = KeysDataFB.GetKeysDataFB(KeysDataFB.EKeysDataFB.Users);

        private FirestoreDb firestoreDb;

        private CollectionReference usersCollections;

        private readonly string  USERS_DATA_COLLECTIONS = KeysDataFB.GetKeysDataFB(KeysDataFB.EKeysDataFB.UserData);

        private CollectionReference userDataCollection;

        private Dictionary<string, UserAccountDataManager> userDatasManagerDictionary = new Dictionary<string, UserAccountDataManager>();

        public UserAccountManager(string userId)
        {
            this.firestoreDb =FireStoreController.GetInstace().FireStoreDb;

            this.usersCollections = firestoreDb.Collection(USERS_COLLECTIONS);

            userDatasManagerDictionary.Add(KeysDataFB.EKeysDataFB.UserBag.ToString(),new UserAccountBagDataManager());

            userDatasManagerDictionary.Add(KeysDataFB.EKeysDataFB.UserInfors.ToString(), new UserAccountInforsManager());

            userDatasManagerDictionary.Add(KeysDataFB.EKeysDataFB.UserPlants.ToString(), new UserAccountPlantsDataManager());

            DocumentReference user = this.usersCollections.Document(userId);

            this.userDataCollection = user.Collection(USERS_DATA_COLLECTIONS);

        }
        public async Task<string> CreateAccount()
        {

            QuerySnapshot documentSnapshots = await userDataCollection.GetSnapshotAsync();

            bool isAccountCreated = documentSnapshots.Documents.Count > 0;

            if (isAccountCreated)
            {
                return GetUserData().Result;
            }

            List<Task> taskExecuted = new List<Task>(); 

            foreach(string userDataManagerKey in userDatasManagerDictionary.Keys)
            {

                taskExecuted.Add(userDatasManagerDictionary[userDataManagerKey].SetUpData(this.userDataCollection));
            }

            await Task.WhenAll(taskExecuted);

            return GetUserData().Result;

        }

        public async Task UpdateUsersDataToServer(string jsonData)
        {
            JObject userDatas = JObject.Parse(jsonData);

            List<Task> tasksUpdatedData = new List<Task>();

            foreach(var userDataType in userDatas)
            {
                 foreach(string userDataManagerKey in userDatasManagerDictionary.Keys)
                {
                    if(userDataManagerKey == userDataType.Key)
                    {
                        Task taskUpdate = Task.Run(() =>
                        {
                               string dataToJson = JsonConvert.SerializeObject(userDataType.Value);

                                
                               userDatasManagerDictionary[userDataManagerKey].UpdateUSerData(dataToJson, this.userDataCollection).Wait();
                               
                        });

                        tasksUpdatedData.Add(taskUpdate);
                        
                        break;
                    }
                }
            }

            await Task.WhenAll(tasksUpdatedData);
        }



        public async Task<string> GetUserData()
        {
            Dictionary<string, string> userDatasDicionary = new Dictionary<string, string>();

            List<Task> tasksRetrievedUserData = new List<Task>();

            foreach(string userDataManagerKey in userDatasManagerDictionary.Keys)
            {
                Task getUserDataTask = Task.Run(() =>
                {
                    UserAccountDataManager userDataManager = userDatasManagerDictionary[userDataManagerKey];

                    KeyValuePair<string, string> userDataRetrieved = userDataManager.GetUserData(this.userDataCollection).Result;

                    userDatasDicionary.Add(userDataRetrieved.Key, userDataRetrieved.Value);
                }
                );

                tasksRetrievedUserData.Add(getUserDataTask);
            }

            await Task.WhenAll(tasksRetrievedUserData);

            return JsonConvert.SerializeObject(userDatasDicionary);
        }
    }
}

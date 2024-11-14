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

        public UserAccountManager()
        {
               this.firestoreDb =FireStoreController.GetInstace().FireStoreDb;

               this.usersCollections = firestoreDb.Collection(USERS_COLLECTIONS);

        }
        public async Task<string> CreateAccount(string userId)
        {

            DocumentReference user = this.usersCollections.Document(userId);

            CollectionReference userData = user.Collection(USERS_DATA_COLLECTIONS);

            QuerySnapshot documentSnapshots = await userData.GetSnapshotAsync();

            bool isAccountCreated = documentSnapshots.Documents.Count > 0;

            if (isAccountCreated)
            {
                return GetUserData(userId).Result;
            }



            await Task.WhenAll([SetUpDataForUserBags(userData), SetUpDataForUserInfors(userData)]);

            return GetUserData(userId).Result;

        }

        private async Task SetUpDataForUserInfors(CollectionReference userData)
        {
            string userBagDocuments = KeysDataFB.GetKeysDataFB(KeysDataFB.EKeysDataFB.UserBag);

            List<string> initialItem = new List<string>(){ 

                KeyItemsInBag.GetItemInBag(KeyItemsInBag.EKeyItemsInBag.Seed_Crop),

                KeyItemsInBag.GetItemInBag(KeyItemsInBag.EKeyItemsInBag.Seed_Rice)};

            Dictionary<string, object> data = new Dictionary<string, object>()
            {
                { "Items",  initialItem}
            };

            await userData.Document(userBagDocuments).SetAsync(data);
        }

        private async Task SetUpDataForUserBags(CollectionReference userData)
        {
            string userInforsDocuments = KeysDataFB.GetKeysDataFB(KeysDataFB.EKeysDataFB.UserInfors);

            Dictionary<string, object> data = new Dictionary<string, object>()
            {
                { "test" , 1}
            };

            await userData.Document(userInforsDocuments).SetAsync(data);



        }

        public async Task<string> GetUserData(string userId)
        {
            Dictionary<string, string> userDatasDicionary = new Dictionary<string, string>();

            QuerySnapshot userDatasQuery = await this.usersCollections.Document(userId).Collection(USERS_DATA_COLLECTIONS).GetSnapshotAsync();

            foreach(DocumentSnapshot userData in userDatasQuery)
            {
                string userDataToJson = JsonSerializer.Serialize(userData.ToDictionary(), new JsonSerializerOptions());

                userDatasDicionary.Add(userData.Id, userDataToJson);
            }

            return JsonSerializer.Serialize(userDatasDicionary, new JsonSerializerOptions());
        }
    }
}

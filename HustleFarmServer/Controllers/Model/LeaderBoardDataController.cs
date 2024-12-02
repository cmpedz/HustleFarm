using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using HustleFarmServer.Controllers.Model.UserDataForm;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections;
using System.Reflection.Metadata;

namespace HustleFarmServer.Controllers.Model
{
   
    public class LeaderBoardDataController
    {
        private FirestoreDb firestoreDb = FireStoreController.GetInstace().FireStoreDb;

        private static LeaderBoardDataController? instance;

        private CollectionReference leaderBoardCollection;
        public CollectionReference LeaderBoardCollection
        {
            get { return this.leaderBoardCollection; }
        }

        private static readonly int MAX_HIGHEST_USERS_DISPLAYED = 100;

        private string documentPointField;
        public string DocumentPointField
        {
            get { return this.documentPointField; }
        }

        private string documentNameField;


        public static LeaderBoardDataController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LeaderBoardDataController();
                }
                return instance;
            }

        }

        private LeaderBoardDataController()
        {

            string collectionName = KeysDataFB.GetKeysDataFB(KeysDataFB.EKeysDataFB.LeaderBoard);

            leaderBoardCollection = firestoreDb.Collection(collectionName);

            documentPointField = KeysDataFB.GetKeysDataFB(KeysDataFB.EKeysDataFB.Point);

            documentNameField = KeysDataFB.GetKeysDataFB(KeysDataFB.EKeysDataFB.UserName);

        }

        public async void AddingUserIntoLeaderBoard(string userId, string userName)
        {

            // Check if the document exists
            DocumentSnapshot docSnapshot = await leaderBoardCollection.Document(userId).GetSnapshotAsync();

            if (!docSnapshot.Exists)
            {
                Dictionary<string, object> user = new Dictionary<string, object>()
                 {
                     { "UserName" , userName},

                     { "Point" , 0}

                
                 };

                await leaderBoardCollection.Document(userId).SetAsync(user);
            }
           

           

            
        }

        public async void IncreaseUserPoint(string userId, int point)
        {
            await leaderBoardCollection.Document(userId).UpdateAsync(documentPointField, FieldValue.Increment(point));
        }


        public async Task<string> GetSortedHighestUsers()
        {
            

            Query someHighestScoreUsers = leaderBoardCollection.OrderByDescending(documentPointField).Limit(MAX_HIGHEST_USERS_DISPLAYED);

            QuerySnapshot leaderBoardUsers = await someHighestScoreUsers.GetSnapshotAsync();

            List<UserPointDataSend> sortedLeaderBoardUsers = new List<UserPointDataSend>();

            foreach (DocumentSnapshot user in leaderBoardUsers.Documents)
            {
                UserPointDataSend userPoint = new UserPointDataSend()
                {
                    Name = user.ToDictionary()[documentNameField].ToString(),

                    Point = int.Parse(user.ToDictionary()[documentPointField].ToString())
                };

                sortedLeaderBoardUsers.Add(userPoint);
            }

            return JsonConvert.SerializeObject(sortedLeaderBoardUsers);
        }
        

       
    }
}

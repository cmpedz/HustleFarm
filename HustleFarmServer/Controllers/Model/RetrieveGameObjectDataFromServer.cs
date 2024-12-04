using Google.Cloud.Firestore;
using System.Collections.Generic;

namespace HustleFarmServer.Controllers.Model
{
    public class RetrieveGameObjectDataFromServer
    {
        private FirestoreDb firestoreDb = FireStoreSetup.GetInstace().FireStoreDb;

        private static RetrieveGameObjectDataFromServer instance;
        public static RetrieveGameObjectDataFromServer Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new RetrieveGameObjectDataFromServer();
                }

                return instance;
            }
        }

        private RetrieveGameObjectDataFromServer() { }

        public async Task<List<Dictionary<string, object>>> GetItemsGachaFromFireBaseAsync(KeysDataFB.EKeysDataFB collectionKey)
        {

            List < Dictionary<string, object> > gameObjectsDataList = new List<Dictionary<string, object>> ();

            string collectionPath = KeysDataFB.GetKeysDataFB(collectionKey);

            Query gameObjectsQuery = firestoreDb.Collection(collectionPath);

            QuerySnapshot gameObjectsQuerySnapShot = await gameObjectsQuery.GetSnapshotAsync();

            foreach (DocumentSnapshot gameObjectDocument in gameObjectsQuerySnapShot.Documents)
            {

                if (gameObjectDocument != null)
                {
                    Dictionary<string, object> gameObjectData = [];

                    await RetrieveGameObjectData(gameObjectDocument, gameObjectData);

                    gameObjectsDataList.Add(gameObjectData);
                }
            }

            return gameObjectsDataList;
        }

        private async Task RetrieveGameObjectData(DocumentSnapshot gameObjectDocument, Dictionary<string, object> gameObjectData)
        {

            if (gameObjectDocument == null) return;

            foreach (KeyValuePair<string, object> pair in gameObjectDocument.ToDictionary())
            {

                gameObjectData.Add(pair.Key, pair.Value);
            }


        }

    }
}

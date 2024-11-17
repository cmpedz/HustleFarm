using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using System.Text.Json;

namespace HustleFarmServer.Controllers.Model
{
    public abstract class UserAccountDataManager
    {
        private KeysDataFB.EKeysDataFB documentId;

        public UserAccountDataManager(KeysDataFB.EKeysDataFB documentId)
        {
            this.documentId = documentId;
        }

        public async Task SetUpData(CollectionReference userData)
        {

            Dictionary<string, object> initialData = new Dictionary<string, object>();

            ConstructInitialData(initialData);

            await userData.Document(this.documentId.ToString()).SetAsync(initialData);


        }

        protected abstract void ConstructInitialData(Dictionary<string, object> initialData);

        public async Task<KeyValuePair<string, string>> GetUserData(CollectionReference userData)
        {
            DocumentReference dataRetrieved = userData.Document(this.documentId.ToString());

            DocumentSnapshot dataSnapShot = await dataRetrieved.GetSnapshotAsync();

            string dataToJson = JsonSerializer.Serialize(dataSnapShot.ToDictionary(), new JsonSerializerOptions());

            return new KeyValuePair<string, string>(this.documentId.ToString(), dataToJson) ;
        }
    

}
}

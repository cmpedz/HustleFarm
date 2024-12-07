using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using HustleFarmServer.Controllers.Model.UserDataForm;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;


namespace HustleFarmServer.Controllers.Model
{
    public abstract class UserAccountDataManager
    {
        private KeysDataFB.EKeysDataFB documentId;

      
        public UserAccountDataManager(KeysDataFB.EKeysDataFB documentId)
        {
            this.documentId = documentId;
        }

        public async Task SetUpData(CollectionReference userData, IntitialUserInfors intitialUserInfors)
        {

            Dictionary<string, object> initialData = new Dictionary<string, object>();

            ConstructInitialData(initialData, intitialUserInfors);

            await userData.Document(this.documentId.ToString()).SetAsync(initialData);


        }

        protected abstract void ConstructInitialData(Dictionary<string, object> initialData, IntitialUserInfors intitialUserInfors);

        public async Task<KeyValuePair<string, string>> GetUserData(CollectionReference userData)
        {
            DocumentReference dataRetrieved = userData.Document(this.documentId.ToString());

            DocumentSnapshot dataSnapShot = await dataRetrieved.GetSnapshotAsync();

            string dataToJson = JsonConvert.SerializeObject(dataSnapShot.ToDictionary(), Formatting.Indented);

            return new KeyValuePair<string, string>(this.documentId.ToString(), dataToJson) ;
        }

        public async Task UpdateUSerData(string newJsonData, CollectionReference userData)
        {

            if (newJsonData == "null" || userData == null || newJsonData == "" || newJsonData == null) return;

            Dictionary<string, object> updatedData = new Dictionary<string, object>();

            JObject newData = JObject.Parse(newJsonData);

            foreach (var newDataKey in newData)
            {
                if(newDataKey.Value.Type == JTokenType.Array)
                {
                    JArray newDataToJArray = JArray.Parse(newDataKey.Value.ToString());

                    object[] newDataToArray = newDataToJArray.ToObject<object[]>();

                    updatedData.Add(newDataKey.Key, newDataToArray);
                }
                else
                {
                    
                    updatedData.Add(newDataKey.Key, newDataKey.Value.ToObject<object>());
                }

               



                }

                await userData.Document(this.documentId.ToString()).UpdateAsync(updatedData);
        }

}
}

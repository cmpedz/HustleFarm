using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Text.Json;



namespace HustleFarmServer.Controllers.Model
{
    [ApiController]

    [Route("[controller]")]

    public class GachaServerController:ControllerBase
    {

        private readonly Dictionary<string, string>? gachaItemsDictionary;

        private FirestoreDb? firestoreDb;

        public GachaServerController() {

            gachaItemsDictionary = new Dictionary<string, string>();


        }
        [HttpGet]
        public IActionResult GiveGachaItemToClientsSide() {

            Task.Run(GetItemsGachaFromFireBaseAsync).Wait();

            if (gachaItemsDictionary == null || gachaItemsDictionary.Count == 0) return Ok("nothing in here");

            return Ok(JsonSerializer.Serialize(gachaItemsDictionary, new JsonSerializerOptions()));
        }

        private async Task GetItemsGachaFromFireBaseAsync() {

            firestoreDb = FireStoreController.GetInstace().FireStoreDb;

            Query gachaItemsQuery = firestoreDb.Collection("Plants");

            QuerySnapshot gachaItemsQuerySnapShot = await gachaItemsQuery.GetSnapshotAsync();

            if (gachaItemsQuerySnapShot == null || gachaItemsDictionary == null) return;

            foreach (DocumentSnapshot gachaItemDocumentSnapShot in gachaItemsQuerySnapShot.Documents) {

                        string gachaItemId = gachaItemDocumentSnapShot.Id;
                    
                        if (!gachaItemsDictionary.ContainsKey(gachaItemId) && gachaItemDocumentSnapShot != null)
                        {
                            string gachaItemDataToJson = TransformItemGachaDataIntoJson(gachaItemDocumentSnapShot);

                            gachaItemsDictionary.Add(gachaItemId, gachaItemDataToJson);
                        }
                    
                     
             }

            
        }

        private string TransformItemGachaDataIntoJson(DocumentSnapshot itemGachaData) {


            Dictionary<string, object> itemGachaDataDictionary = new Dictionary<string, object>();


            FormatItemGachaDataToDictionary(itemGachaData, itemGachaDataDictionary).Wait();

            return JsonSerializer.Serialize(itemGachaDataDictionary, new JsonSerializerOptions());

        }

        private async Task FormatItemGachaDataToDictionary(DocumentSnapshot itemGachaData, Dictionary<string, object> itemGachaDataDictionary) {

            if (itemGachaData == null) return;

            foreach (KeyValuePair<string, object> pair in itemGachaData.ToDictionary() ){

                if (pair.Value.GetType() == typeof(DocumentReference)) {

                    DocumentReference documentReference = (DocumentReference)pair.Value;

                    DocumentSnapshot documentSnapshot = await documentReference.GetSnapshotAsync();

                    await FormatItemGachaDataToDictionary(documentSnapshot, itemGachaDataDictionary);
                }
                else
                {
                    itemGachaDataDictionary.Add(pair.Key, pair.Value);
                }

            }


        }

        
    }
}

using Newtonsoft.Json;

namespace HustleFarmServer.Controllers.Model
{
    public class AnimalDataManager
    {
        private static AnimalDataManager instance;
        public static AnimalDataManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AnimalDataManager();
                }

                return instance;
            }
        }

        private Dictionary<string, object> animalsDataDictionary = new Dictionary<string, object>();

        private AnimalDataManager()
        {
            List<Dictionary<string, object>> animalsDataFromServer = RetrieveGameObjectDataFromServer.Instance
                .GetItemsGachaFromFireBaseAsync(KeysDataFB.EKeysDataFB.Animals).Result;

            

            foreach(Dictionary<string, object> animalData in animalsDataFromServer)
            {
                string animalIdField = KeysDataFB.GetKeysDataFB(KeysDataFB.EKeysDataFB.AnimalId);

                if(animalData.TryGetValue(animalIdField, out object animalId)) {

                    animalsDataDictionary.Add(animalId.ToString(), JsonConvert.SerializeObject(animalData));
                }
                
            }
        }

        public string GetAnimalsData()
        {
            return JsonConvert.SerializeObject(animalsDataDictionary);
        }


    }
}

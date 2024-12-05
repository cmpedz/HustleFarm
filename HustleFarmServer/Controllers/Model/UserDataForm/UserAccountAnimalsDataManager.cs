
namespace HustleFarmServer.Controllers.Model.UserDataForm
{
    public class UserAccountAnimalsDataManager : UserAccountDataManager
    {
        public UserAccountAnimalsDataManager() : base(KeysDataFB.EKeysDataFB.UserAnimals)
        {
        }

        protected override void ConstructInitialData(Dictionary<string, object> initialData, IntitialUserInfors intitialUserInfors)
        {
            
            initialData.Add(UserAnimals.AnimalsField, new List<string>());
        }
    }
}

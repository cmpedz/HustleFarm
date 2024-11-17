
namespace HustleFarmServer.Controllers.Model
{
    public class UserAccountInforsManager : UserAccountDataManager
    {

        public UserAccountInforsManager() : base(KeysDataFB.EKeysDataFB.UserInfors)
        {
        }
        protected override void ConstructInitialData(Dictionary<string, object> initialData)
        {
            
        }
    }
}

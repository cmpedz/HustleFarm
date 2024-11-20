namespace HustleFarmServer.Controllers.Model.UserDataForm
{

    [System.Serializable]
    public class UserBag
    {
        public static readonly string ItemsField = "Items";
        public List<string>? Items { get; set; }
    }
}

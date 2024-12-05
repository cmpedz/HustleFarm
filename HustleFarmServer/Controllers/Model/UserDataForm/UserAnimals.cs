namespace HustleFarmServer.Controllers.Model.UserDataForm
{
    [System.Serializable]
    public class UserAnimals
    {
        public static readonly string AnimalsField = "Animals";
        public List<string>? Animals { get; set; }
    }
}

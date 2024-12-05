namespace HustleFarmServer.Controllers.Model.UserDataForm
{
    [System.Serializable]
    public class UserData
    {
        public string? UserId { get; set; }

        public UserBag? UserBag { get; set; }

        public UserInfors? UserInfors { get; set; }

        public UserPlants? UserPlants { get; set; }

        public UserAnimals? UserAnimals { get; set; }
    }
}

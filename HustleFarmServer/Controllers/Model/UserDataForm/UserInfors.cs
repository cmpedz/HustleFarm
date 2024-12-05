namespace HustleFarmServer.Controllers.Model.UserDataForm
{
    [System.Serializable]
    public class UserInfors
    {
        public static readonly string UserPointField = "UserPoint";

        public static readonly string GachaTicketsField = "GachaTickets";
        public string? UserPoint { get; set; }

        public int? GachaTickets { get; set; }
    }
}

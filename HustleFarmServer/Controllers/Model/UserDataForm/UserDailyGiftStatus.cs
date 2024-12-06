namespace HustleFarmServer.Controllers.Model.UserDataForm
{
    
    public class UserDailyGiftStatus
    {
        public const string STATUS_FIELD = "IsReceived";

        public bool IsReceived { get; set; }

        public string? UserId { get; set; }
    }
}

namespace HustleFarmServer.Controllers.Model
{
    public interface IOnAccountCreatedEvent
    {
        public void OnAccountCreated(string userId);
    }
}

using HustleFarmServer.Controllers.Model.DailyGift;

namespace HustleFarmServer.Controllers.Model
{
    public class OnAccountCreatedEvents
    {
        private List<IOnAccountCreatedEvent> onAccountCreatedEvents = new List<IOnAccountCreatedEvent>();

        private static OnAccountCreatedEvents instance;

        public static OnAccountCreatedEvents Instance
        {
            get {
                if(instance == null)
                {
                    instance = new OnAccountCreatedEvents();
                }

                return instance;
            }
        }

        private OnAccountCreatedEvents() {
            AddListener(DailyGiftController.Instance);
            AddListener(LeaderBoardDataController.Instance);
        }

        public void Invoke(string userId)
        {
            foreach (IOnAccountCreatedEvent onAccountCreatedEvent in onAccountCreatedEvents)
            {
                onAccountCreatedEvent.OnAccountCreated(userId);
            }
        }

        public void AddListener(IOnAccountCreatedEvent listener) { 
            this.onAccountCreatedEvents.Add(listener);
        }

        public void RemoveListener(IOnAccountCreatedEvent listener) { 
            this.onAccountCreatedEvents.Remove(listener);
        }
    }
}

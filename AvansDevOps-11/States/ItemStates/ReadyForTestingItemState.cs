
using AvansDevOps_11.Users;

namespace AvansDevOps_11.States.ItemStates
{
    public class ReadyForTestingItemState : IItemState
    {
        private BacklogItem _item;

        public ReadyForTestingItemState(BacklogItem item)
        {
            _item = item;
            List<User> testers = item.Sprint.Testers.Cast<User>().ToList();
            item.Sprint.NotificationEvent.Notify(testers, $"Item {item.Title} is ready for testing", "Item ready for testing");
        }

        public void Start()
        {
            Console.WriteLine("State transition not allowed; Item is already started");
        }
        public void Finish()
        {
            Console.WriteLine("State transition not allowed; Item should be tested first");
        }
        public void Test()
        {
            Console.WriteLine("Moving item to 'Testing'");
            _item.ItemState = new TestingItemState(_item);
        }
        public void FinishTest()
        {
            Console.WriteLine("State transition not allowed; Item should be tested first");
        }
        public void Redo()
        {
            Console.WriteLine("State transition not allowed; Item can't be redone, it's already started");
        }
        public void Retest()
        {
            Console.WriteLine("State transition not allowed; Item has not been tested yet");
        }
        public void Approve()
        {
            Console.WriteLine("State transition not allowed; Item has not been tested nor checked yet");
        }
    }
}
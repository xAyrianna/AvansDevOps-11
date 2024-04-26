
using AvansDevOps_11.States.SprintStates;
using AvansDevOps_11.Users;

namespace AvansDevOps_11.States.ItemStates
{
    public class TestingItemState : IItemState
    {
        private readonly BacklogItem _item;

        public TestingItemState(BacklogItem item)
        {
            _item = item;
        }

        public void Start()
        {
            Console.WriteLine("State transition not allowed; Can't start item while testing");
        }
        public void Finish()
        {
            Console.WriteLine("State transition not allowed; Can't finish item while testing");
        }
        public void Test()
        {
            Console.WriteLine("State transition not allowed; Item is already being tested");
        }
        public void FinishTest()
        {
            if (_item.Sprint.State is InProgressSprintState)
            {
                Console.WriteLine("Moving item to 'Tested'");
                _item.ItemState = new TestedItemState(_item);
            }
            else
            {
                Console.WriteLine("State transition not allowed; Sprint is not in progress");
            }
        }
        public void Redo()
        {
            if (_item.Sprint.State is InProgressSprintState)
            {
                Console.WriteLine("Moving item back to 'ToDo'");
                _item.ItemState = new ToDoItemState(_item);
                List<User> ToBeNotified = new List<User> { _item.Sprint.ScrumMaster };
                _item.Sprint.NotificationEvent.Notify(ToBeNotified, $"Item {_item.Title} failed testing and has been moved back to 'ToDo'", "Item moved back to 'ToDo'");
            }
            else
            {
                Console.WriteLine("State transition not allowed; Sprint is not in progress");
            }
        }
        public void Retest()
        {
            Console.WriteLine("State transition not allowed; Can't retest item while testing");
        }
        public void Approve()
        {
            Console.WriteLine("State transition not allowed; Item is not tested yet");
        }
    }
}

using AvansDevOps_11.Users;

namespace AvansDevOps_11.States.ItemStates
{
    public class TestingItemState : IItemState
    {
        private BacklogItem _item;

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
            Console.WriteLine("Moving item to 'Tested'");
            _item.ItemState = new TestedItemState(_item);
        }
        public void Redo()
        {
            Console.WriteLine("Moving item back to 'ToDo'");
            _item.ItemState = new ToDoItemState(_item);
            List<User> ToBeNotified = new List<User> { _item.Sprint.ScrumMaster };
            _item.Sprint.NotificationEvent.Notify(ToBeNotified, $"Item {_item.Title} failed testing and has been moved back to 'ToDo'", "Item moved back to 'ToDo'");
        }
        public void Retest()
        {
            Console.WriteLine("State transition not allowed; Can't retest item while testing");
        }
        public void Done()
        {
            Console.WriteLine("State transition not allowed; Item is not tested yet");
        }
    }
}
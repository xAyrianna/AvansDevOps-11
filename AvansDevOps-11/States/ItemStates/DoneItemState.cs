

namespace AvansDevOps_11.States.ItemStates
{
    public class DoneItemState : IItemState
    {
        private readonly BacklogItem _item;

        public DoneItemState(BacklogItem item)
        {
            _item = item;
            foreach (var thread in item.Threads)
            {
                thread.Value.IsClosed = true;
            }
        }

        public void Start()
        {
            Console.WriteLine("State transition not allowed; Item is already done.");
        }
        public void Finish()
        {
            Console.WriteLine("State transition not allowed; Item is already done.");
        }
        public void Test()
        {
            Console.WriteLine("State transition not allowed; Item is already done.");
        }
        public void FinishTest()
        {
            Console.WriteLine("State transition not allowed; Item is already done.");
        }
        public void Redo()
        {
            foreach (var thread in _item.Threads)
            {
                thread.Value.IsClosed = false;
            }
            Console.WriteLine("Moving item back to 'ToDo'");
            _item.ItemState = new ToDoItemState(_item);
        }
        public void Retest()
        {
            Console.WriteLine("State transition not allowed; Item is already done.");
        }
        public void Approve()
        {
            Console.WriteLine("State transition not allowed; Item is already done.");
        }
    }
}
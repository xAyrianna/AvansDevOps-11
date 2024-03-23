

namespace AvansDevOps_11.States.ItemStates
{
    public class DoneItemState : IItemState
    {
        private BacklogItem _item;

        public DoneItemState(BacklogItem item)
        {
            _item = item;
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
            Console.WriteLine("Moving item back to 'ToDo'");
            _item.ItemState = new ToDoItemState(_item);
        }
        public void Retest()
        {
            Console.WriteLine("State transition not allowed; Item is already done.");
        }
        public void Done()
        {
            Console.WriteLine("State transition not allowed; Item is already done.");
        }
    }
}
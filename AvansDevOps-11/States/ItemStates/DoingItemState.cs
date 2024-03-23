
namespace AvansDevOps_11.States.ItemStates
{
    public class DoingItemState : IItemState
    {
        private BacklogItem _item;

        public DoingItemState(BacklogItem item)
        {
            _item = item;
        }

        public void Start()
        {
            Console.WriteLine("State transition not allowed; Item is already started");
        }
        public void Finish()
        {
            Console.WriteLine("Moving item to 'Ready for testing''");
            _item.ItemState = new ReadyForTestingItemState(_item);
        }
        public void Test()
        {
            Console.WriteLine("State transition not allowed; Item is not ready for testing");
        }
        public void FinishTest()
        {
            Console.WriteLine("State transition not allowed; Item is not ready for testing");
        }
        public void Redo()
        {
            Console.WriteLine("State transition not allowed; Item can't be redone, it's already started");
        }
        public void Retest()
        {
            Console.WriteLine("State transition not allowed; Item is not ready for testing");
        }
        public void Done()
        {
            Console.WriteLine("State transition not allowed; Item has not been tested nor checked yet");
        }
    }
}
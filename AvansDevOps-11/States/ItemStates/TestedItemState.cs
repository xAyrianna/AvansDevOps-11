using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.States.ItemStates
{
    public class TestedItemState : IItemState
    {
        private BacklogItem _item;

        public TestedItemState(BacklogItem item)
        {
            _item = item;
        }

        public void Start()
        {
            Console.WriteLine("State transition not allowed; Item is already tested");
        }
        public void Finish()
        {
            Console.WriteLine("State transition not allowed; Item is already tested");
        }
        public void Test()
        {
            Console.WriteLine("State transition not allowed; Item is already tested");
        }
        public void FinishTest()
        {
            Console.WriteLine("State transition not allowed; Item is already tested");
        }
        public void Redo()
        {
            Console.WriteLine("State transition not allowed; Item can't be redone, it's already tested");
        }
        public void Retest()
        {
            Console.WriteLine("Moving item back to 'Ready for testing'");
            _item.ItemState = new ReadyForTestingItemState(_item);
        }
        public void Approve()
        {
            Console.WriteLine("Moving item to 'Done'");
            _item.ItemState = new DoneItemState(_item);
        }
    }
}
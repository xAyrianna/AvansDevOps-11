using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.ItemStates
{
    public class DoingItemState : IItemState
    {
        private BacklogItem Item;

        public DoingItemState(BacklogItem item)
        {
            this.Item = item;
        }

        public void Start()
        {
            Console.WriteLine("Item is already started");
        }
        public void Finish()
        {
            Console.WriteLine("Moving item to 'Ready for testing''");
            this.Item.ItemState = new ReadyForTestingItemState(this.Item);
        }
        public void Test()
        {
            Console.WriteLine("Item is not ready for testing");
        }
        public void FinishTest()
        {
            Console.WriteLine("Item is not ready for testing");
        }
        public void Redo()
        {
            Console.WriteLine("Item can't be redone, it's already started");
        }
        public void Retest()
        {
            Console.WriteLine("Item is not ready for testing");
        }
        public void Done()
        {
            Console.WriteLine("Item has not been tested nor checked yet");
        }
    }
}
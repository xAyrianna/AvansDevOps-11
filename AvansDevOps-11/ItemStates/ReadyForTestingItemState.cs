using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.ItemStates
{
    public class ReadyForTestingItemState : IItemState
    {
        private BacklogItem Item;
        
        public ReadyForTestingItemState(BacklogItem item)
        {
            this.Item = item;
        }

        public void Start()
        {
           Console.WriteLine("Item is already started");
        }
        public void Finish()
        {
            Console.WriteLine("Item should be tested first");
        }
        public void Test()
        {
            Console.WriteLine("Moving item to 'Testing'");
            this.Item.ItemState = new TestingItemState(this.Item);
        }
        public void FinishTest()
        {
            Console.WriteLine("Item should be tested first");
        }
        public void Redo()
        {
            Console.WriteLine("Item can't be redone, it's already started");
        }
        public void Retest()
        {
            Console.WriteLine("Item has not been tested yet");
        }
        public void Done()
        {
            Console.WriteLine("Item has not been tested nor checked yet");
        }
    }
}
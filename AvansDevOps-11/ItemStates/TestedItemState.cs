using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.ItemStates
{
    public class TestedItemState : IItemState
    {
        private BacklogItem Item;

        public TestedItemState(BacklogItem item)
        {
            this.Item = item;
        }
        
        public void Start()
        {
            Console.WriteLine("Item is already tested");
        }
        public void Finish()
        {
            Console.WriteLine("Item is already tested");
        }
        public void Test()
        {
            Console.WriteLine("Item is already tested");
        }
        public void FinishTest()
        {
            Console.WriteLine("Item is already tested");
        }
        public void Redo()
        {
            Console.WriteLine("Item can't be redone, it's already tested");
        }
        public void Retest()
        {
            Console.WriteLine("Moving item back to 'Ready for testing'");
            this.Item.ItemState = new ReadyForTestingItemState(this.Item);
        }
        public void Done()
        {
            Console.WriteLine("Moving item to 'Done'");
            this.Item.ItemState = new DoneItemState(this.Item);
        }
    }
}
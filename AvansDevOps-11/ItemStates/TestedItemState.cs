using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.ItemStates
{
    public class TestedItemState : IItemState
    {
        private BacklogItem _item;

        public TestedItemState(BacklogItem item)
        {
            this._item = item;
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
            this._item.ItemState = new ReadyForTestingItemState(this._item);
        }
        public void Done()
        {
            Console.WriteLine("Moving item to 'Done'");
            this._item.ItemState = new DoneItemState(this._item);
        }
    }
}
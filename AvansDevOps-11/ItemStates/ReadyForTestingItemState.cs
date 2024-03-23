using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.ItemStates
{
    public class ReadyForTestingItemState : IItemState
    {
        private BacklogItem _item;
        
        public ReadyForTestingItemState(BacklogItem item)
        {
            this._item = item;
        }

        public void Start()
        {
           Console.WriteLine("State transition not allowed; Item is already started");
        }
        public void Finish()
        {
            Console.WriteLine("State transition not allowed; Item should be tested first");
        }
        public void Test()
        {
            Console.WriteLine("Moving item to 'Testing'");
            this._item.ItemState = new TestingItemState(this._item);
        }
        public void FinishTest()
        {
            Console.WriteLine("State transition not allowed; Item should be tested first");
        }
        public void Redo()
        {
            Console.WriteLine("State transition not allowed; Item can't be redone, it's already started");
        }
        public void Retest()
        {
            Console.WriteLine("State transition not allowed; Item has not been tested yet");
        }
        public void Done()
        {
            Console.WriteLine("State transition not allowed; Item has not been tested nor checked yet");
        }
    }
}
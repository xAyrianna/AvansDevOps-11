using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.ItemStates
{
    public class TestingItemState : IItemState
    {
        private BacklogItem _item;

        public TestingItemState(BacklogItem item)
        {
            this._item = item;
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
            this._item.ItemState = new TestedItemState(this._item);
        }
        public void Redo()
        {
            Console.WriteLine("Moving item back to 'ToDo'");
            this._item.ItemState = new ToDoItemState(this._item);
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
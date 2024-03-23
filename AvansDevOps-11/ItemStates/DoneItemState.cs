using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.ItemStates
{
    public class DoneItemState : IItemState
    {
        private BacklogItem _item;

        public DoneItemState(BacklogItem item)
        {
            this._item = item;
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
            this._item.ItemState = new ToDoItemState(this._item);
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
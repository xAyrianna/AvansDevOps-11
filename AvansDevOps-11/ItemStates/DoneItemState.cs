using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.ItemStates
{
    public class DoneItemState : IItemState
    {
        private BacklogItem item;

        public DoneItemState(BacklogItem item)
        {
            this.item = item;
        }

        public void Start()
        {
            Console.WriteLine("Item is already done.");
        }
        public void Finish()
        {
            Console.WriteLine("Item is already done.");
        }
        public void Test()
        {
            Console.WriteLine("Item is already done.");
        }
        public void FinishTest()
        {
            Console.WriteLine("Item is already done.");
        }
        public void Redo()
        {
            Console.WriteLine("Moving item back to 'ToDo'");
            this.item.ItemState = new ToDoItemState(this.item);
        }
        public void Retest()
        {
            Console.WriteLine("Item is already done.");
        }
        public void Done()
        {
            Console.WriteLine("Item is already done.");
        }
    }
}
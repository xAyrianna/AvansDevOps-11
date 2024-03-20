using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.ItemStates
{
    public class ToDoItemState : IItemState
    {
        private BacklogItem Item;

        public ToDoItemState(BacklogItem item)
        {
            this.Item = item;
        }

        public void Start()
        {
            this.Item.ItemState = new DoingItemState(this.Item);
        }
        public void Finish()
        {
            Console.WriteLine("Item is not started yet");
        }
        public void Test()
        {
            Console.WriteLine("Item is not started yet");
        }
        public void FinishTest()
        {
            Console.WriteLine("Item is not started yet");
        }
        public void Redo()
        {
            Console.WriteLine("Item is not started yet");
        }
        public void Retest()
        {
            Console.WriteLine("Item is not started yet");
        }
        public void Done()
        {
            Console.WriteLine("Item is not started yet");
        }
    }
}
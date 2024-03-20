using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.ItemStates
{
    public class TestingItemState : IItemState
    {
        private BacklogItem Item;

        public TestingItemState(BacklogItem item)
        {
            this.Item = item;
        }

        public void Start()
        {
            Console.WriteLine("Can't start item while testing");
        }
        public void Finish()
        {
            Console.WriteLine("Can't finish item while testing");
        }
        public void Test()
        {
            Console.WriteLine("Item is already being tested");
        }
        public void FinishTest()
        {
            this.Item.ItemState = new TestedItemState(this.Item);
        }
        public void Redo()
        {
            Console.WriteLine("Moving item back to 'ToDo'");
            this.Item.ItemState = new ToDoItemState(this.Item);
        }
        public void Retest()
        {
            Console.WriteLine("Can't retest item while testing");
        }
        public void Done()
        {
            Console.WriteLine("Item is not tested yet");
        }
    }
}
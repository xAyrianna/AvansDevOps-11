using AvansDevOps_11.States.SprintStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.States.ItemStates
{
    public class ToDoItemState : IItemState
    {
        private BacklogItem _item;

        public ToDoItemState(BacklogItem item)
        {
            _item = item;
        }

        public void Start()
        {
            if (_item.Sprint.State is InProgressSprintState)
            {
                Console.WriteLine("Moving backlog item to 'doing'.");
                _item.ItemState = new DoingItemState(_item);
            }
            else
            {
                Console.WriteLine("State transition not allowed; Sprint is not in progress");
            }
        }
        public void Finish()
        {
            Console.WriteLine("State transition not allowed; Item is not started yet");
        }
        public void Test()
        {
            Console.WriteLine("State transition not allowed; Item is not started yet");
        }
        public void FinishTest()
        {
            Console.WriteLine("State transition not allowed; Item is not started yet");
        }
        public void Redo()
        {
            Console.WriteLine("State transition not allowed; Item is not started yet");
        }
        public void Retest()
        {
            Console.WriteLine("State transition not allowed; Item is not started yet");
        }
        public void Approve()
        {
            Console.WriteLine("State transition not allowed; Item is not started yet");
        }
    }
}
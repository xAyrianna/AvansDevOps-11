using AvansDevOps_11.States.SprintStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.States.ItemStates
{
    public class TestedItemState : IItemState
    {
        private BacklogItem _item;

        public TestedItemState(BacklogItem item)
        {
            _item = item;
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
            if (_item.Sprint.State is InProgressSprintState)
            {
                Console.WriteLine("Moving item back to 'Ready for testing'");
                _item.ItemState = new ReadyForTestingItemState(_item);
            }
            else
            {
                Console.WriteLine("State transition not allowed; Sprint is not in progress");
            }
        }
        public void Approve()
        {
            if (_item.Sprint.State is InProgressSprintState)
            {
                bool done = true;
                if (_item.Activities != null)
                {
                    foreach (Activity activity in _item.Activities)
                    {
                        if (!activity.IsDone)
                        {
                            done = false;
                        }
                    }
                }
                if (done)
                {
                    Console.WriteLine("Moving item to 'Done'");
                    _item.ItemState = new DoneItemState(_item);
                }
                else
                {
                    Console.WriteLine("State transition not allowed; Not all activities are done");
                }
            }
            else
            {
                Console.WriteLine("State transition not allowed; Sprint is not in progress");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.States.ItemStates
{
    public interface IItemState
    {
        public void Start();
        public void Finish();
        public void Test();
        public void FinishTest();
        public void Redo();
        public void Retest();
        public void Approve();
    }
}
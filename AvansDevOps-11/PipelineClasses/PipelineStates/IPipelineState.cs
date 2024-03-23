using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps_11.PipelineClasses.PipelineStates
{
    public interface IPipelineState
    {
        public void Start();
        public void Finish();
        public void Error();
        public void Restart();
    }
}

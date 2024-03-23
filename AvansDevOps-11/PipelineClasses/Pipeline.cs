using AvansDevOps_11.PipelineClasses.PipelineStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.PipelineClasses
{
    public class Pipeline
    {
        public IPipelineState State { get; set; }

        public Pipeline()
        {
            State = new CreatedPipelineState(this);
        }

    }
}
using AvansDevOps_11.PipelineClasses.PipelineStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.PipelineClasses
{
    public class Pipeline
    {
        public Sprint Sprint { get; set; }
        public IPipelineState State { get; set; }
        public List<IPipelineActivity> Activities = new List<IPipelineActivity>();

        public Pipeline(Sprint sprint)
        {
            State = new CreatedPipelineState(this);
            Sprint = sprint;
        }

        public void Accept(PipelineVisitor visitor)
        {
            visitor.Visit(this);
            foreach (var activity in Activities)
            {
                activity.Accept(visitor);
            }
        }
    }
}
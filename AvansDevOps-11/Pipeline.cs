using AvansDevOps_11.Composites.PipelineComposite;
using AvansDevOps_11.States.PipelineStates;
using AvansDevOps_11.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11
{
    public class Pipeline
    {
        public Sprint Sprint { get; set; }
        public IPipelineState State { get; set; }
        public List<PipelineActivity> Activities = new List<PipelineActivity>();

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

        public void AddActivity(PipelineActivity activity)
        {
            if (State is CreatedPipelineState)
            {
                Activities.Add(activity);
            }
            else
            {
                Console.WriteLine("Can no longer add activity to pipeline.");
            }
        }

        public void RemoveActivity(PipelineActivity activity)
        {
            if (State is CreatedPipelineState)
            {
                Activities.Remove(activity);
            }
            else
            {
                Console.WriteLine("Can no longer remove activity from pipeline.");
            }
        }
    }
}
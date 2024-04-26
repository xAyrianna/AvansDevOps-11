using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvansDevOps_11.Visitors;

namespace AvansDevOps_11.Composites.PipelineComposite
{
    public class PipelineComposite : PipelineActivity
    {
        private readonly List<PipelineActivity> Children = new List<PipelineActivity>();

        public PipelineComposite(PipelineActionType actionType): base(actionType)
        {
        }

        public void Add(PipelineActivity activity)
        {
            Children.Add(activity);
        }

        public void Remove(PipelineActivity activity)
        {
            Children.Remove(activity);
        }

        public override void Accept(PipelineVisitor visitor)
        {
            visitor.Visit(this);
            foreach (var child in Children)
            {
                child.Accept(visitor);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.PipelineClasses
{
    public class PipelineComposite : IPipelineActivity
    {
        private List<IPipelineActivity> Children = new List<IPipelineActivity>();

        public string Name { get; internal set; }

        public void Add(IPipelineActivity activity)
        {
            Children.Add(activity);
        }

        public void Remove(IPipelineActivity activity)
        {
            Children.Remove(activity);
        }

        public void Accept(PipelineVisitor visitor)
        {
            visitor.Visit(this);
            foreach (var child in Children)
            {
                child.Accept(visitor);
            }
        }
    }
}
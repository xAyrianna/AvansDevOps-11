using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvansDevOps_11.Visitors;

namespace AvansDevOps_11.Composites.PipelineComposite
{
    public class PipelineComposite : IPipelineActivity
    {
        private List<IPipelineActivity> Children = new List<IPipelineActivity>();

        public string Name { get; set; }

        public PipelineComposite(string name)
        {
            Name = name;
        }

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
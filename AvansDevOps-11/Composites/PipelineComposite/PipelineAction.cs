using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvansDevOps_11.Visitors;

namespace AvansDevOps_11.Composites.PipelineComposite
{
    public class PipelineAction : IPipelineActivity
    {
        public string Command;

        public PipelineAction(string command)
        {
            Command = command;
        }

        public void Accept(PipelineVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
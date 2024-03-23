using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvansDevOps_11.PipelineClasses
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
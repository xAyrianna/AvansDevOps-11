using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvansDevOps_11.Visitors;

namespace AvansDevOps_11.Composites.PipelineComposite
{
    public class PipelineAction : PipelineActivity
    {
        public string Command;

        public PipelineAction(string command, PipelineActionType actionType): base(actionType)
        {
            Command = command;
        }

        public override void Accept(PipelineVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
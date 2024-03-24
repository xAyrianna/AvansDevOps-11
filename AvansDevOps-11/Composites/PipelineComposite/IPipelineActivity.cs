using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvansDevOps_11.Visitors;

namespace AvansDevOps_11.Composites.PipelineComposite
{
    public abstract class PipelineActivity
    {
        public PipelineActionType ActionType { get; set; }
        public PipelineActivity(PipelineActionType actionType)
        {
            ActionType = actionType;
        }
        public abstract void Accept(PipelineVisitor visitor);
    }
}
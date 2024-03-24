using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps_11.Composites.PipelineComposite
{
    public enum PipelineActionType
    {
        SOURCE,
        PACKAGE,
        BUILD,
        TEST,
        ANALYSE,
        DEPLOY,
        UTILITY
    }
}

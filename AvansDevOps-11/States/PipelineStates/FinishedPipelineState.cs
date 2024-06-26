﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps_11.States.PipelineStates
{
    public class FinishedPipelineState : IPipelineState
    {

        public FinishedPipelineState(Pipeline pipeline)
        {
            pipeline.Sprint.State.FinishPipeline();
        }

        public void Start()
        {
            Console.WriteLine("State transition not allowed; pipeline has finished.");
        }

        public void Finish()
        {
            Console.WriteLine("State transition not allowed; pipeline has finished.");
        }

        public void Error()
        {
            Console.WriteLine("State transition not allowed; pipeline has finished.");
        }

        public void Restart()
        {
            Console.WriteLine("State transition not allowed; pipeline has finished.");
        }
    }
}

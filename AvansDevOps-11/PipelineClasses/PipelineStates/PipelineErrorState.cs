using AvansDevOps_11.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps_11.PipelineClasses.PipelineStates
{
    public class PipelineErrorState: IPipelineState
    {
        private Pipeline _pipeline;

        public PipelineErrorState(Pipeline pipeline)
        {
            this._pipeline = pipeline;
            List<User> ToBeNotified = new List<User>() 
            { 
                this._pipeline.Sprint.ScrumMaster
            };
            pipeline.Sprint.NotificationEvent.Notify(ToBeNotified, "Pipeline has an error, please restart the pipeline or cancel the sprint.", "Pipeline Error");
        }

        public void Start()
        {
            Console.WriteLine("State transition not allowed; pipeline has an error.");
        }

        public void Finish()
        {
            Console.WriteLine("State transition not allowed; pipeline has an error.");
        }

        public void Error()
        {
            Console.WriteLine("State transition not allowed; pipeline has an error.");
        }

        public void Restart()
        {
            Console.WriteLine("Restarting pipeline execution.");
            this._pipeline.State = new RunningPipelineState(this._pipeline);
        }
    }
}

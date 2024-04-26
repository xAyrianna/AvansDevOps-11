
namespace AvansDevOps_11.States.PipelineStates
{
    public class CreatedPipelineState : IPipelineState
    {
        private readonly Pipeline _pipeline;
        public CreatedPipelineState(Pipeline pipeline)
        {
            _pipeline = pipeline;
        }
        public void Start()
        {
            Console.WriteLine("Starting pipeline execution.");
            _pipeline.State = new RunningPipelineState(_pipeline);
        }

        public void Finish()
        {
            Console.WriteLine("State transition not allowed; pipeline has not started yet and cannot be finished.");
        }

        public void Error()
        {
            Console.WriteLine("State transition not allowed; pipeline has not started yet and cannot have an error.");
        }

        public void Restart()
        {
            Console.WriteLine("State transition not allowed; pipeline has not started yet and cannot be restarted.");
        }
    }
}

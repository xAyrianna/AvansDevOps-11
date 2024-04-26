// See https://aka.ms/new-console-template for more information
using AvansDevOps_11.Composites.PipelineComposite;
using AvansDevOps_11.Users;
using AvansDevOps_11;
using AvansDevOps_11.Visitors;

Console.WriteLine("Hello, World!");

Sprint sprint = new ReleaseSprint(new Project("Test project", new ProductOwner("John Doe", "John Doe")), new ScrumMaster("Jane Doe", "Jane Doe"), "Sprint name", new DateTime(), new DateTime().AddDays(3));
Pipeline pipeline = new Pipeline(sprint);
PipelineComposite pipelineComposite = new PipelineComposite(PipelineActionType.SOURCE);
pipeline.AddActivity(pipelineComposite);

pipeline.State.Start();
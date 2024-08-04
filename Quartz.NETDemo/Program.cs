using Quartz;
using Quartz.Impl;
using Quartz.NETDemo;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var schedulerFactory = new StdSchedulerFactory();
var scheduler = await schedulerFactory.GetScheduler();
await scheduler.Start();

// Define the job and trigger
var job = JobBuilder.Create<HelloJob>()
    .WithIdentity("myJob", "group1")
    .Build();

var trigger = TriggerBuilder.Create()
    .WithIdentity("myTrigger", "group1")
    .StartNow()
    .WithSimpleSchedule(x => x
        .WithIntervalInSeconds(10)
        .RepeatForever())
    .Build();

await scheduler.ScheduleJob(job, trigger);

app.Run();


//var builder = WebApplication.CreateBuilder(args);
//var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//app.Run();

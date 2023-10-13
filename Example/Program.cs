// See https://aka.ms/new-console-template for more information
using THManager;

Console.WriteLine("Worker Example V1.0");

Worker worker = new Worker("One to hundred counter", (_) =>
{
    Thread.Sleep(1000);
});

worker.OnStart += (source, @event) =>
{
    Console.WriteLine($"On start: {@event.StartTime}");
};

worker.OnError += (source, @event) =>
{
    Console.WriteLine($"On start: {@event.ErrorTime}");
};

worker.OnFinish += (source, @event) =>
{
    Console.WriteLine($"On start: {@event.FinishTime}");
};
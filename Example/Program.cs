// See https://aka.ms/new-console-template for more information
using THManager;

Console.WriteLine("Worker Example V1.0");

Worker worker = new Worker("One to hundred counter", () =>
{
    Console.WriteLine("Initialized a new thread");
    Thread.Sleep(2500);
});

worker.OnStart += (source, @event) =>
    Console.WriteLine($"On start: {@event.StartTime}");

worker.OnError += (source, @event) =>
    Console.WriteLine($"On error: {@event.ErrorTime}");

worker.OnFinish += (source, @event) =>
    Console.WriteLine($"On finish: {@event.FinishTime}");

worker.Trigger();
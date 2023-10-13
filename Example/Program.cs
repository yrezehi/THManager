// See https://aka.ms/new-console-template for more information
using THManager;

Console.WriteLine("Worker Example V1.0");

WorkerManager.Spawn("One to hundred counter", () =>
{
    Console.WriteLine(WorkerManager.GetReport());
});

WorkerManager.Spawn("Five to hundred counter", () =>
{
    Console.WriteLine(WorkerManager.GetReport());
});

WorkerManager.Spawn("Ten to hundred counter", () =>
{
    Console.WriteLine(WorkerManager.GetReport());
});
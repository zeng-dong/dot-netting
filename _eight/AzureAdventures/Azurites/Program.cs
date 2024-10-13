using Azurites;

Console.WriteLine("Hello, You see Azurite enabling 3 types of storages!");

List<IStorageService> services = [
    new BlobStorageService(),
    new TableStorageService(),
    new QueueStorageService()
];

var tasks = services.Select(x => x.Execute());
await Task.WhenAll(tasks);

Console.WriteLine("Finished running services");
Console.ReadKey();
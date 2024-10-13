using Azure.Data.Tables;

namespace Azurites;

internal class TableStorageService : IStorageService
{
    public async Task Execute()
    {
        var connectionString = "DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1;";

        var client = new TableClient(connectionString, "zdproducts");

        List<TableEntity> products = [
            new("Book", "1"){{ "name", "DDD"}, { "price", 22.00M }, { "quantity", 11} },
            new("Book", "2"){{ "name", "Agile"}, { "price", 23.00M }, { "quantity", 12} },
            ];

        products.ForEach(async p =>
        {
            await client.AddEntityAsync(p);
            Console.WriteLine($"{p["name"]} added to the products table");
        });
    }
}
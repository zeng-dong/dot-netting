using Azure.Storage.Blobs;

namespace Azurites;

internal class BlobStorageService : IStorageService
{
    public async Task Execute()
    {
        var connectionString = "DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;";

        var client = new BlobContainerClient(connectionString, "zd-images");
        var stream = await new HttpClient().GetStreamAsync("https://hacknowledge.com/wp-content/uploads/2021/05/Unknown.png");

        var blob = client.GetBlobClient("zd-blobStorage.png");
        await blob.UploadAsync(stream);

        Console.WriteLine($"Image {blob.Name} was uploaded successfully!");
    }
}
using Azure.Identity;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System;

namespace chat_winform.Azure;

internal class AzureBlobContainer
{
    public static async Task<string> UploadFileToAzureBlob(string imageFileName, string imageFullPath)
    {
        var config = new ConfigurationBuilder().AddUserSecrets<chat_winform.frmChat>().Build();

        var azureBlobUri = config["AZURE_BLOB_URI"];
        var containerName = config["AZURE_BLOB_URI_CONTAINERNAME"];

        var blobServiceClient = new BlobServiceClient(new Uri(azureBlobUri), new DefaultAzureCredential());
        var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
        var blobClient = containerClient.GetBlobClient(imageFileName);
        Console.WriteLine($"Uploading to Blob storage as blob:\n\t {blobClient.Uri}\n");
        await blobClient.UploadAsync(imageFullPath, true);
        Console.WriteLine($"Uploading complete ...\n");
        return blobClient.Uri.ToString();
    }
}

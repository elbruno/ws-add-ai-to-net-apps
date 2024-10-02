using Azure.Identity;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace chat_winform.Azure;

internal class AzureBlobContainer
{
    public static async Task<string> UploadFileToAzureBlobWinformDocs(string docFileName, string docFullPath)
    {
        string uri = "";
        var validExtensions = new[] { ".txt", ".pdf" };
        var extension = Path.GetExtension(docFileName);
        if (validExtensions.Contains(extension))
        {
            var config = new ConfigurationBuilder().AddUserSecrets<frmChat>().Build();
            var containerName = config["AZURE_BLOB_CONTAINERNAME_DOCS"];
            uri = await UploadFileToAzureBlob(containerName, docFileName, docFullPath);
        }
        return uri;
    }

    public static async Task<string> UploadFileToAzureBlobWinformImages(string imageFileName, string imageFullPath)
    {
        var config = new ConfigurationBuilder().AddUserSecrets<frmChat>().Build();
        var containerName = config["AZURE_BLOB_CONTAINERNAME_IMAGES"];
        return await UploadFileToAzureBlob(containerName, imageFileName, imageFullPath);
    }

    public static async Task<string> UploadFileToAzureBlob(string containerName, string fileName, string fileFullPath)
    {
        var config = new ConfigurationBuilder().AddUserSecrets<frmChat>().Build();
        var azureBlobUri = config["AZURE_BLOB_URI"];
        
        var blobServiceClient = new BlobServiceClient(new Uri(azureBlobUri), new DefaultAzureCredential());
        var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
        var blobClient = containerClient.GetBlobClient(fileName);
        Console.WriteLine($"Uploading to Blob storage as blob:\n\t {blobClient.Uri}\n");
        await blobClient.UploadAsync(fileFullPath, true);
        Console.WriteLine($"Uploading complete ...\n");
        return blobClient.Uri.ToString();
    }
}

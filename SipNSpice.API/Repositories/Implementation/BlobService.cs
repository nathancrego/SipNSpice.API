using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;

namespace SipNSpice.API.Repositories.Implementation
{
    public class BlobService
    {
        private readonly BlobContainerClient drinksBlobContainerClient;
        private readonly BlobContainerClient recipesBlobContainerClient;

        public BlobService(IConfiguration configuration)
        {
            var connectionString = configuration["AzureBlobStorage:ConnectionString"];
            var drinksContainerName = configuration["AzureBlobStorage:DrinkContainerName"];
            var recipesContainerName = configuration["AzureBlobStorage:RecipeContainerName"];

            drinksBlobContainerClient = new BlobContainerClient(connectionString, drinksContainerName);
            drinksBlobContainerClient.CreateIfNotExists();

            recipesBlobContainerClient = new BlobContainerClient(connectionString, recipesContainerName);
            recipesBlobContainerClient.CreateIfNotExists();

        }

        public async Task<string> UploadRecipeFileAsync(IFormFile file, string fileName)
        {
            var blobClient = recipesBlobContainerClient.GetBlobClient(fileName);

            using var stream = file.OpenReadStream();
            await blobClient.UploadAsync(stream, new BlobHttpHeaders { ContentType = file.ContentType });

            return blobClient.Uri.ToString();
        }

        public async Task<string> UploadDrinkFileAsync(IFormFile file, string fileName)
        {
            var blobClient = drinksBlobContainerClient.GetBlobClient(fileName);

            using var stream = file.OpenReadStream();
            await blobClient.UploadAsync(stream, new BlobHttpHeaders { ContentType = file.ContentType });

            return blobClient.Uri.ToString();
        }
    }
}

using System;
using System.IO;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;

namespace S3ExampleApp
{
    class Program
    {
        private static readonly string bucketName = "tu-bucket-de-ejemplo"; // Reemplaza con tu bucket de S3
        private static readonly string keyName = "ejemplo.txt";
        private static readonly string filePath = "C:\\ruta\\a\\tu\\archivo.txt"; // Reemplaza con la ruta de tu archivo local
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USEast1;
        private static IAmazonS3 s3Client;

        static async Task Main(string[] args)
        {
            s3Client = new AmazonS3Client(bucketRegion);

            Console.WriteLine("Listando los buckets en tu cuenta de AWS:");
            await ListingBucketsAsync();

            Console.WriteLine("\nSubiendo un archivo al bucket...");
            await UploadFileAsync();

            Console.WriteLine("¡Operación completada!");
        }

        static async Task ListingBucketsAsync()
        {
            try
            {
                var listResponse = await s3Client.ListBucketsAsync();
                foreach (var bucket in listResponse.Buckets)
                {
                    Console.WriteLine($"- {bucket.BucketName}");
                }
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when listing buckets", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when listing buckets", e.Message);
            }
        }

        static async Task UploadFileAsync()
        {
            try
            {
                var fileTransferUtility = new TransferUtility(s3Client);

                // Opción 1. Cargar el archivo directamente
                await fileTransferUtility.UploadAsync(filePath, bucketName);
                Console.WriteLine("Subida directa completada");

                // Opción 2. Cargar un archivo con más opciones
                var fileTransferUtilityRequest = new TransferUtilityUploadRequest
                {
                    BucketName = bucketName,
                    FilePath = filePath,
                    StorageClass = S3StorageClass.Standard,
                    PartSize = 6291456, // 6 MB
                    Key = keyName,
                    CannedACL = S3CannedACL.PublicRead
                };

                await fileTransferUtility.UploadAsync(fileTransferUtilityRequest);
                Console.WriteLine("Subida con opciones completada");
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered on server. Message:'{0}' when writing an object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
            }
        }
    }
}
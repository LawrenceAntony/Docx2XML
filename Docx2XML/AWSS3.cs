using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using System.Configuration;

namespace Docx2XML
{
    public class AWSS3
    {
        private static readonly string _awsAccessKey = ConfigurationManager.AppSettings["AWSAccessKey"];
        private static readonly string _awsSecretKey = ConfigurationManager.AppSettings["AWSSecretKey"];
        public static bool CreateFileFromStream(Stream InputStream, string FileName, string _bucketName = "doc2xml")
        {
            bool _saved=false;
            try
            {
                
                IAmazonS3 client;
                AmazonS3Config objCon = new AmazonS3Config() ;
                objCon.RegionEndpoint = RegionEndpoint.USEast1;
                using (client = Amazon.AWSClientFactory.CreateAmazonS3Client(_awsAccessKey, _awsSecretKey,objCon))
                {
                    var request = new PutObjectRequest()
                    {
                        BucketName = _bucketName,
                        CannedACL = S3CannedACL.PublicRead,//PERMISSION TO FILE PUBLIC ACCESIBLE
                        Key = string.Format("{0}", FileName),
                        InputStream = InputStream//SEND THE FILE STREAM
                    };

                    client.PutObject(request);
                    _saved = true;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();

            }
            return _saved;
        }
        public static string GeneratePreSignedURL(string bucketName, string objectKey)
        {
            string urlString = "";
            IAmazonS3 s3Client;
            using (s3Client = new AmazonS3Client(Amazon.RegionEndpoint.USEast1))
            {
                GetPreSignedUrlRequest request1 = new GetPreSignedUrlRequest
                {
                    BucketName = bucketName,
                    Key = objectKey,
                    Expires = DateTime.Now.AddMinutes(5)
                };
                try
                {
                    urlString = s3Client.GetPreSignedURL(request1);
                    //string url = s3Client.GetPreSignedURL(request1);
                }
                catch (AmazonS3Exception amazonS3Exception)
                {
                    if (amazonS3Exception.ErrorCode != null &&
                        (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId")
                        ||
                        amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                    {
                        Console.WriteLine("Check the provided AWS Credentials.");
                        Console.WriteLine(
                        "To sign up for service, go to http://aws.amazon.com/s3");
                    }
                    else
                    {
                        Console.WriteLine(
                         "Error occurred. Message:'{0}' when listing objects",
                         amazonS3Exception.Message);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return urlString;

        }
    }
}
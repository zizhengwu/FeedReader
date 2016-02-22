using System;
using System.Collections.Generic;
using System.Text;
using Amazon;

namespace FeedReader
{
    public class Constants
    {
        public const string appId = "1534327030231289";
        public const string appName = "FeedReader";
        public const string COGNITO_IDENTITY_POOL_ID = "us-east-1:d9deee06-d0fb-4ad2-82df-a476d04d7a86";
        public static RegionEndpoint COGNITO_REGION = RegionEndpoint.USEast1;
        public const string PROVIDER_NAME = "graph.facebook.com";
    }
}

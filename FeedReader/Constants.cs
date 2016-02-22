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
        public const string COGNITO_IDENTITY_POOL_ID = "us-east-1:3c46831d-9f76-44fd-a3cd-2dabd63b34ce";
        public static RegionEndpoint COGNITO_REGION = RegionEndpoint.USEast1;
        public const string PROVIDER_NAME = "graph.facebook.com";
    }
}

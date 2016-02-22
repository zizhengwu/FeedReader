using System;
using System.Collections.Generic;
using System.Text;
using Amazon.CognitoIdentity;
using ObjCRuntime;
using UIKit;

namespace FeedReader
{
    public class AmazonUtils
    {
        private static CognitoAWSCredentials _credentials;

        public static CognitoAWSCredentials Credentials
        {
            get
            {
                if (_credentials == null)
                {
                    Console.WriteLine("null");
                    _credentials = new CognitoAWSCredentials(Constants.COGNITO_IDENTITY_POOL_ID, Constants.COGNITO_REGION);
                }
                    
                return _credentials;
            }
        }

        public static void ClearCredentials()
        {
            var credentials = Credentials;
            credentials.Clear();
            credentials.ClearCredentials();
            credentials.ClearIdentityCache();
            credentials = new CognitoAWSCredentials(Constants.COGNITO_IDENTITY_POOL_ID, Constants.COGNITO_REGION);
        }
    }
}

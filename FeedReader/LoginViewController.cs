using System;

using UIKit;
using System.Collections.Generic;

using Facebook.LoginKit;
using Facebook.CoreKit;
using CoreGraphics;
using Foundation;

namespace FeedReader
{
    public partial class LoginViewController : UIViewController
    {
        // To see the full list of permissions, visit the following link:
        // https://developers.facebook.com/docs/facebook-login/permissions/v2.3

        // This permission is set by default, even if you don't add it, but FB recommends to add it anyway
        List<string> readPermissions = new List<string> { "public_profile" };

        LoginButton loginButton;
        ProfilePictureView pictureView;
        UILabel nameLabel;

        public LoginViewController()
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            // already logged in
            try
            {
                if (!String.IsNullOrEmpty(AccessToken.CurrentAccessToken.TokenString))
                {
                    AwsUtils.Credentials.AddLogin(Constants.PROVIDER_NAME, AccessToken.CurrentAccessToken.TokenString);
                    Console.WriteLine(AwsUtils.Credentials.GetIdentityId());
                    this.DismissViewController(true, () => { });
                }
            }
            catch(NullReferenceException e) {}
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            loginButton = new LoginButton(new CGRect(80, 20, 220, 46))
            {
                LoginBehavior = LoginBehavior.Native,
                ReadPermissions = readPermissions.ToArray()
            };
            
            // Handle actions once the user is logged in
            loginButton.Completed += (sender, e) => {
                if (e.Error != null)
                {
                    // Handle if there was an error
                }

                else if (e.Result.IsCancelled)
                {
                    // Handle if the user cancelled the login request
                }

                else
                {
                    // Handle your successful login
                    this.DismissViewController(true, () => {});
                }
            };

            // Handle actions once the user is logged out
            loginButton.LoggedOut += (sender, e) => {
                // Handle your logout
            };

            // The user image profile is set automatically once is logged in
            pictureView = new ProfilePictureView(new CGRect(80, 80, 220, 220));

            // Add views to main view
            View.AddSubview(loginButton);
            View.AddSubview(pictureView);

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}


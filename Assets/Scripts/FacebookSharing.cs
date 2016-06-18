using UnityEngine;
using System.Collections;
using Facebook.Unity;
using System.Collections.Generic;
using System;

public class FacebookSharing : MonoBehaviour {

	// Use this for initialization
	public void OnButtonEvent_FB () {
        FB.Init(OnInit);
	}

   
    void OnInit()
    {
        if(FB.IsInitialized)
        {
            var perms = new List<string>() { "public_profile"/*, "email", "user_friends"*/ };
            FB.LogInWithReadPermissions(perms, AuthCallback);
            //FB.LogInWithPublishPermissions(perms,AuthCallback);
        }
        else
        {
            // Already initialized, signal an app activation App Event
            FB.ActivateApp();
            Debug.Log("Login Failed");
        }
    }

    private void AuthCallback(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            // AccessToken class will have session details
            var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
            // Print current access token's User ID
            Debug.Log(aToken.UserId);
            // Print current access token's granted permissions
            foreach (string perm in aToken.Permissions)
            {
                Debug.Log(perm);
            }

            //Post


            //FB.ShareLink(
            // new System.Uri("https://developer.facebook.com/"),
            // "I had Scored 50 Runs",
            //callback: ShareCallback);


            //portal link
            FB.Mobile.AppInvite(
                new Uri("https://fb.me/230990123946361")
                 //new Uri("https://developer.facebook.com/")
                 );

        }
        else
        {
            Debug.Log("User cancelled login");
        }
    }




    private void ShareCallback(IShareResult result)
    {
        if (result.Cancelled || !String.IsNullOrEmpty(result.Error))
        {
            Debug.Log("ShareLink Error: " + result.Error);
        }
        else if (!String.IsNullOrEmpty(result.PostId))
        {
            // Print post identifier of the shared content
            Debug.Log(result.PostId);
        }
        else
        {
            // Share succeeded without postID
            Debug.Log("ShareLink success!");
        }
    }

}

using UnityEngine;
using System.Collections;
//using GoogleMobileAds.Api;
using UnityEngine.Advertisements; // Using the Unity Ads namespace.



public class AdColonyAdsManager : SingeltonBase<AdColonyAdsManager>
{

    public void Initialize()
    {
        // Assign any AdColony Delegates before calling Configure
        AdColony.OnVideoFinished = this.OnVideoFinished;

        AdColony.OnV4VCResult = this.OnV4VCResult;


        // If you wish to use a the customID feature, you should call  that now.
        // Then, configure AdColony:
        AdColony.Configure
        (
          "version:1.0,store:google", // Arbitrary app version and Android app store declaration.
          "app5a1cbea0794348bd95",   // ADC App ID from adcolony.com
          "vz9d141739db9c4e4db4",
          "vz219b65d3d9a542d3bd"
        // A zone ID from adcolony.com
        /*"vzf8fb4670a60e4a139d01b5", // Any number of additional Zone IDS
        "vz1fd5a8b2bf6841a0a4b826"*/
        );
    }

    string zoneIDForReward = "vz219b65d3d9a542d3bd";
    // When a video is available, you may choose to play it in any fashion you like.
    // Generally you will play them automatically during breaks in your game,
    // or in response to a user action like clicking a button.
    // Below is a method that could be called, or attached to a GUI action.
    public void PlayV4VCAd(string zoneIDForReward= "vz219b65d3d9a542d3bd", bool prePopup=false, bool postPopup=true)
    {
        // Check to see if a video for V4VC is available in the zone.
        if (AdColony.IsV4VCAvailable(zoneIDForReward))
        {
            Debug.Log("Play AdColony V4VC Ad");
            // The AdColony class exposes two methods for showing V4VC Ads.
            // ---------------------------------------
            // The first `ShowV4VC`, plays a V4VC Ad and, optionally, displays
            // a popup when the video is finished.
            // ---------------------------------------
            // The second is `OfferV4VC`, which popups a confirmation before
            // playing the ad and, optionally, displays popup when the video 
            // is finished.

            // Call one of the V4VC Video methods:
            // Note that you should also pause your game here (audio, etc.) AdColony will not
            // pause your app for you.
            if (prePopup) AdColony.OfferV4VC(postPopup, zoneIDForReward);
            else AdColony.ShowV4VC(postPopup, zoneIDForReward);

            ////if (false)
            //AdColony.OfferV4VC(true, zoneIDForReward);
            ////else 
            ////AdColony.ShowV4VC(true, zoneIDForReward);
        }
        else
        {
            Debug.Log("V4VC Ad Not Available");
        }
    }




 

    // The V4VCResult Delegate assigned in Initialize -- AdColony calls this after confirming V4VC transactions with your server
    // success - true: transaction completed, virtual currency awarded by your server - false: transaction failed, no virtual currency awarded
    // name - The name of your virtual currency, defined in your AdColony account
    // amount - The amount of virtual currency awarded for watching the video, defined in your AdColony account
    private void OnV4VCResult(bool success, string name, int amount)
    {
        if (success)
        {
            Debug.Log("V4VC SUCCESS: name = " + name + ", amount = " + amount);
            TimerManager.RewardTime = true;
        }
        else
        {
            Debug.LogWarning("V4VC FAILED!");
        }
    }






    string zoneID = "vz9d141739db9c4e4db4";
    private void OnVideoFinished(bool ad_was_shown)
    {
        Debug.Log("On Video Finished");
        // Resume your app here.
    }


    // When a video is available, you may choose to play it in any fashion you like.
    // Generally you will play them automatically during breaks in your game,
    // or in response to a user action like clicking a button.
    // Below is a method that could be called, or attached to a GUI action.
    public void PlayAVideo()
    {
        // Check to see if a video is available in the zone.
        if (AdColony.IsVideoAvailable(zoneID))
        {
            Debug.Log("Play AdColony Video");
            // Call AdColony.ShowVideoAd with that zone to play an interstitial video.
            // Note that you should also pause your game here (audio, etc.) AdColony will not
            // pause your app for you.
            AdColony.ShowVideoAd(zoneID);
        }
        else
        {
            Debug.Log("Video Not Available");
        }
    }







    //Unity Ads
    #if !UNITY_ADS // If the Ads service is not enabled...
    public string gameId= "1064689"; // Set this value from the inspector.
    public bool enableTestMode = true;
#endif

    IEnumerator Start()
    {
#if !UNITY_ADS // If the Ads service is not enabled...
        if (Advertisement.isSupported)
        { // If runtime platform is supported...
            Advertisement.Initialize(gameId, enableTestMode); // ...initialize.
        }
#endif

        // Wait until Unity Ads is initialized,
        //  and the default ad placement is ready.
        while (!Advertisement.isInitialized || !Advertisement.IsReady())
        {
            yield return new WaitForSeconds(0.5f);
        }

    }


    public void ShowUnityVideoAd()
    {
        // Show the default ad placement.
        Advertisement.Show();
    }











        /*
        private string _interstitialAdUnitId = "ca-app-pub-2546982839475485/4158396856";
        private string _interstitialVideoAdUnitId = "";
        private string _bannerAdUnitId = "ca-app-pub-2546982839475485/2681663651";
        //Replace "MOPUB_AD_UNIT_ID" with actual Ad Unity Id
        /// <summary>
        /// :::
        /// </summary>

        ///Hammad :: :
        //private string _bannerAdUnitId = "ca-app-pub-5457802273866975/9925176242";




        private InterstitialAd interstitial;
        private BannerView bannerView;


        #if UNITY_IPHONE

        private string _interstitialAdUnitId = "ca-app-pub-5457802273866975/6832109044";
        private string _interstitialVideoAdUnitId = "";
        private string _bannerAdUnitId = "";

        #endif

        private double pauseTime;
        private double timeLimit;
        private double timeDifference;

        // Use this for initialization
        void Start () {
            pauseTime = 0.0f;
            timeLimit = 180.0f; // enter timeLimit in seconds => 1800.0f = 30 mins
            timeDifference = 0.0f;

            #if UNITY_ANDROID
            //if(!GamePrefManager.getPrefBoolPrefs(GamePrefManager.prefIsRemoveAds))

    {
    //			reportAppOpen();

            }
            #endif
            #if UNITY_IPHONE

            #endif
        }

        // Update is called once per frame
        void Update () {

        }

    //	/// <summary>
    //	/// Display the ad.
    //	/// </summary>
    //	public void callAdsHandler()
    //	{
    //		
    //		switch(GameManager.Instance.GetCurrentGameState())
    //		{
    //			
    //		case GameManager.GameState.MAIN_MENU:
    ////			this.PlayHavenOrMopubAdOnMainMenu();
    ////			this.RequestForMainMenuMopubAd();
    ////			this.hideBannerAds();
    ////			this.RequestForInterstitialAds();
    ////			if(GameManager.Instance.GetPreviousGameState() ==  GameManager.GameState.SCORE_BOARD){
    ////				destoryBannerAds();
    ////			}
    //			break;
    //		case GameManager.GameState.GAME_PLAY:
    //			this.RequestForInterstitialAds();
    ////			if(GameManager.Instance.GetPreviousGameState() == GameManager.GameState.SCORE_BOARD){
    ////				destoryBannerAds();
    ////			}
    ////			this.RequestForMopubAd();
    ////			this.showBannnerAds();
    //			break;
    ////		case GameManager.GameState.LEVELCOMPLETE:
    //		//	if(UserPrefs.unlockLevelsArrays[0]>2)
    //		//			this.ShowMopubAdOnLevelEnd();
    ////			break;
    ////		case GameManager.GameState.TIMEOVER:
    //		//this.ShowMopubAdOnLevelEnd();
    ////			break;
    ////		case GameManager.GameState.CRASHED:
    //		//	this.ShowMopubAdOnLevelEnd();
    ////			break;
    //		case GameManager.GameState.SCORE_BOARD:
    //			this.showIntersitialAds();
    ////			this.RequestForBannerAds();
    //			break;
    //			
    //		}
    //	}

        /// <summary>
        /// Requests for interstitial ads.
        /// </summary>
        public void RequestForInterstitialAds()
        {
            //if(!GamePrefManager.getPrefBoolPrefs(GamePrefManager.prefIsRemoveAds)) 
    {

                if(interstitial != null && interstitial.IsLoaded() ) {
                    Debug.Log("Ads Interstitial is already laoded.");
                    return;
                }
                //.AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
    //.AddTestDevice("D20F055200131732D32557B77A377B7A")  // Test Device 1.
                // Initialize an InterstitialAd.
                interstitial = new InterstitialAd(_interstitialAdUnitId);
                // Create an empty ad request.
                //AdRequest request = new AdRequest.Builder().Build();
                AdRequest request = new AdRequest.Builder()

        .Build();
                // Load the interstitial with the request.
                interstitial.LoadAd(request);
                Debug.Log("Ads Interstitial request send.");


    #if UNITY_ANDROID

    #endif
    #if UNITY_IPHONE

    #endif


            }
        }

        /// <summary>
        /// Shows the intersitial ads.
        /// </summary>
        public void showIntersitialAds() {
            Debug.Log("Ads Manager::showIntersitialAds");

            //if(!GamePrefManager.getPrefBoolPrefs(GamePrefManager.prefIsRemoveAds)) 
    {

                if(interstitial != null && interstitial.IsLoaded() ) {
                    Debug.Log("Show Intersitial Ads.");

                    interstitial.Show();
                } else {
                    Debug.Log("Ad is not loaded yet.");
                }


                #if UNITY_ANDROID

                #endif
                #if UNITY_IPHONE

                #endif
            } 
        }

        /// <summary>
        /// Requests for banner ads.
        /// </summary>
        public void RequestForBannerAds() {

            Debug.Log("Ads Banner Req");
            //if(!GamePrefManager.getPrefBoolPrefs(GamePrefManager.prefIsRemoveAds)) 
            {

                bannerView = new BannerView(_bannerAdUnitId, AdSize.Banner, AdPosition.Bottom);
                // Create an empty ad request.
                //AdRequest request = new AdRequest.Builder().Build();

                AdRequest request = new AdRequest.Builder()
    //.AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
    //.AddTestDevice("D20F055200131732D32557B77A377B7A")  // Test Device 1.
        .Build();
                // Load the banner with the request.
                bannerView.LoadAd(request);

                this.hideBannerAds();
            }


            #if UNITY_ANDROID

            #endif
            #if UNITY_IPHONE

            #endif
        }

        /// <summary>
        /// Destories the banner ads.
        /// </summary>
        private void destoryBannerAds() {

            if (bannerView != null) {
                bannerView.Destroy();
            }

        }

        /// <summary>
        /// Sets the banner keywords.
        /// </summary>
        private void setBannerKeywords() {
            #if UNITY_ANDROID

            #endif
            #if UNITY_IPHONE

            #endif
        }

        /// <summary>
        /// Shows the banner ads.
        /// </summary>
        public void showBannerAds() {
            //if(!GamePrefManager.getPrefBoolPrefs(GamePrefManager.prefIsRemoveAds)) 
    {

                if (bannerView != null) {
                    Debug.Log("Ads Banner showing");
                    bannerView.Show ();
                }
            }
        }

        /// <summary>
        /// Hides the banner ads.
        /// </summary>
        private void hideBannerAds() {

            if (bannerView != null) {
                bannerView.Hide ();
            }
        }

        /// <summary>
        /// Reports the app open.
        /// </summary>
        private void reportAppOpen () {

        }

        /// <summary>
        /// Raises the application pause event.
        /// </summary>
        /// <param name="status">If set to <c>true</c> status.</param>
        void OnApplicationPause(bool status)
        {
            if(status) {
                pauseTime = Time.realtimeSinceStartup;

            } else {
                #if UNITY_ANDROID
                //if(!GamePrefManager.getPrefBoolPrefs(GamePrefManager.prefIsRemoveAds)) 
    {

                }
                #endif
                #if UNITY_IPHONE

                #endif
                timeDifference = Time.realtimeSinceStartup - pauseTime;
                if(timeDifference >= timeLimit) {

                }
                else {

                }

            }

        }

        /// <summary>
        /// Removes the ads.
        /// </summary>
        public void removeAds() {
            //GamePrefManager.SavePrefs (GamePrefManager.prefIsRemoveAds, 1);

    //		GameObject.FindWithTag("AdsBtn").SetActive (false);
    //		if(GameObject.FindWithTag("RestoreTransc")) {
    //			GameObject.FindWithTag("RestoreTransc").SetActive (false);
    //		}

        }


        */
    }
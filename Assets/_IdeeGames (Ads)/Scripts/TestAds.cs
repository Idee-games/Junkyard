using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
public class TestAds : MonoBehaviour
{ 
    //    [SerializeField] string _androidGameId;
    //    [SerializeField] string _iOSGameId;
    //    [SerializeField] bool _testMode = true;
    //    [SerializeField] string _androidAdUnitId = "Interstitial_Android";
    //    [SerializeField] string _iOsAdUnitId = "Interstitial_iOS";
    //    private string _gameId;
    //    string _adUnitId;
    //    string _adUnitIdios;


    //    [SerializeField] Button _showAdButton;
    //    [SerializeField] string _androidAdUnitIdReward = "Rewarded_Android";
    //    [SerializeField] string _iOSAdUnitIdReward = "Rewarded_iOS";
    //    string _adUnitIdReward = null;
    //    // Start is called before the first frame update
    //    void Awake()
    //    {
    //        InitializeAds();

    //    }

    //    public void InitializeAds()
    //    {
    //        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
    //            ? _iOSGameId
    //            : _androidGameId;
    //        Advertisement.Initialize(_gameId, _testMode, this);



    //        _adUnitIdReward = (Application.platform == RuntimePlatform.IPhonePlayer)
    //           ? _iOSAdUnitIdReward
    //           : _androidAdUnitIdReward;



    //#if UNITY_IOS
    //        _adUnitIdios = _iOSAdUnitId;
    //#elif UNITY_ANDROID
    //        _adUnitId = _androidAdUnitId;
    //#endif

    //        //Disable the button until the ad is ready to show:
    //        _showAdButton.interactable = false;
    //    }

    //    public void OnInitializationComplete()
    //    {
    //        Debug.Log("Unity Ads initialization complete.");
    //    }

    //    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    //    {
    //        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    //    }
    //    // Update is called once per frame
    //    void Update()
    //    {

    //    }

    public void loadInter()
    {
        AdsManager.instance.Log("Unity InterAd Loaded");
      //AdsManager.instance.LoadAd();
        AdsManager.instance.Unity_LoadIAd();
    }
    public void loadInter2()
    {
        AdsManager.instance.Log("Admob InterAd Loaded");
        //AdsManager.instance.LoadAd();
        AdsManager.instance.Admob_RequestAndLoadInterstitialAd();
    }
    public void loadRewarded()
    {
        AdsManager.instance.Log("Unity RewardedAd Loaded");
        // AdsManager.instance.LoadAdReward();
        AdsManager.instance.Unity_LoadRAd();
    }
    public void loadRewarded2()
    {
        AdsManager.instance.Log("Admob RewardedAd Loaded");
       // AdsManager.instance.LoadAdReward(); 
        AdsManager.instance.Admob_RequestAndLoadRewardedAd();
        
    }
    public void showInter()
    {
        AdsManager.instance.Log("unity InterAd Showed");
        AdsManager.instance.Unity_ShowIAd();
        //   AdsManager.instance.ShowAd();
        //  AdsManager.instance.ShowAd(AdsManager.AdType.INTERSTITIAL);
    }
    public void showInter2()
    { 
        AdsManager.instance.Log("Admob InterAd Showed");
        AdsManager.instance.Admob_ShowInterstitialAd();
        //   AdsManager.instance.ShowAd();
        //  AdsManager.instance.ShowAd(AdsManager.AdType.INTERSTITIAL);
    }
    public void showRewarded()
    {
        AdsManager.instance.Log("unity RewardedAd Showed");
        AdsManager.instance.Unity_ShowRAd();
        //AdsManager.instance.ShowAd(AdsManager.AdType.Re);
    }
    public void showRewarded2()
    {
        AdsManager.instance.Log("Admob RewardedAd Showed");
        AdsManager.instance.Admob_ShowRewardedAd();
        //AdsManager.instance.ShowAd(AdsManager.AdType.Re);
    }
    //    public void LoadAd()
    //    {
    //        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
    //        Debug.Log("Loading Ad: " + _adUnitId);
    //        Advertisement.Load(_adUnitId, this);
    //    }

    //    // Show the loaded content in the Ad Unit:
    //    public void ShowAd()
    //    {
    //        // Note that if the ad content wasn't previously loaded, this method will fail
    //        Debug.Log("Showing Ad: " + _adUnitId);
    //        Advertisement.Show(_adUnitId, this);
    //    }

    //    // Implement Load Listener and Show Listener interface methods: 


    //    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    //    {
    //        Debug.Log($"Error loading Ad Unit: {adUnitId} - {error.ToString()} - {message}");
    //        // Optionally execute code if the Ad Unit fails to load, such as attempting to try again.
    //    }

    //    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    //    {
    //        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
    //        // Optionally execute code if the Ad Unit fails to show, such as loading another ad.
    //    }

    //    public void OnUnityAdsShowStart(string adUnitId) { }
    //    public void OnUnityAdsShowClick(string adUnitId) { }



    //    public void LoadAdReward()
    //    {
    //        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
    //        Debug.Log("Loading Ad: " + _adUnitIdReward);
    //        Advertisement.Load(_adUnitIdReward, this);
    //    }

    //    // If the ad successfully loads, add a listener to the button and enable it:
    //    public void OnUnityAdsAdLoaded(string _adUnitId)
    //    {
    //        Debug.Log("Ad Loaded: " + _adUnitId);

    //        if (_adUnitId.Equals(_adUnitIdReward))
    //        {
    //            // Configure the button to call the ShowAd() method when clicked:
    //            _showAdButton.onClick.AddListener(ShowAd);
    //            // Enable the button for users to click:
    //            _showAdButton.interactable = true;
    //        }
    //    }

    //    // Implement a method to execute when the user clicks the button:
    //    public void ShowAdReward()
    //    {
    //        // Disable the button:
    //        _showAdButton.interactable = false;
    //        // Then show the ad:
    //        Advertisement.Show(_adUnitIdReward, this);
    //    }

    //    // Implement the Show Listener's OnUnityAdsShowComplete callback method to determine if the user gets a reward:
    //    public void OnUnityAdsShowComplete(string _adUnitId, UnityAdsShowCompletionState showCompletionState)
    //    {
    //        if (_adUnitId.Equals(_adUnitIdReward) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
    //        {
    //            Debug.Log("Unity Ads Rewarded Ad Completed");
    //            // Grant a reward.

    //            // Load another ad:
    //            Advertisement.Load(_adUnitIdReward, this);
    //        }

    //    }

    //    // Implement Load and Show Listener error callbacks:


    //    void OnDestroy()
    //    {
    //        // Clean up the button listeners:
    //        _showAdButton.onClick.RemoveAllListeners();
    //    }
}


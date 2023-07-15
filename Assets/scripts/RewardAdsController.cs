using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardAdsController : MonoBehaviour
{

#if UNITY_ANDROID
    private string _adUnitId = "ca-app-pub-6252623389750489/5157582356";
#elif UNITY_IPHONE
  private string _adUnitId = "ca-app-pub-6252623389750489/9175050114";
#else
  private string _adUnitId = "unused";
#endif

    private RewardedAd rewardedAd;
    public AudioSource coinCollectedSound;
    public int rewardCoinsCount = 5000;
    public bool isForContinue = false;
    public GameObject gameOverUIObj;

    /// <summary>
    /// Loads the rewarded ad.
    /// </summary>
    /// 
    void Start()
    {
        LoadRewardedAd();
    }

    public void ShowRewardedAd()
    {
       

        if (rewardedAd != null && rewardedAd.CanShowAd())
        {
            rewardedAd.Show((Reward reward) =>
            {
                Debug.Log("Show Rewarded ad");
                LoadRewardedAd();
                RewardAddHasCompleted();
            });
        }
    }

    void RewardAddHasCompleted()
    {
        if (!isForContinue)
        {
          
            Debug.Log("RewardAddHasCompleted");
            FindObjectOfType<MainMenuController>().setCoinsText((FindObjectOfType<MainMenuController>().getCurrentCoinsCoint() + rewardCoinsCount).ToString());
            Utils.increaseCoins(rewardCoinsCount);
        }
        else
        {

            FindObjectOfType<HeadCollision>().startingCollision = false;
            FindObjectOfType<PlayerMovementController>().conitinue();
            gameOverUIObj.transform.localScale = Vector3.zero;
            FindObjectOfType<GameOverController>().uiIsSetted = false;

        }
    }
    private void RegisterEventHandlers(RewardedAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(String.Format("Rewarded ad paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Rewarded ad recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        ad.OnAdClicked += () =>
        {
            Debug.Log("Rewarded ad was clicked.");
        };
        // Raised when an ad opened full screen content.
        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Rewarded ad full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Rewarded ad full screen content closed.");
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Rewarded ad failed to open full screen content " +
                           "with error : " + error);
        };
    }

    private void RegisterReloadHandler(RewardedAd ad)
    {
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
    {
            Debug.Log("Rewarded Ad full screen content closed.");

            // Reload the ad so that we can show another as soon as possible.
            LoadRewardedAd();
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Rewarded ad failed to open full screen content " +
                           "with error : " + error);

            // Reload the ad so that we can show another as soon as possible.
            LoadRewardedAd();
        };
    }
    public void LoadRewardedAd()
    {
        Debug.Log("Loading the rewarded ad.");
        RequestConfiguration requestConfiguration = new RequestConfiguration
        {
            TagForChildDirectedTreatment = TagForChildDirectedTreatment.True
        };
        MobileAds.SetRequestConfiguration(requestConfiguration);
        // Clean up the old ad before loading a new one.
        if (rewardedAd != null)
        {
            rewardedAd.Destroy();
            rewardedAd = null;
        }

       

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        RewardedAd.Load(_adUnitId, adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    Debug.LogError("Rewarded ad failed to load an ad " +
                                   "with error : " + error);
                    return;
                }

                Debug.Log("Rewarded ad loaded with response : "
                          + ad.GetResponseInfo());

                rewardedAd = ad;
                //ShowRewardedAd();
            });
    }
    // Start is called before the first frame update
    

    
}

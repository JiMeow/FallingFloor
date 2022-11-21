using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    public static AdManager instance;
    string[] ios;
    string[] android;
    bool isAndroid, isIos;

    [SerializeField]
    AudioSource Sound;

#if UNITY_IOS
    string gameId = "4896284";
#elif UNITY_ANDROID
    string gameId = "4896285";
#else
    string gameId = "4896284";
#endif

    Action OnSuccessAd;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Advertisement.Initialize(gameId);
        Advertisement.AddListener(this);
        ios = new string[] { "Interstitial_iOS", "Rewarded_iOS", "Banner_iOS" };
        android = new string[] { "Interstitial_Android", "Rewarded_Android", "Banner_Android" };
        if (gameId == "4896044")
        {
            isIos = true;
        }
        else
        {
            isAndroid = true;
        }
    }

    public void PlayNormalAd(Action onSucess)
    {
        OnSuccessAd = onSucess;
        if (isIos)
        {
            if (Advertisement.IsReady(ios[0]))
            {
                Advertisement.Show(ios[0]);
            }
        }
        else if (isAndroid)
        {
            if (Advertisement.IsReady(android[0]))
            {
                Advertisement.Show(android[0]);
            }
        }
    }

    public void PlayRewardAd(Action onSucess)
    {
        OnSuccessAd = onSucess;
        if (isIos)
        {
            if (Advertisement.IsReady(ios[1]))
            {
                Advertisement.Show(ios[1]);
            }
        }
        else if (isAndroid)
        {
            if (Advertisement.IsReady(android[1]))
            {
                Advertisement.Show(android[1]);
            }
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        //pass
    }

    public void OnUnityAdsDidError(string message)
    {
        //pass
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //pass
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        foreach (AudioSource audio in FindObjectsOfType<AudioSource>())
        {
            audio.mute = true;
        }
        if (placementId == ios[0] || placementId == android[0])
        {
            OnSuccessAd.Invoke();
        }
        //pass
        // if (placementId == ios[1] || placementId == android[1])
        // {
        //     if (showResult == ShowResult.Finished)
        //     {
        //         // GameManager.instance.AddScore(50);
        //     }
        // }
    }
}

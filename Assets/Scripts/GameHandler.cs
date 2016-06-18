using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameHandler : MonoBehaviour {

    public static int AdsCount = 0;
    public void ButtonEvent_BackToMainMenu()
    {
        if(AdsCount%2 == 0)
        {
            AdColonyAdsManager.Instance.PlayAVideo();
        }
        else
        {
            AdColonyAdsManager.Instance.ShowUnityVideoAd();
        }
        AdsCount++;
        Application.LoadLevel("MainMenu");
    }

    public void ButtonEvent_PlayColorLevel()
    {
        if (AdsCount % 2 == 0)
        {
            AdColonyAdsManager.Instance.PlayAVideo();
        }
        else
        {
            AdColonyAdsManager.Instance.ShowUnityVideoAd();
        }
        AdsCount++;
        Application.LoadLevel("GamePlayColor");
    }

    public void ButtonEvent_GiveReward()
    {
      //  if (AdsCount % 2 == 0)
        {
            AdColonyAdsManager.Instance.PlayV4VCAd();
        }
        //else
        {

        }
        
       
    }

}

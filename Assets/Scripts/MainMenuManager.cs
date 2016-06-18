using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {

    void Start()
    {
        AdColonyAdsManager.Instance.Initialize();
       
    }

    public void ButtonEvent_Play()
    {
        Application.LoadLevel("GamePlay");
    }


}

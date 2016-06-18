using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChallengeSetScript : MonoBehaviour {

    public Text ChallengeTapsText;
    public Slider ChallengeSlider;

    public static int challengeValue;
    public static bool gameStart=false;

    void Start()
    {
        gameStart = false;
    }

    void Update()
    {
        challengeValue = (int) ChallengeSlider.GetComponent<Slider>().value;
        ChallengeTapsText.text = (challengeValue - challengeValue % 5).ToString();
    }


    public Text TextTimer;
    public void ButtonEvent_Play()
    {
        this.gameObject.SetActive(false);
        TextTimer.gameObject.SetActive(true);
        gameStart = true;

    }

}

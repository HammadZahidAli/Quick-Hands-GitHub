using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour {

    public GameObject GameOverPanel;
    public Text TextScore;
    public Text TextTime;

    public float timerValue = 20f;
    public int timerContainer = 1;
    public static bool RewardTime;


    void OnEnable()
    {
        if (RewardTime)
        {
            timerValue += 30f;
        }

    }

    // Update is called once per frame
    void Update()
    {


        if (ChallengeSetScript.gameStart)
        {
            if (timerValue > 0)
            {
                timerValue -= Time.deltaTime;
                timerContainer = (int)timerValue;

                TextTime.text = "" + timerContainer;
                TextScore.text = "" + ButtonsHandler.Score;
            }

            if (timerContainer == 0)
            {
                GameOverPanel.SetActive(true);
                timerContainer = -1;
            }
        }

    }

}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour {

    public Text TextScore;
    public Text TextMissedTaps;
    public Text TextPercentageChallenge;

    void OnEnable()
    {
        TextScore.text += " " + ButtonsHandler.Score;
        TextMissedTaps.text += " " + ButtonsHandler.Missed;
        
        int perc;
        
        if (ButtonsHandler.Score < ChallengeSetScript.challengeValue)
        {
            perc = (int)((ButtonsHandler.Score / (float)ChallengeSetScript.challengeValue)*100);
            TextPercentageChallenge.text = "" + perc + "%";
        }
        else if(ButtonsHandler.Score == 0)
        {
            TextPercentageChallenge.text = "" + "POOR!";
        }
        else
        {
            TextPercentageChallenge.text = "" + "GREAT!";
        }

        
    }

    
}

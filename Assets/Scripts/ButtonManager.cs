using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour {

    public static int Indicator = new System.Random().Next(30, 60);
    System.Random rand = new System.Random();
    void OnEnable()
    {
        if (tag == "Smaller")
        {
            
            gameObject.GetComponentInChildren<Text>().text = "" + rand.Next(1, Indicator);
            Debug.Log("smaller" + gameObject.GetComponentInChildren<Text>().text);
        }
        else if (tag == "Normal")
        {
            gameObject.GetComponentInChildren<Text>().text = "" + rand.Next(Indicator, 99);
            Debug.Log("Normal" + gameObject.GetComponentInChildren<Text>().text);
        }
        Indicator = rand.Next(40,70);

    }


}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonsHandler : MonoBehaviour {

    public GameObject[] NormalButtonArray;
    public GameObject[] SmallerButtonArray;

    int normalvalue;
    int smallervalue;

    
    
    public static int Score = 0;
    public static int Missed = 0;


    void Start()
    {
        CurrentColor = CorrectColor.Blue;
        Score = 0;
        Missed = 0;
    }


    public void Button_Event_Smaller()
    {
        Missed++;
    }

    public void Button_Event_Normal()
    {
        Score++;
        HidePreviousButtons();
        ShowNewButtons();
    }


    void HidePreviousButtons()
    {
        GameObject[] s = GameObject.FindGameObjectsWithTag("Smaller");
        GameObject[] n = GameObject.FindGameObjectsWithTag("Normal");

        s[0].SetActive(false);
        n[0].SetActive(false);
    }

    int index = 0;
    void ShowNewButtons()
    {
        Debug.Log(index);

        
        SmallerButtonArray[index% SmallerButtonArray.Length].SetActive(true);
        NormalButtonArray[index%NormalButtonArray.Length].SetActive(true);

        index++;
    }



    /*****************************************************************COLOR LEVEL Logic********/
    public static CorrectColor CurrentColor;

    public enum CorrectColor
    {
        Red,
        Green,
        Blue
    }

    public GameObject[] RedArray;
    public GameObject[] GreenArray;
    public GameObject[] BlueArray;


    public void ButtonEvent_RedClick()
    {

        Missed++;
        RandomizeArray(RedArray);
    }


    public void ButtonEvent_GreenClick()
    {

        Missed++;
        RandomizeArray(GreenArray);
    }

    public void ButtonEvent_BlueClick()
    {
        Debug.Log("Blue");
        if (CurrentColor == CorrectColor.Blue)
        {
            Score++;
            HidePreviousColorButtons();
            ShowNewColorButtons();
        }

        RandomizeArray(BlueArray);
        

    }


    void HidePreviousColorButtons()
    {
        GameObject[] r = GameObject.FindGameObjectsWithTag("Red");
        GameObject[] g = GameObject.FindGameObjectsWithTag("Green");
        GameObject[] b = GameObject.FindGameObjectsWithTag("Blue");

        r[0].SetActive(false);
        g[0].SetActive(false);
        b[0].SetActive(false);
    }

    int Colorindex = new System.Random().Next(0,5);
    void ShowNewColorButtons()
    {
        Debug.Log(Colorindex);

        RedArray[Colorindex % RedArray.Length].SetActive(true);
        GreenArray[Colorindex % GreenArray.Length].SetActive(true);
        BlueArray[Colorindex % BlueArray.Length].SetActive(true);
        Colorindex++;

    }


    void RandomizeArray(GameObject[] arr)
    {
        for (var i = arr.Length - 1; i > 0; i--)
        {
            var r = Random.Range(0, i);
            GameObject tmp = arr[i];
            arr[i] = arr[r];
            arr[r] = tmp;
        }
    }


    /*****************************************************************COLOR END Logic********/

}




//Extra
//if (Colorindex < SmallerButtonArray.Length)
//{
//    RedArray[Colorindex].SetActive(true);
//    GreenArray[Colorindex].SetActive(true);
//    BlueArray[Colorindex].SetActive(true);
//}
//else
//{
//    Colorindex = 0;
//    RedArray[Colorindex].SetActive(true);
//    GreenArray[Colorindex].SetActive(true);
//    BlueArray[Colorindex].SetActive(true);

//}


//if (CurrentColor == CorrectColor.Green)
//{
//    Score++;
//    HidePreviousColorButtons();
//    ShowNewColorButtons();
//}
//else

//if (CurrentColor == CorrectColor.Red)
//{
//    Score++;
//    HidePreviousColorButtons();
//    ShowNewColorButtons();
//}
//else
//if(index<SmallerButtonArray.Length)
//{
//    SmallerButtonArray[index].SetActive(true);
//    NormalButtonArray[index].SetActive(true);

//}
//else
//{
//    index = 0;
//    SmallerButtonArray[index].SetActive(true);
//    NormalButtonArray[index].SetActive(true);

//}


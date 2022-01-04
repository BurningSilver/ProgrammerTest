using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkCorrect : MonoBehaviour
{
    //checks the match between the btn pressed and 
    private Text mainWord;
    private GameObject playCanvas;
    public void checkMatch()
    {
        playCanvas = GameObject.Find("PlayCanvas");
        mainWord = playCanvas.GetComponentInChildren<Text>();
        if (correctCol())
        {
            playCanvas.GetComponent<playHandler>().incrementSuccess();
        }
        else{
            playCanvas.GetComponent<playHandler>().createRound();
        }
    }

    private bool correctCol()
    {
        bool val = false;
        Color col = mainWord.color;
        string text = this.GetComponentInChildren<Text>().text;

        string compare = translateCol(col);

        if (compare == text)
        {
            val = true;
        }
        else{ /*something idk */ }
        return val;
    }

    // checking and converting the colour back to a readable form above
    private string translateCol(Color col)
    {
        string res = "";
        if (col == Color.red)
        {
            res = "Red";
        }
        else if (col == Color.blue)
        {
            res = "Blue";
        }
        else if (col == Color.green)
        {
            res = "Green";
        }
        else if (col == Color.black)
        {
            res = "Black";
        }
        else if (col == Color.yellow)
        {
            res = "Yellow";
        }
        else if (col == Color.magenta)
        {
            res = "Magenta";
        }

        return res;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playHandler : MonoBehaviour
{
    // creates the first word to guess.
    private GameObject mainWord;
    private Text wordText;
    private List<Vector3> positions = new List<Vector3>(4);

    public void createGame()
    {
        mainWord = GameObject.Find("mainWord");
        if (mainWord == null)
        {
            mainWord = new GameObject();
            mainWord.name = "mainWord";
            mainWord.transform.SetParent(this.transform);
            //mainWord.transform.position = new Vector3(0,70,0);
            mainWord.AddComponent<Text>();
            mainWord.GetComponent<Text>().text = "";
            mainWord.GetComponent<Text>().fontSize = 34;
        }
        wordText = mainWord.GetComponent<Text>();
        wordText.alignment = TextAnchor.MiddleCenter;
        wordText.text = selectRandomWord();
        selectRandomColour();
        createOptions();
    }

    // selects a random number to assign a random word
    string selectRandomWord()
    {

        int num = Random.Range(0, 5);
        string col = "";

        switch (num)
        {
            case 0:
                col = "Red";
                break;
            case 1:
                col = "Blue";
                break;
            case 2:
                col = "Green";
                break;
            case 3:
                col = "Yellow";
                break;
            case 4:
                col = "Black";
                break;
            case 5:
                col = "Magenta";
                break;
        }
        return col;
    }

    void selectRandomColour()
    {

        int num = Random.Range(0, 5);

        switch (num)
        {
            case 0:
                wordText.color = Color.red;
                break;
            case 1:
                wordText.color = Color.blue;
                break;
            case 2:
                wordText.color = Color.green;
                break;
            case 3:
                wordText.color = Color.yellow;
                break;
            case 4:
                wordText.color = Color.black;
                break;
            case 5:
                wordText.color = Color.magenta;
                break;
        }
    }

    // to retrieve the correct colour from main word
    string correctColAsText()
    {

        string col = "";
        Color correctCol = wordText.color;

        if (correctCol == Color.red)
        {
            col = "Red";
        }
        else if (correctCol == Color.blue)
        {
            col = "Blue";
        }
        else if (correctCol == Color.green)
        {
            col = "Green";
        }
        else if (correctCol == Color.black)
        {
            col = "Black";
        }
        else if (correctCol == Color.yellow)
        {
            col = "Yellow";
        }
        else if (correctCol == Color.magenta)
        {
            col = "Magenta";
        }

        return col;
    }

// creates all of the buttons for selecting word
    void createOptions()
    {

        GameObject refBtn = GameObject.Find("preFabBtn");

        GameObject[] choices = new GameObject[4];
        string[] colourChoices = new string[4];

        GameObject correct = GameObject.Instantiate(refBtn);
        correct.GetComponentInChildren<Text>().text = correctColAsText();
        correct.GetComponentInChildren<Text>().color = Color.black;
        correct.transform.SetParent(GameObject.Find("PlayCanvas").transform);
        colourChoices[0] = correct.GetComponentInChildren<Text>().text;

        choices[0] = correct;

        //creates choice buttons (settings/text)
        for (int i = 1; i < choices.Length; i++)
        {
            choices[i] = GameObject.Instantiate(correct);
            string wrongCol = selectRandomWord();
            bool wordPlaced = false;

            //while a unique word is not placed yet
            while (!wordPlaced)
            {
                bool wordPresent = false;
                // to check if the random word does not already exist
                foreach (string str in colourChoices)
                {

                    if (str == null) {/* do nothing */};

                    //check if it matches current word
                    if (wrongCol == str)
                    {
                        wordPresent = true;
                    }
                }

                // it exists already, pick a new word (continues while loop)
                if (wordPresent)
                {
                    wrongCol = selectRandomWord();
                }
                // word does not exist, place into trackers and cancel while loop
                else
                {
                    choices[i].GetComponentInChildren<Text>().text = wrongCol;
                    choices[i].transform.SetParent(GameObject.Find("PlayCanvas").transform);
                    colourChoices[i] = wrongCol;
                    wordPlaced = true;
                }
            }
        }

        //retrieving canvas dimensions and applying structured math
        RectTransform canvas = GameObject.Find("MainMenuCanvas").GetComponent<RectTransform>();
        float halfX = canvas.rect.width / 2;
        float halfY = canvas.rect.height / 2;

        positions.Add(new Vector3(halfX - 350, halfY - 125, 0));
        positions.Add(new Vector3(halfX - 125, halfY - 125, 0));
        positions.Add(new Vector3(halfX + 125, halfY - 125, 0));
        positions.Add(new Vector3(halfX + 350, halfY - 125, 0));
        
        List<int> pos = new List<int>{0,1,2,3};

        //assigns the buttons to a random position
        foreach(GameObject go in choices){
            int num = Random.Range(0,positions.Count - 1);
            go.transform.position = positions[num];
            positions.RemoveAt(num);
        }
    }
}

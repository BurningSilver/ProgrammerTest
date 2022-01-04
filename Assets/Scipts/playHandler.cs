using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playHandler : MonoBehaviour
{
    // creates the first word to guess.
    private GameObject mainWord;
    private Text wordText;

    // void Start(){}
    // // Update is called once per frame
    // void Update(){}

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
        selectRandomWord();
        selectRandomColour();
        createOptions();
    }

    // selects a random number to assign a random word
    void selectRandomWord()
    {

        int num = Random.Range(0, 5);

        switch (num)
        {
            case 0:
                wordText.text = "Red";
                break;
            case 1:
                wordText.text = "Blue";
                break;
            case 2:
                wordText.text = "Green";
                break;
            case 3:
                wordText.text = "Yellow";
                break;
            case 4:
                wordText.text = "Black";
                break;
            case 5:
                wordText.text = "Magenta";
                break;
        }
    }

    void selectRandomColour() { 

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

    void createOptions() { }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playBtn : MonoBehaviour
{
    public GameObject playCanvas;

    public void changeToPlay(){
        playCanvas = GameObject.Find("PlayCanvas");
        GameObject.Find("mainMenu").SetActive(false);
        playCanvas.GetComponent<playHandler>().createGame();
        GameObject.Find("MainMenuCanvas").GetComponent<Timer>().StartStopwatch();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{

    bool stopwatchActive = false;
    float currentTime;
    private Text currentTimeText;

    // Start is called before the first frame update
    void Start()
    {
        currentTimeText = GameObject.Find("Timer").GetComponent<Text>();
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(stopwatchActive){
            currentTime = currentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss\:ff");
    }

    public void StartStopwatch(){
        currentTimeText.text = "00:00:00";
        currentTime = 0;
        stopwatchActive = true;
    }

    public void StopStopWatch(){
        stopwatchActive = false;
    }
}

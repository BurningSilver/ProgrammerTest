using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colourCycling : MonoBehaviour
{
    private Text text;
    private float timeToChange = 0.5f;
    private float timeSinceChanged = 0f;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceChanged += Time.deltaTime;
        if(timeSinceChanged >= timeToChange){
            text.color = new Color(
                Random.value,
                Random.value,
                Random.value
            );

            timeSinceChanged = 0f;
        }
    }
}

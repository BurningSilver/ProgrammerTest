using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBtn : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject playCanvas;

    public void restart(){
        mainMenu.SetActive(true);
        playCanvas.SetActive(false);
    }
}

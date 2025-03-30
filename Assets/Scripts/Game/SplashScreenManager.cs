using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenManager : MonoBehaviour
{
    public float delayTime = 3f; 
    public GameObject MainMenuCanvas; 

    void Start()
    {
        
        if (MainMenuCanvas != null)
            MainMenuCanvas.SetActive(false);

        
        Invoke("HideSplashScreen", delayTime);
    }

    void HideSplashScreen()
    {
        
        gameObject.SetActive(false);

        
        if (MainMenuCanvas != null)
            MainMenuCanvas.SetActive(true);
    }
}

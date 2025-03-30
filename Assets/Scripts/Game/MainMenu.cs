using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {

        LoadingScreen.LoadScene("SampleScene");
    }

    public void OpenSettings()
    {
        Debug.Log("Settings opened");
        LoadingScreen.LoadScene("Settings");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game quit"); 
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void HandlePlayGame()
    {
        SceneManager.LoadScene("PlayerSelector");
    }  

    public void HandleExit()
    {
        Application.Quit();
    }
}

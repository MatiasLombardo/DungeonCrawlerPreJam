
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void GoToScene() { 
        SceneManager.LoadScene("Floor 1 Copy");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game stopped");
    }

}

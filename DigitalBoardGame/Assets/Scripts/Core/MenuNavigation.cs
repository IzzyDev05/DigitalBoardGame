using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene(1);
    }

    public void Rules() {
        SceneManager.LoadScene(2);
    }

    public void Credits() {
        SceneManager.LoadScene(3);
    }

    public void Quit() {
        Application.Quit();
    }

    public void MainMenu() {
        SceneManager.LoadScene(0);
    }
}
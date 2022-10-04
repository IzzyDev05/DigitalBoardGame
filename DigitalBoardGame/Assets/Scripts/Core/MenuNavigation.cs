using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    [SerializeField] GameObject theme;

    public void StartGame() {
        SceneManager.LoadScene(1);
        Destroy(theme);
    }

    public void Rules() {
        SceneManager.LoadScene(2);
        DontDestroyOnLoad(theme);
    }

    public void Credits() {
        SceneManager.LoadScene(3);
        DontDestroyOnLoad(theme);
    }

    public void Quit() {
        Application.Quit();
    }

    public void MainMenu() {
        SceneManager.LoadScene(0);
    }
}
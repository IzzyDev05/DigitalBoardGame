using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuThemeSingleton : MonoBehaviour 
{
    public static MenuThemeSingleton instance;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }    

    private void Update() {
        if (SceneManager.GetActiveScene().buildIndex == 1) {
            Destroy(gameObject);
        }
    }
}
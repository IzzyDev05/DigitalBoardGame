using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    [SerializeField] private float transitionTime = 1f;
    private Animator animator;

    private void Start() {
        animator = GetComponentInChildren<Animator>();
    }

    public void StartGame() {
        StartCoroutine(LoadLevel(1));
    }

    public void Controls() {
        StartCoroutine(LoadLevel(2));
    }

    public void Credits() {
        StartCoroutine(LoadLevel(3));
    }

    public void Quit() {
        Application.Quit();
    }

    public void MainMenu() {
        StartCoroutine(LoadLevel(0));
    }

    private IEnumerator LoadLevel(int levelIndex) {
        animator.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
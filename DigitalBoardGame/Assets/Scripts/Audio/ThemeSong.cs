using UnityEngine;
using OTU.Core;

public class ThemeSong : MonoBehaviour 
{
    //public static ThemeSong instance;

    [SerializeField] private float cutoffFrequency;
    private AudioSource source;
    private AudioLowPassFilter lowPassFilter;

    /*
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
    */

    private void Start() {
        source = GetComponent<AudioSource>();
        lowPassFilter = GetComponent<AudioLowPassFilter>();
        source.Play();
    }

    private void Update() {
        if (GameManager.IsMenuOpen || GameManager.HasGameEnded) {
            lowPassFilter.cutoffFrequency = cutoffFrequency;
        }
        else {
            lowPassFilter.cutoffFrequency = 22000f;
        }
    }
}
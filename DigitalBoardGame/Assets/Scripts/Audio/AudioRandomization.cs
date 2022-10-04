using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandomization : MonoBehaviour
{
    private int rand;

    private AudioManager audioManager;

    private void Start() {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void RandomizeFootsteps() {
        rand = Random.Range(0, 3);

        if (rand == 0) {
            audioManager.Play("Footstep 1");
        }
        else if (rand == 1) {
            audioManager.Play("Footstep 2");
        }
        else if (rand == 2) {
            audioManager.Play("Footstep 3");
        }
    }
}

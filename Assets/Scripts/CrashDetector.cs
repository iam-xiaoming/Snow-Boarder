using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayAmount = 1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    // AudioSource audioSource;
    PlayerController playerController;
    bool hasCrashed = false;

    void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();    
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") && !hasCrashed)
        {
            crashEffect.Play();
            // audioSource.Play();

            // play sounds once time then disable controller
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            playerController.DisableControl();
            hasCrashed = true;
            Invoke("LoadScene", delayAmount);
        }
    }

    void LoadScene() {
        SceneManager.LoadScene(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    public GameObject dead;
    [SerializeField] ParticleSystem fnishedEffect;
    [SerializeField] AudioClip crashSFX;

    bool hasCrashed = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableContoller();
            fnishedEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            GameOver();
        }
    }
    void GameOver()
    {
        dead.SetActive(true);
    }
    void Update()
    {
        if(dead.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
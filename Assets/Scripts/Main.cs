using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public AudioClip startMusic;
    public int a;

    void Start()
    {
        Game_Music(startMusic);
    }

    public void Lose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Game_Music(AudioClip music)
    {
        GetComponent<AudioSource>().PlayOneShot(music);
    }
}

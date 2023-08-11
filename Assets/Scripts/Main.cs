using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public GameObject pausePanel;
    public AudioClip startMusic;
    public Player player;
    public Text goldCoinText, silverCoinText, copperCoinText;

    void Start()
    {
        PauseOff();
        Game_Music(startMusic);
    }

    void Update()
    {
        goldCoinText.text = player.goldCoin.ToString();
        silverCoinText.text = player.silverCoin.ToString();
        copperCoinText.text = player.copperCoin.ToString();
    }

    public void Lose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Game_Music(AudioClip music)
    {
        GetComponent<AudioSource>().PlayOneShot(music);
    }

    public void PauseOn()
    {
        Time.timeScale = 0f;
        player.enabled = false;
        pausePanel.SetActive(true);
    }

    public void PauseOff()
    {
        Time.timeScale = 1f;
        player.enabled = true;
        pausePanel.SetActive(false);
    }

    public void OpenScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}


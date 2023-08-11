using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjects : MonoBehaviour
{
    public string[] typeOfObject = {"goldCoin", "silverCoin", "copperCoin", "speedMashroom", "jumpMashroom", "slowtimeMashroom"};
    public int chooseType;
    public Player player;
    public AudioClip sound;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(chooseType)
        {
            case 0:
                player.goldCoin++;
                player.GetComponent<AudioSource>().PlayOneShot(sound);
                Destroy(gameObject);
                break;
            case 1:
                player.silverCoin++;
                player.GetComponent<AudioSource>().PlayOneShot(sound);
                Destroy(gameObject);
                break;
            case 2:
                player.copperCoin++;
                player.GetComponent<AudioSource>().PlayOneShot(sound);
                Destroy(gameObject);
                break;
            case 3:
                
                StartCoroutine(Waiting(1f,3));
                player.GetComponent<AudioSource>().PlayOneShot(sound);
                Destroy(gameObject);
                break;
            case 4:
                player.jump_height = player.jump_height * 1.5f;
                StartCoroutine(Waiting(5f,4));
                player.GetComponent<AudioSource>().PlayOneShot(sound);
                Destroy(gameObject);
                break;
            case 5:
                Time.timeScale = 0.5f;
                StartCoroutine(Waiting(5f,5));
                player.GetComponent<AudioSource>().PlayOneShot(sound);
                Destroy(gameObject);
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Waiting(float time, int typeObjt)
    {
        switch (typeObjt)
        {
            case 3:
                player.speed_of_player = player.speed_of_player * 2.5f;
                print("speed = " + player.speed_of_player);
                yield return new WaitForSeconds(time);
                player.speed_of_player = player.speed_of_player / 2.5f;
                print("speed = " + player.speed_of_player);
                break;
            case 4:
                
                player.jump_height = player.jump_height / 1.5f;
                break;
            case 5:
                
                Time.timeScale = 1f;
                break;
        }
    }
}

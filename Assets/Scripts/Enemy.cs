using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float dmg;
    public AudioClip sound;
    public float power_of_jump;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D enemy)
    {

        if (enemy.gameObject.tag == "Player")
        {
            player.GetComponent<AudioSource>().Stop();
            player.GetComponent<Player>().Audio(sound);
            player.GetComponent<Rigidbody2D>().AddForce(transform.up * power_of_jump, ForceMode2D.Impulse);
            StartCoroutine(ToDamage());
        }
    }

    void OnCollisionExit2D(Collision2D enemy)
    {
        if (enemy.gameObject.tag == "Player")
        StopAllCoroutines();
    }

    private IEnumerator ToDamage()
    {
                                                //Отнимаем dmg ед здоровья пока здоровье есть или пока корутина не будет остановлена
        while (player.GetComponent<Player>().curr_hp_of_player > 0)
        {
            player.GetComponent<Player>().RecountHp(dmg);
            yield return new WaitForSeconds(0.5f);
        }
    }
}

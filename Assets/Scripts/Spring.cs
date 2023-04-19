using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public AudioClip audioSprung;

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag=="Player" && (GameObject.Find("Player").GetComponent<Transform>().position.y - 0.8)  > transform.position.y)
        {
            GetComponent<Animator>().SetBool("isSprung",false);
            GetComponent<AudioSource>().PlayOneShot(audioSprung);
        }
    }

    public void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag=="Player")
        {
            GetComponent<Animator>().SetBool("isSprung",true);
        }
    }
}

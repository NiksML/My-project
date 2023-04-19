using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public AudioClip audioSprung;
    public float power_of_sprung;

    void Start()

    {
        PhysicsMaterial2D newMaterial = new PhysicsMaterial2D("Bouncy");
        newMaterial.bounciness = power_of_sprung;
        GetComponent<BoxCollider2D>().sharedMaterial = newMaterial;
    }
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

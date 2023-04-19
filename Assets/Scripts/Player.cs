using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    Animator anim;
    Rigidbody2D rb;
    AudioSource audioSource;
    public float speed_of_player;
    public float jump_height;
    public float curr_hp_of_player;
    public float max_hp_of_player=1000; 
    public Transform ground_check;
    bool on_ground;
    public Main main;

    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        curr_hp_of_player = max_hp_of_player;
    }

    void Update()
    {
        CheckY();
        Jump();
        CheckGround();
        if (Input.GetAxis("Horizontal") == 0 && on_ground)
        {
            anim.SetInteger("State", 1);
        }
        else
        {
            Flip(); 
            if(on_ground)
            {
                anim.SetInteger("State", 3);
            }
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed_of_player, rb.velocity.y);
    }

    void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
    void CheckY()
    {
        if (transform.position.y < -20)
        {
            Lose();
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && on_ground)
        {
            rb.AddForce(transform.up * jump_height, ForceMode2D.Impulse);
        }
    }

    void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(ground_check.position, 0.2f);
        on_ground = colliders.Length > 1;
        if (!on_ground)
        {
            anim.SetInteger("State", 2);
        }
    }

    public void RecountHp(float deltaHp)
    {
        curr_hp_of_player = curr_hp_of_player + deltaHp;
        print(curr_hp_of_player);
        if (curr_hp_of_player <= 0)
        {
            Lose();
        }
    }

    void Lose()
    {
        main.GetComponent<Main>().Lose();
    }

    public void Audio(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    }

    
}

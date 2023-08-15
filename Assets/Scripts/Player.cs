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
    bool inWater;
    bool isClimbing;
    public Transform ground_check;
    bool on_ground;
    public Main main;
    public bool[] keys;
    public bool[] buffs;
    public bool[] debaffs;
    public GameObject portal;
    bool can_tp = true;
    readonly float wait_time = 2;
    public int goldCoin = 0;
    public int silverCoin = 0;
    public int copperCoin = 0;
    public bool x_vel = true;
    public bool y_vel = false;

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
        Anime();
        
    }

    void Anime()
    {
        if (Input.GetAxis("Horizontal") == 0 && on_ground && !inWater && !isClimbing)
        {
            anim.SetInteger("State", 1);
        }

        else if(isClimbing)
        {
            if(Input.GetAxis("Vertical") == 0)
            {
                anim.SetInteger("State", 5);
            }
            else
            {
                anim.SetInteger("State", 6);
            }
        }

        else
        {
            Flip();
            if (on_ground && !inWater)
            {
                anim.SetInteger("State", 3);
            }
            else if(inWater)
            {
                anim.SetInteger("State", 4);
            }
        }
    }

    void FixedUpdate()
    {
        Moving(x_vel, y_vel);
    }

    public void Moving(bool xIsOn, bool yIsOn)
    {
        switch(xIsOn, yIsOn)
        {
            case (true,false) :
                
                rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed_of_player, rb.velocity.y);
                break;
            case(true,true) :
                rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed_of_player, Input.GetAxis("Vertical") * speed_of_player);
                break;
        }
        
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
        if (transform.position.y < -30)
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
        if (!on_ground && !y_vel)
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            keys[collision.GetComponent<Key>().number_key] = true;
            Destroy(collision.gameObject);
        }
    }

    IEnumerator Wait_For_TP()
    {
        yield return new WaitForSeconds(wait_time);
        can_tp = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Portal")
        {
            int number_of_portal = collision.GetComponent<Portal>().number_of_portal;
            if (keys[number_of_portal] == true)
            {
                collision.GetComponent<Portal>().OpenDoor();
            }

            if (collision.GetComponent<Portal>().isOpen == true && can_tp)
            {
                collision.GetComponent<Portal>().TP(gameObject);
                can_tp = false;
                StartCoroutine(Wait_For_TP());
            }
        }

        if (collision.gameObject.tag == "Ladder")
        {
            isClimbing = true;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            if (Input.GetAxis("Vertical") !=0)
            {
                rb.velocity = new Vector2(rb.velocity.x, Input.GetAxis("Vertical") * speed_of_player * 0.5f);
            }
            else
            {       
                rb.velocity = new Vector2(rb.velocity.x, 0f);
            }
        }

        if (collision.gameObject.tag == "Water")
        {
            inWater = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            isClimbing = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            rb.velocity = new Vector2(rb.velocity.x, Input.GetAxis("Vertical") * speed_of_player);
        }

        if (collision.gameObject.tag == "Water")
        {
            inWater = false;
        }
    }

   /* public void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Tilemap_ground" && rb.bodyType == RigidbodyType2D.Kinematic)
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            
        }
    }*/


}

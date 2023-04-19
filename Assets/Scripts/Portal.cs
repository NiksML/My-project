using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform second_potal;
    bool can_tp = true;
    public int number_of_portal;
    public GameObject player;
    public bool isOpen = false;
    public Sprite opened_Door_top, opened_Door_mid;

    // Start is called before the first frame update
    public void OpenDoor()
    {
        if (player.GetComponent<Player>().keys[number_of_portal] == true) 
        { 
            GetComponent<SpriteRenderer>().sprite = opened_Door_top;
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = opened_Door_mid;
            isOpen = true;
        }
    }

    public void TP(GameObject player)
    {
        if (isOpen && can_tp)
        {
            this.player.transform.position = new Vector3(second_potal.transform.position.x, second_potal.transform.position.y, player.transform.position.z);
        }
    }
}

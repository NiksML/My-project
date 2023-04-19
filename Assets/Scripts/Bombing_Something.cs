using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombing_Something : MonoBehaviour
{
    public GameObject bullet;
    public float speed;
    public float wait_for_shoot;
    public Transform shoot_position;
    public bool can_shoot;
    public Transform parent;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (can_shoot)
        {
            GameObject clone = Instantiate(bullet, shoot_position.position, transform.rotation, parent);
            clone.GetComponent<Enemy>().player = player;
            can_shoot = false;
            StartCoroutine(Wait_Shooting());
        }
    }

    IEnumerator Wait_Shooting()
    {
        yield return new WaitForSeconds(wait_for_shoot);
        can_shoot = true;
    }
}

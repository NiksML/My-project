using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air_Enemy_2Points : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public float speed;
    Transform buffer;
    public float wait;
    bool can_move = true;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(point2.transform.position.x, point2.transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(can_move)
        {
            transform.position = Vector3.MoveTowards(transform.position, point1.position, speed * Time.deltaTime);
            if (transform.position == point1.position)
            {
                buffer = point2;
                point2 = point1;
                point1 = buffer;
                can_move = false;
                StartCoroutine(Waiting_Before_Going());
            }
        }
        
    }

    IEnumerator Waiting_Before_Going()
    {
        yield return new WaitForSeconds(wait);
        if (transform.rotation.y == 0)
        {
            transform.eulerAngles = new Vector3(0,180,0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0,0,0);
        }
        can_move = true;
    }
}

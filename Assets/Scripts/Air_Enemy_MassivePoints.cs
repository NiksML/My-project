using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air_Enemy_MassivePoints : MonoBehaviour
{
    public Transform[] points;
    public float speed;
    public float wait;
    bool can_move = true;
    int  i = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(points[0].position.x, points[0].position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(can_move)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
            if (transform.position == points[i].position)
            {
                if(i < points.Length - 1)
                {
                    i++;
                }
                else
                {
                    i=0;
                }
                can_move = false;
                StartCoroutine(Waiting());
                
            }
        }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(wait);
        can_move = true;
    }
}

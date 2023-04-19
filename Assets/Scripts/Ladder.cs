using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public int lenth_of_ladder;
    public GameObject ladder_mid;
    public Transform parent;
    public Transform pos;
    BoxCollider2D m_size;
    // Start is called before the first frame update
    void Awake()
    {
        m_size = GetComponent<BoxCollider2D>();

        for (int i = 0; i < lenth_of_ladder; i++)
        {
            
            pos.position = new Vector3(pos.position.x, pos.position.y - 1.0f, pos.position.z);
            Instantiate(ladder_mid, pos.position, transform.rotation, parent);
            GetComponent<BoxCollider2D>().size = new Vector2(m_size.size.x , m_size.size.y+1f);
            GetComponent<BoxCollider2D>().offset = new Vector2(m_size.offset.x, m_size.offset.y - 0.5f);
        }
        
    }
}

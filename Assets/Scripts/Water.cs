using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Waves());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Waves()
    {
        transform.localScale = new Vector3(1,1,1);
        yield return new WaitForSeconds(0.5f);
        transform.localScale = new Vector3(-1,1,1);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Waves());
    }
}

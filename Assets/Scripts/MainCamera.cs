using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public float speed_of_camera;
    public Transform target;

    void Start()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
    }

    void FixedUpdate()
    {
        Vector3 position = target.position;
        position.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, position, speed_of_camera * Time.deltaTime);
    }

}

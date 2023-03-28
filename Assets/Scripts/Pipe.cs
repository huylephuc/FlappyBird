using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private float speed = 0.25f;

    void Start()
    {

    }

    void Update()
    {
        transform.position -= new Vector3(speed, 0); 
    }
}

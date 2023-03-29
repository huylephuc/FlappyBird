using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private float speed = 2.5f;

    void Update()
    {
        transform.position -= new Vector3(speed, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float speed = 2f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(speed*Time.deltaTime, 0, 0);
    }
}

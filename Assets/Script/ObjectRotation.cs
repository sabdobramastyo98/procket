﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    public float speed = 2f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate( 0, 0, speed);        
    }
}

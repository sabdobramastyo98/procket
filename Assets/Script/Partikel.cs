using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partikel : MonoBehaviour
{
    ParticleSystem myParticle;
    // Start is called before the first frame update
    void Start()
    {
        myParticle = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            myParticle.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            myParticle.Play();
        }

        if(Input.GetMouseButtonUp(0))
        {
            myParticle.Stop();
        }
    }
}

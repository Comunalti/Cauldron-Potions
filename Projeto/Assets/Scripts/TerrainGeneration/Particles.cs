using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    public bool water;
    public bool cauldron;

    public ParticleSystem waterParticles;
    public ParticleSystem cauldronParticles;

    // Start is called before the first frame update
    void Start()
    {
        if (water)
        {
            waterParticles.Play();
        }
        else
        {
            waterParticles.Stop();
        }

        if (cauldron)
        {
            cauldronParticles.Play();
        }
        else
        {
            cauldronParticles.Stop();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
}

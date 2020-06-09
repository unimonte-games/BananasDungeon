using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticulaDestrutiva : MonoBehaviour
{
    void Start()
    {
        float tempo = GetComponent<ParticleSystem>().main.duration;
        Destroy(gameObject, tempo);
    }
}
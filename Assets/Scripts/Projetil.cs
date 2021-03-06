﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    public GameObject Atirador;
    Vector3 posInicial;
    public float velocidade = 3;
    public GameObject ParticulaDano;

    void Start()
    {
        posInicial = Atirador.transform.position;
    }

    void Update()
    {
        if ((transform.position - posInicial).magnitude > 20)
            Destroy(gameObject);
        else
            transform.Translate(Vector3.forward * velocidade * Time.deltaTime);
    }

    void OnTriggerEnter (Collider c)
    {
        if (c.gameObject.tag == "Enemy")
        {
            Instantiate(ParticulaDano, transform.position, Quaternion.identity);
            
            Destroy(gameObject);
        }
    }
}
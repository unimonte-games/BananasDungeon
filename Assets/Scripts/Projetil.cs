using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    public GameObject Atirador;
    Vector3 posInicial;
    public float velocidade = 3;

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

    void OnCollisionEnter (Collision colisor)
    {
        print("Bateu porra");
        if (colisor.gameObject.tag == "Enemy")
        {
            Destroy(colisor.gameObject);
            Destroy(gameObject);
        }
    }
}
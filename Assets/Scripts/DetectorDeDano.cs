using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorDeDano : MonoBehaviour
{
    public GameObject Principal = null;
    public DanoArma Dano;
    public AudioClip SomDano;
    public AudioSource DisparadordeSons;


    void Awake()
    {
        DisparadordeSons = GameObject.Find("EfeitoSonoro").GetComponent<AudioSource>();
        Dano = GetComponent<DanoArma>();
    }

    void OnTriggerEnter(Collider other)
    {
        switch (Principal.tag)
        {
            case "Player":
                if (other.CompareTag("Enemy"))
                {
                    var ctrArma = Principal.GetComponent<ControleDeArmas>();
                    var danoArma = ctrArma.PegarArma().GetComponent<DanoArma>();
                    var atb = other.GetComponent<Atributos>();
                    
                    int danoCalculado = (int)(danoArma.Dano * ctrArma.multi);
                    int variacao = Random.Range(-5, 6);
                    atb.CausarDano(ctrArma.PegarArma().GetComponent<NivelArma>().arma, danoCalculado + variacao);
                }
                break;
            case "Enemy":
                break;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectorDeDano : MonoBehaviour
{
    public GameObject Principal = null;
    public DanoArma Dano;
    public AudioClip SomDano;
    public AudioSource DisparadordeSons;


    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Jogo")
            DisparadordeSons = GameObject.Find("EfeitoSonoro").GetComponent<AudioSource>();
            
        Dano = GetComponent<DanoArma>();
    }

    public ControleDeArmas ctrArma;
    public DanoArma danoArma ;
    public Atributos atb;

    void OnTriggerEnter(Collider other)
    {
        switch (Principal.tag)
        {
            case "Player":
                print("Player: " + other.tag);
                if (other.CompareTag("Enemy"))
                {
                    ControleDeArmas ctrArma = Principal.GetComponent<ControleDeArmas>();
                    DanoArma danoArma = GetComponent<DanoArma>();
                    Atributos atb = other.GetComponent<Atributos>();
                    
                    int danoCalculado = (int)(danoArma.Dano * ctrArma.multi);
                    int variacao = Random.Range(-5, 6);
                    atb.CausarDano(ctrArma.PegarArma().GetComponent<NivelArma>().arma, danoCalculado + variacao);
                }
                break;
            case "Enemy":
                print("Enemy: " + other.tag);
                if (other.CompareTag("Player"))
                {
                    danoArma = GetComponent<DanoArma>();
                    atb = other.GetComponent<Atributos>();
                    // DanoArma danoArma = GetComponent<DanoArma>();
                    // Atributos atb = other.GetComponent<Atributos>();
                    
                    int danoCalculado = (int)(danoArma.Dano);
                    int variacao = Random.Range(-5, 6);
                    atb.CausarDano(Dados.Armas.Nenhum, danoCalculado + variacao);
                }
                break;
        }
    }
}
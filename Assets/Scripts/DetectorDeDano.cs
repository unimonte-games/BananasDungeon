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

    public ControleDeArmas ctrArma;
    public DanoArma danoArma;
    public Atributos atb;


    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Jogo")
            DisparadordeSons = GameObject.Find("EfeitoSonoro").GetComponent<AudioSource>();

        Dano = GetComponent<DanoArma>();
    }

    void Update()
    {
        switch (Principal.tag)
        {
            case "Player":
                if (Principal.GetComponent<ControleDeAnimacao>().Atacando)
                    GetComponent<BoxCollider>().enabled = true;
                else
                    GetComponent<BoxCollider>().enabled = false;
                break;
            case "Enemy":
                if (Principal.GetComponent<ControledeAnimacaoInimigo>().Atacando)
                    GetComponent<CapsuleCollider>().enabled = true;
                else
                    GetComponent<CapsuleCollider>().enabled = false;
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        switch (Principal.tag)
        {
            case "Player":
                print("Player: " + other.tag);
                if (!Principal.GetComponent<ControleDeAnimacao>().Atacando && GetComponent<NivelArma>().arma != Dados.Armas.Arco && GetComponent<NivelArma>().arma != Dados.Armas.Cajado)
                    return;

                if (other.CompareTag("Enemy"))
                {
                    ControleDeArmas ctrArma = Principal.GetComponent<ControleDeArmas>();
                    DanoArma danoArma = GetComponent<DanoArma>();
                    Atributos atb = other.GetComponent<Atributos>();

                    DisparadordeSons.PlayOneShot(SomDano);

                    int danoCalculado = (int)(danoArma.Dano * ctrArma.multi);

                    if (atb.Especialidade == ctrArma.arma)
                        danoCalculado = (int)(danoArma.Dano * atb.multiEspecialidade);

                    float variacao = Random.Range(.9f, 1.1f);
                    atb.CausarDano(ctrArma.PegarArma().GetComponent<NivelArma>().arma, (int)(danoCalculado * variacao));
                }
                break;
            case "Enemy":
                print("Enemy: " + other.tag);
                if (!Principal.GetComponent<ControledeAnimacaoInimigo>().Atacando)
                    return;

                if (other.CompareTag("Player"))
                {
                    danoArma = GetComponent<DanoArma>();
                    atb = other.GetComponent<Atributos>();

                    DisparadordeSons.PlayOneShot(SomDano);

                    int danoCalculado = (int)(danoArma.Dano);
                    int variacao = Random.Range(-5, 6);
                    atb.CausarDano(Dados.Armas.Nenhum, danoCalculado + variacao);
                }
                break;
        }
    }
}
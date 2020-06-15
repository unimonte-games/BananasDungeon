using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Atributos : MonoBehaviour
{
    public Dados.Personagens Personagem;
    public Dados.Armas Especialidade = Dados.Armas.Nenhum;
    public float multiEspecialidade = 1.2f;
    public int Vida = 1000;
    public int vidaAtual = 1000;
    public int Regeneracao = 10;
    public float DelayRegen = 3f;
    public Slider barraVida;
    [Space(20)]
    AudioSource SFX;
    public AudioClip SomDano;
    public AudioClip SomMorte;
    public GameObject ParticulaDano;
    public GameObject ParticulaMorte;


    void Start()
    {
        SFX = GameObject.Find("SFX").GetComponent<AudioSource>();
        if (SceneManager.GetActiveScene().name != "Jogo")
            return;
        
        if (gameObject.CompareTag("Player"))
        {
            barraVida.maxValue = Vida;
            barraVida.value = vidaAtual;
            InvokeRepeating("RegenVida", 1, DelayRegen);
        }
    }

    void RegenVida()
    {
        if(vidaAtual < Vida)
        {
            vidaAtual += Regeneracao;
            barraVida.value = vidaAtual;
        }
    }

    public void CausarDano(int Dano)
    {
        vidaAtual -= (int)(Dano);
        if (vidaAtual <= 0)
        {
            SFX.PlayOneShot(SomMorte);
            if (gameObject.CompareTag("Player") && !GetComponent<ControleDeAnimacao>().Morto)
            {
                barraVida.value = 0;
                barraVida.value = vidaAtual;
                GetComponent<ControleDeAnimacao>().Morte();
                Instantiate(ParticulaMorte, transform.position, new Quaternion(-90, 0, 0, 0));
            }

            if (gameObject.CompareTag("Enemy") && !GetComponent<ControledeAnimacaoInimigo>().Morto)
            {
                GetComponent<ControledeAnimacaoInimigo>().Morte();
                var ini = GetComponent<Inimigo>();
                ini.Drop();
                if (ini.TipoInimigo == Inimigo.Tipo.Boss)
                    FindObjectOfType<PortalFinal>().AtivarPortal();
            }
        }
        else
        {
            if (gameObject.CompareTag("Player"))
            {
                Instantiate(ParticulaDano, transform.position, Quaternion.identity);
                barraVida.value = vidaAtual;
            }

            SFX.PlayOneShot(SomDano);
        }
    }
}
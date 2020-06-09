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
    public Slider barraVida;
    [Space(20)]
    AudioSource SFX;
    public AudioClip SomDano;
    public AudioClip SomMorte;
    public GameObject ParticulaDano;
    public GameObject ParticulaMorte;


    void Awake()
    {
        SFX = GameObject.Find("SFX").GetComponent<AudioSource>();
        if (SceneManager.GetActiveScene().name != "Jogo")
            return;
        
        if (gameObject.CompareTag("Player"))
        {
            var aux = GetComponent<Move>().playerIndice;
            barraVida.maxValue = Vida;
            barraVida.value = vidaAtual;
        }
    }

    public void CausarDano(int Dano)
    {
        vidaAtual -= (int)(Dano);
        Instantiate(ParticulaDano, transform.position, Quaternion.identity);
        if (vidaAtual <= 0)
        {
            SFX.PlayOneShot(SomMorte);
            if (gameObject.CompareTag("Player"))
            {
                barraVida.value = 0;
                barraVida.value = vidaAtual;
                GetComponent<ControleDeAnimacao>().Morte();
                Instantiate(ParticulaMorte, transform.position, Quaternion.identity);
            }
            else
                GetComponent<ControledeAnimacaoInimigo>().Morte();
        }
        else
            SFX.PlayOneShot(SomDano);
    }
}
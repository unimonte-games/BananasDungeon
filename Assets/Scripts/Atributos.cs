using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Atributos : MonoBehaviour
{
    public Dados.Personagens Personagem;
    public Dados.Armas Especialidade = Dados.Armas.Nenhum;
    public int Vida = 1000;
    public int vidaAtual = 1000;
    public Slider barraVida;


    void Awake()
    {
        if (SceneManager.GetActiveScene().name != "Game")
            return;
        
        if (gameObject.CompareTag("Player"))
        {
            var aux = GetComponent<Move>().playerIndice;
            barraVida.maxValue = Vida;
            barraVida.value = vidaAtual;
        }
    }

    public void CausarDano(Dados.Armas arma, int Dano)
    {
        float multiEspecialidade = 1;
        switch (arma)
        {
            case Dados.Armas.Nenhum:
                multiEspecialidade = 1f;
                break;
            default:
                multiEspecialidade = 1.5f;
                break;
        }

        vidaAtual -= (int)(Dano * multiEspecialidade);

        if (vidaAtual <= 0)
        {
            if (gameObject.CompareTag("Player"))
            {
                barraVida.value = 0;
                GetComponent<ControleDeAnimacao>().Morte();
            }
            else
            {
                barraVida.value = vidaAtual;
                GetComponent<ControledeAnimacaoInimigo>().Morte();
            }
        }
    }
}
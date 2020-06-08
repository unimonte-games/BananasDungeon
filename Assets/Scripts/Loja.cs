using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Loja : MonoBehaviour
{
    public GameObject loja;
    public Text Titulo;
    public float delayBotao = .3f;
    public float delayTempo = .3f;
    Dados.Personagens Personagem;
    Dados.Armas Arma;
    public Dados.PlayerIndice Player;
    [Space(20)]
    public Item[] Itens;
    [System.Serializable]
    public struct Item
    {
        public Dados.Armas Arma;
        public GameObject[] ArmaNiveis;
    }
    int indice = 0;
    [Space(20)]
    AudioSource EfeitoSonoros;
    public AudioClip SomClick;


    void Awake()
    {
        IniciaNivelArma();
    }

    void Update()
    {
        if (Player == Dados.PlayerIndice.Vazio)
            return;

        delayTempo += Time.deltaTime;

        if (Input.GetButtonDown(Player.ToString() + "RB") && delayTempo > delayBotao)//Próximo
        {
            delayTempo = 0;
            ArmaSeguinte();
        }

        if (Input.GetButtonDown(Player.ToString() + "LB") && delayTempo > delayBotao)//Anterior
        {
            delayTempo = 0;
            ArmaAnterior();
        }

        if (Input.GetButtonDown(Selecionados.VezLoja.ToString() + "B"))
        {
            Selecionados.VezLoja = Dados.PlayerIndice.Vazio;
            FecharLoja();
        }

        if (Input.GetButtonDown(Player.ToString() + "A") && delayTempo > delayBotao)//Selecionar Arma
        {

        }
    }

    public void IniciaNivelArma()
    {
        for (int x = 0; x < Itens.Length; x++)
        {
            for (int y = 0; y < Itens[x].ArmaNiveis.Length; y++)
            {
                Itens[x].ArmaNiveis[y].GetComponent<NivelArma>().DefinirNivel((Dados.ArmaNivel)y);
            }
        }
    }

    public void ArmaSeguinte()
    {
        indice += 1;
        TrocaArma();
    }

    public void ArmaAnterior()
    {
        indice -= 1;
        TrocaArma();
    }

    public void TrocaArma()
    {
        if (indice > Itens.Length - 1)
            indice = 0;

        if(indice < 0)
            indice = Itens.Length - 1;

        for (int x = 0; x < Itens.Length; x++)
        {
            if (x == indice)
                TrocaTitulo(Itens[x].Arma);

            for (int y = 0; y < Itens[x].ArmaNiveis.Length; y++)
            {
                Itens[x].ArmaNiveis[y].SetActive(x == indice);
            }
        }
    }

    public void DefinirArma(Dados.Armas a)
    {
        int NivelDesbloqueio = 0;
        for (int x = 0; x < AutoSave.ArmasNiveis.Count; x++)
        {
            if (AutoSave.ArmasNiveis[x].arma == a)
            {
                NivelDesbloqueio = (int)AutoSave.ArmasNiveis[x].nivel;
            }
        }

        for (int x = 0; x < Itens.Length; x++)
        {
            bool ativar = Itens[x].Arma == Arma;
            if (ativar)
                indice = x;
            for (int y = 0; y < Itens[x].ArmaNiveis.Length; y++)
            {
                Itens[x].ArmaNiveis[y].SetActive(ativar);
                Itens[x].ArmaNiveis[y].GetComponentInParent<Image>().color = NivelDesbloqueio >= y ? Color.yellow : Color.gray;
            }
        }
        TrocaTitulo(a);
    }

    void TrocaTitulo(Dados.Armas a)
    {
        Titulo.text = string.Format("{0} - {1}", Player.ToString(), NomeArma(a));
    }

    string NomeArma(Dados.Armas a)
    {
        switch (a)
        {
            case Dados.Armas.Lanca:
                return "Lança";
            default:
                return a.ToString();
        }
    }

    public void AbrirLoja(GameObject gbj)
    {
        Selecionados.LojaAberta = true;
        Player = gbj.GetComponent<Move>().playerIndice;
        Personagem = gbj.GetComponent<Atributos>().Personagem;
        Arma = gbj.GetComponent<ControleDeArmas>().arma;
        loja.SetActive(true);
        DefinirArma(Arma);
    }

    public void FecharLoja()
    {
        loja.SetActive(false);
        Selecionados.LojaAberta = false;
        Arma = Dados.Armas.Nenhum;
        Personagem = Dados.Personagens.Nenhum;
        Player = Dados.PlayerIndice.Vazio;
    }
}
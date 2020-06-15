using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Loja : MonoBehaviour
{
    public GameObject loja;
    public Text Titulo;
    public Text txtSangue;
    public float delayBotao = .3f;
    public float delayTempo = .3f;
    GameObject alvoLoja = null;
    Dados.Personagens Personagem;
    Dados.Armas Arma;
    Dados.ArmaNivel ArmaNivel;
    public Dados.PlayerIndice Player;
    [Space(20)]
    public Text[] txtValorNivel;

    public Item[] Itens;
    [System.Serializable]
    public struct Item
    {
        public Dados.Armas Arma;
        public GameObject[] ArmaNiveis;
    }
    int indice = 0;
    AudioSource SFX;
    [Space(20)]
    public AudioClip SomClick;


    void Awake()
    {
        IniciaNivelArma();
        txtSangue.text = AutoSave.Sangue.ToString();
        SFX = GameObject.Find("SFX").GetComponent<AudioSource>();
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

        if (Input.GetButtonDown(Selecionados.VezLoja.ToString() + "Y"))
        {
            print("Upgrade da arma");
            if (ArmaNivel != Dados.ArmaNivel.Nivel5)
            {
                if (AutoSave.Sangue >= Dados.CustoNivel[(int)ArmaNivel + 1])
                {
                    AutoSave.AtualizarSangue(Dados.CustoNivel[(int)ArmaNivel + 1], false);
                    AutoSave.AtualizarArma(Personagem, Itens[indice].Arma);
                    AutoSave.AtualizarNivelArma(Itens[indice].Arma);
                    TrocaArma();
                    txtSangue.text = AutoSave.Sangue.ToString();
                }
            }
        }

        if (Input.GetButtonDown(Player.ToString() + "A") && delayTempo > delayBotao)//Selecionar Arma
        {
            SFX.PlayOneShot(SomClick);
            alvoLoja.GetComponent<ControleDeArmas>().AtivarArma(Itens[indice].Arma, AutoSave.QualNivel(Itens[indice].Arma));
            TrocaArma();
        }

        if (Input.GetButtonDown(Selecionados.VezLoja.ToString() + "B"))
            FecharLoja();
    }

    public void IniciaNivelArma()
    {
        for (int x = 0; x < Itens.Length; x++)
        {
            for (int y = 0; y < Itens[x].ArmaNiveis.Length; y++)
            {
                Itens[x].ArmaNiveis[y].GetComponent<NivelArma>().DefinirNivel((Dados.ArmaNivel)y);
                Itens[x].ArmaNiveis[y].GetComponent<DetectorDeDano>().enabled = false;
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
        SFX.PlayOneShot(SomClick);
        if (indice > Itens.Length - 1)
            indice = 0;

        if(indice < 0)
            indice = Itens.Length - 1;

        TrocaTitulo(Itens[indice].Arma);
        for (int x = 0; x < Itens.Length; x++)
        {
            Dados.ArmaNivel nArma = 0;
            for (int y = 0; y < AutoSave.ArmasNiveis.Count; y++)
            {
                if (Itens[x].Arma == AutoSave.ArmasNiveis[y].arma)
                    nArma = AutoSave.ArmasNiveis[y].nivel;
            }

            for (int y = 0; y < Itens[x].ArmaNiveis.Length; y++)
            {
                Itens[x].ArmaNiveis[y].SetActive(x == indice);

                if (x == indice)
                {
                    txtValorNivel[y].text = "";

                    if (y <= (int)nArma)
                        Itens[x].ArmaNiveis[y].GetComponentInParent<Image>().color = Color.white;

                    if (y == (int)nArma && Arma == Itens[x].Arma)
                        Itens[x].ArmaNiveis[y].GetComponentInParent<Image>().color = Color.yellow;
                    else
                        Itens[x].ArmaNiveis[y].GetComponentInParent<Image>().color = Color.white;

                    if (y > (int)nArma)
                    {
                        Itens[x].ArmaNiveis[y].GetComponentInParent<Image>().color = Color.gray;
                        txtValorNivel[y].text = Dados.CustoNivel[y].ToString();
                    }
                }
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
                txtValorNivel[y].text = "";

                if (NivelDesbloqueio < y)
                    Itens[x].ArmaNiveis[y].GetComponentInParent<Image>().color = Color.white;

                if (NivelDesbloqueio == y)
                    Itens[x].ArmaNiveis[y].GetComponentInParent<Image>().color = Color.yellow;

                if (NivelDesbloqueio > y)
                {
                    Itens[x].ArmaNiveis[y].GetComponentInParent<Image>().color = Color.gray;
                    txtValorNivel[y].text = Dados.CustoNivel[y].ToString();
                }
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

    public void CarregarDadosSave()
    {
        Player = alvoLoja.GetComponent<Move>().playerIndice;
        Personagem = alvoLoja.GetComponent<Atributos>().Personagem;
        Arma = alvoLoja.GetComponent<ControleDeArmas>().arma;
        for (int x = 0; x < AutoSave.ArmasNiveis.Count; x++)
        {
            if (AutoSave.ArmasNiveis[x].arma == Arma)
            {
                ArmaNivel = AutoSave.ArmasNiveis[x].nivel;
                break;
            }
        }
    }

    public void AbrirLoja(GameObject gbj)
    {
        Selecionados.LojaAberta = true;
        Selecionados.VezLoja = gbj.GetComponent<Move>().playerIndice;
        alvoLoja = gbj;
        CarregarDadosSave();
        loja.SetActive(true);
        DefinirArma(Arma);
    }

    public void FecharLoja()
    {
        Selecionados.VezLoja = Dados.PlayerIndice.Vazio;
        loja.SetActive(false);
        alvoLoja = null;
        Selecionados.LojaAberta = false;
        Personagem = Dados.Personagens.Nenhum;
        Player = Dados.PlayerIndice.Vazio;
        Arma = Dados.Armas.Nenhum;
        ArmaNivel = Dados.ArmaNivel.Nivel1;
    }
}
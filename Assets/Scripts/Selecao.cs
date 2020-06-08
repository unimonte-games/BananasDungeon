using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Selecao : MonoBehaviour
{
    public Text txtTimer;
    public SelecaoDePersonagem[] selecao;
    bool liberaTimer = false;
    float timer = 6;
    [Space(20)]
    public AudioSource SFX;
    public AudioClip SomClick;
    public AudioClip SomStart;


    void Start()
    {
        txtTimer.text = "";
        SFX = GameObject.Find("SFX").GetComponent<AudioSource>();
    }

    void Update()
    {
        if (liberaTimer)
        {
            timer -= Time.deltaTime;
            if (timer <= 1)
            {
                Contagem(false);
                SceneManager.LoadScene("Jogo");
            }
            else
                txtTimer.text = string.Format("Começando em {0}...", (int)timer);
        }

        if (Input.GetButtonDown("P1Start"))
        {
            bool SelecionarP1 = false;
            for (int x = 0; x < selecao.Length; x++)
            {
                if (selecao[x].playerIndice == Dados.PlayerIndice.P1)
                    SelecionarP1 = selecao[x].Selecao;
            }

            if (SelecionarP1)
            {
                bool Iniciar = true;
                
                for (int x = 0; x < selecao.Length; x++)
                {
                    if (selecao[x].Selecao && !selecao[x].Confirmado)
                        Iniciar = false;
                }

                if (Iniciar)
                {
                    Selecionados.Jogadores.Clear();
                    SFX.PlayOneShot(SomStart);
                    Contagem(true);
                }
            }
        }

        if (Input.GetButtonDown("P1B"))
        {
            SFX.PlayOneShot(SomClick);
            Contagem(false);
        }
    }

    void Contagem(bool Iniciar)
    {
        if (Iniciar)
        {
            liberaTimer = true;
            if (Selecionados.Jogadores.Count == 0)
            {
                for (int x = 0; x < selecao.Length; x++)
                {
                    Selecionados.Jogadores.Add(selecao[x].PersonagemSelecionado);
                }
            }
        }
        else
        {
            txtTimer.text = "";
            timer = 6;
            liberaTimer = false;
        }
    }

    public bool PodeSelecionar(Dados.Personagens person)
    {
        bool pode = true;
        for (int x = 0; x < selecao.Length; x++)
        {
            if (selecao[x].Person == person && selecao[x].Confirmado)
                return false;
        }

        return pode;
    }
}
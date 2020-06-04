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


    void Start()
    {
        txtTimer.text = "";
    }

    void Update()
    {
        for (int x = 1; x < 9; x++)
        {
            for (int y = 0; y < 20; y++)
            {
                if (Input.GetKeyDown("joystick " + x.ToString() + " button " + y.ToString()))
                    print("joystick" + x + "button " + y);
            }
        }

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
                print("Seleção: " + "P1Start");
                bool Iniciar = true;
                
                for (int x = 0; x < selecao.Length; x++)
                {
                    if (selecao[x].Selecao && !selecao[x].Confirmado)
                        Iniciar = false;
                }

                if (Iniciar)
                {
                    Selecionados.Jogadores.Clear();
                    Contagem(true);
                }
            }
        }

        if (Input.GetButtonDown("P1B"))
        {
            print("P1B");
            Contagem(false);
        }
    }

    void Contagem(bool Iniciar)
    {
        if (Iniciar)
        {
            print("Inicio da contagem");
            liberaTimer = true;
            if (Selecionados.Jogadores.Count == 0)
            {
                print("Adicionando jogadores: " + selecao.Length);
                for (int x = 0; x < selecao.Length; x++)
                {
                    print(selecao[x].PersonagemSelecionado.playerIndice.ToString());
                    print(selecao[x].PersonagemSelecionado.personagem.ToString());
                    Selecionados.Jogadores.Add(selecao[x].PersonagemSelecionado);
                }
                print("Adicionado jogadores: " + selecao.Length);
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Selecao : MonoBehaviour
{
    public Text txtTimer;
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
            var sp = FindObjectsOfType<SelecaoDePersonagem>();
            for (int x = 0; x < sp.Length; x++)
            {
                if (sp[x].playerIndice == Dados.PlayerIndice.P1)
                {
                    SelecionarP1 = sp[x].Selecao;
                }
            }
            if (SelecionarP1)
            {
                print("Seleção: " + "P1Start");
                bool Iniciar = true;
                var players = FindObjectsOfType<SelecaoDePersonagem>();
                
                for (int x = 0; x < players.Length; x++)
                {
                    if (players[x].Selecao && !players[x].Confirmado)
                        Iniciar = false;
                }
                

                if (Iniciar)
                    Contagem(true);
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
            liberaTimer = true;
        else
        {
            txtTimer.text = "";
            timer = 6;
            liberaTimer = false;
        }
    }

    public bool PodeSelecionar(Dados.Personagens person)
    {
        var ps = FindObjectsOfType<SelecaoDePersonagem>();
        bool pode = true;
        for (int x = 0; x < ps.Length; x++)
        {
            if (ps[x].Person == person && ps[x].Confirmado)
                return false;
        }

        return pode;
    }
}
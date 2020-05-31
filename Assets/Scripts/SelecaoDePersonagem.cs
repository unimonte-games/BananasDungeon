using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelecaoDePersonagem : MonoBehaviour
{
    public Text txtBotaoPlayer;
    public GameObject[] Personagens;
    public int indice = 0;

    public bool Selecao = false;
    public Move.PlayerIndice playerIndice;
    public AutoSave.Players Person = AutoSave.Players.Nenhum;
    public bool Confirmado = false;


    void Start()
    {
        print("Seleção de personagem");
        if (Personagens.Length == 0)
            txtBotaoPlayer.text = "Em breve...";

        for (int x = 0; x < Personagens.Length; x++)
        {
            Personagens[x].GetComponent<Rigidbody>().isKinematic = true;
            Personagens[x].GetComponent<AudioListener>().enabled = false;
            Personagens[x].GetComponent<Move>().enabled = false;
            Personagens[x].GetComponent<ControleDeAnimacao>().Idle(1);

            Personagens[x].SetActive(false);
            print("ué");
        }
    }

    void Update()
    {
        if (Personagens.Length == 0)
            return;

        if (Input.GetButtonDown(playerIndice.ToString() + "Start") && !Selecao)
        //if (Input.GetButtonDown("joystick " + playerIndice.ToString().Substring(1, 1) + " button 7") && !Selecao)
        {
            print(playerIndice.ToString() + "Start");
            Selecao = true;
            Debug.Log(Personagens.Length, gameObject);
            Personagens[0].SetActive(true);
            Personagens[0].GetComponent<ControleDeAnimacao>().Idle(1);
            Person = Personagens[0].GetComponent<Atributos>().Personagem;
            print("Ativa porra");
        }

        if (Selecao)
        {
            switch (Input.GetAxis(playerIndice.ToString() + "Right/Left"))
            {
                case 1:
                    MudarPersonagem(indice++);
                    break;
                case -1:
                    MudarPersonagem(indice--);
                    break;
            }

            if (Input.GetButtonDown(playerIndice.ToString() + "A"))
            {
                print("A");
                if (FindObjectOfType<Selecao>().PodeSelecionar(Person))
                {
                    Confirmado = true;

                }
            }

            if (Input.GetButtonDown(playerIndice.ToString() + "B") && Confirmado)
            {
                print("B");
                Confirmado = false;
            }
            else
            {
                Selecao = false;
                for (int x = 0; x < Personagens.Length; x++)
                {
                    Personagens[x].SetActive(false);
                }
                Person = AutoSave.Players.Nenhum;
                indice = 0;
            }
        }
    }

    public void MudarPersonagem(int indice)
    {
        if (indice > Personagens.Length - 1)
            indice = 0;

        if (indice < 0)
            indice = Personagens.Length - 1;

        for (int x = 0; x < Personagens.Length; x++)
        {
            Personagens[x].SetActive(x == indice ? true : false);
            Person = Personagens[x].GetComponent<Atributos>().Personagem;
        }
    }
}
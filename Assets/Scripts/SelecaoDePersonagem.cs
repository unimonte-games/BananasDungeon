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
            var ctrAnim = Personagens[x].GetComponent<ControleDeAnimacao>();
            Animator anim = Personagens[x].GetComponent<Animator>();
            var arma = Personagens[x].GetComponent<ControleDeArmas>().ArmaInicial.ToString();
            ctrAnim.Idle(1);
            anim.SetBool(arma, true);
            Personagens[x].SetActive(false);
            print("ué");
        }
    }

    void Update()
    {
        if (Personagens.Length == 0)
            return;

        if (Selecao)
        {
            if (Input.GetAxis(playerIndice.ToString() + "Right/Left") != 0)
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
            }

            if (Input.GetButtonDown(playerIndice.ToString() + "A"))
            {
                print("A");
                print(FindObjectOfType<Selecao>().PodeSelecionar(Person));
                if (FindObjectOfType<Selecao>().PodeSelecionar(Person))
                    Confirmado = true;
            }

            if (Input.GetButtonDown(playerIndice.ToString() + "B") && Confirmado)
            {
                print("B");
                Confirmado = false;
            }

            if (Input.GetButtonDown(playerIndice.ToString() + "B") && !Confirmado)
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

        if (Input.GetButtonDown(playerIndice.ToString() + "Start") && !Selecao)
        {
            print(playerIndice.ToString() + "Start");
            Selecao = true;
            Debug.Log(Personagens.Length, gameObject);
            Personagens[0].SetActive(true);
            Personagens[0].GetComponent<ControleDeAnimacao>().Idle(1);
            Person = Personagens[0].GetComponent<Atributos>().Personagem;
            print("Ativa porra");
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
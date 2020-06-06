using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Loja : MonoBehaviour
{
    public Text Titulo;
    float delayBotao = 1.5f;
    public Dados.PlayerIndice Player;
    [Space(20)]
    public Item[] Itens;
    [System.Serializable]
    public struct Item
    {
        public string NomeArma;
        public Dados.Armas Arma;
        public GameObject[] ArmaNiveis;
    }
    [Space(20)]
    int indice = 0;


    void Start()
    {
        IniciaArma();
        for (int x = 0; x < Itens.Length; x++)
        {
            for (int y = 0; y < Itens[x].ArmaNiveis.Length; y++)
            {
                Itens[x].ArmaNiveis[y].SetActive(x == 2 ? true : false);
            }
        }
    }

    void Update()
    {
        delayBotao += Time.deltaTime;

        if (Player == Dados.PlayerIndice.Vazio)
            return;

        if (Input.GetButtonDown(Player.ToString() + "RB") && delayBotao > 1.5f)//Próximo
        {
            delayBotao = 0;
            ArmaSeguinte();
        }

        if (Input.GetButtonDown(Player.ToString() + "LB") && delayBotao > 1.5f)//Anterior
        {
            delayBotao = 0;
            ArmaAnterior();
        }
    }

    public void IniciaArma()
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
            for (int y = 0; y < Itens[x].ArmaNiveis.Length; y++)
            {
                Itens[x].ArmaNiveis[y].SetActive(x == indice ? true : false);
            }
        }
    }
}
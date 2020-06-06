using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Loja : MonoBehaviour
{
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
        for (int x = 0; x < Itens.Length; x++)
        {
            for (int y = 0; y < Itens[x].ArmaNiveis.Length; y++)
            {
                Itens[x].ArmaNiveis[y].SetActive(x == 0 ? true : false);
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

    public void IniciaArma(Dados.Armas arma)
    {
        
        for (int x = 0; x < Itens.Length; x++)
        {
            if (Itens[x].Arma == arma)
            {
                
            }
        }
    }

    public void ArmaSeguinte()
    {
        indice = 1;
        TrocaArma();
    }

    public void ArmaAnterior()
    {
        indice = 0;
        TrocaArma();
    }

    public void TrocaArma()
    {
        for (int x = 0; x < Itens.Length; x++)
        {
            for (int y = 0; y < Itens[x].ArmaNiveis.Length; y++)
            {
                Itens[x].ArmaNiveis[y].SetActive(x == indice ? true : false);
            }
        }
    }
}
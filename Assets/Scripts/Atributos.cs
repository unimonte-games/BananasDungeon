using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Atributos : MonoBehaviour
{
    public int Vida = 1000;
    public int vidaAtual = 1000;
    public Slider barraVida;

    void Awake()
    {
        var aux = GetComponent<Move>().playerIndice;
        barraVida = GameObject.Find("HP" + aux.ToString()).GetComponent<Slider>();
        barraVida.maxValue = Vida;
        barraVida.value = vidaAtual;
    }

    public void CausarDano(int Dano)
    {
         vidaAtual -= Dano;
        barraVida.value = vidaAtual;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selecionados : MonoBehaviour
{
    public static List<Jogador> Jogadores = new List<Jogador>();
    public struct Jogador
    {
        public Dados.PlayerIndice playerIndice;
        public Dados.Personagens personagem;
    }
}
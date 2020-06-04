using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Dados
{
    public enum Armas
    {
        Nenhum = 0,
        Alabarda,
        Arco,
        Cajado,
        Espada,
        Lanca,
        Machado
    }

    public enum PlayerIndice
    {
        Vazio = 0,
        P1,
        P2,
        P3,
        P4
    }

    public enum Personagens
    {
        Nenhum = -1,
        Amazona = 0,
        Oliver
    }

    public enum ArmaNivel
    {
        Nivel1 = 0,
        Nivel2,
        Nivel3,
        Nivel4,
        Nivel5
    }
}